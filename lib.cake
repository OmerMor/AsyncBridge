public void DefaultClean()
{
    var binDirectories = GetFiles("**/*.*proj")
        .Select(csproj => csproj.GetDirectory().Combine("bin"))
        .Where(binDirectory => DirectoryExists(binDirectory))
        .ToList();

    if (binDirectories.Any())
    {
        Information("Deleting bin directories:");

        foreach (var binDirectory in binDirectories)
        {
            for (var attempt = 1;; attempt++)
            {
                Information(binDirectory);
                try
                {
                    DeleteDirectory(binDirectory, new DeleteDirectorySettings { Recursive = true });
                    break;
                }
                catch (IOException ex) when (attempt < 3 && (WinErrorCode)ex.HResult == WinErrorCode.DirNotEmpty)
                {
                    Information("Another process added files to the directory while its contents were being deleted. Retrying...");
                }
            }
        }
    }
    else
    {
        Information("No bin directories to delete.");
    }
}

private enum WinErrorCode : ushort
{
    DirNotEmpty = 145
}

public static string GetCISuffix(CISettings settings)
{
    if (settings.PullRequestNumber != null)
    {
        return $"{settings.BuildNumber}.pr.{settings.PullRequestNumber.Value}";
    }

    if ("master".Equals(settings.Branch, StringComparison.OrdinalIgnoreCase))
    {
        return $"ci.{settings.BuildNumber}";
    }

    if (settings.Branch == null) return settings.BuildNumber.ToString();

    var builder = (StringBuilder)null;
    var separate = true;

    if (settings.Branch != null)
    {
        foreach (var c in settings.Branch)
        {
            if (IsValidSemVerLabelChar(c))
            {
                if (separate)
                {
                    if (builder == null)
                        builder = new StringBuilder().Append(settings.BuildNumber).Append('.');
                    else
                        builder.Append('-');
                    separate = false;
                }
                builder.Append(c);
                if (builder.Length == 20) break; // NuGet prerelease version length limit
            }
            else
            {
                separate = true;
            }
        }
    }

    return builder?.ToString() ?? settings.BuildNumber.ToString();

    bool IsValidSemVerLabelChar(char value)
    {
        // https://semver.org/#spec-item-9
        return value == '-'
            || ('0' <= value && value <= '9')
            || ('A' <= value && value <= 'Z')
            || ('a' <= value && value <= 'z');
    }
}

public static string ChangeVersionSuffix(string version, string prereleaseLabel)
{
    if (string.IsNullOrEmpty(version) || !char.IsDigit(version[0]) || !char.IsLetterOrDigit(version[version.Length - 1]))
    {
        throw new ArgumentException("Version must begin with a digit and end with a digit or letter.", nameof(version));
    }

    var suffixIndex = version.IndexOf('-');
    if (suffixIndex == -1) suffixIndex = version.IndexOf('+');

    if (string.IsNullOrEmpty(prereleaseLabel))
    {
        return suffixIndex == -1
            ? version
            : version.Substring(0, suffixIndex);
    }

    if (!char.IsLetterOrDigit(prereleaseLabel[0]) || !char.IsLetterOrDigit(prereleaseLabel[prereleaseLabel.Length - 1]))
    {
        throw new ArgumentException("Prerelease label must be null or empty or must begin and end with a digit or letter.", nameof(prereleaseLabel));
    }

    return suffixIndex == -1
        ? version + '-' + prereleaseLabel
        : version.Substring(0, suffixIndex + 1) + prereleaseLabel;
}

public bool TryReadFromCsproj(FilePath filePath, out string version)
{
    version = XmlPeek(filePath, "/Project/PropertyGroup/Version")?.Trim();
    if (!string.IsNullOrEmpty(version)) return true;
    version = null;
    return false;
}

public CISettings? TryDetectCISettings()
{
    if (AppVeyor.IsRunningOnAppVeyor)
    {
        var env = AppVeyor.Environment;

        return env.PullRequest.IsPullRequest
            ? new CISettings(env.Build.Number, env.PullRequest.Number)
            : new CISettings(env.Build.Number, env.Repository.Branch);
    }

    return null;
}

public readonly struct CISettings
{
    public int BuildNumber { get; }
    public string Branch { get; }
    public int? PullRequestNumber { get; }
    public bool IsPullRequest => PullRequestNumber != null;

    public CISettings(int buildNumber, string branch)
    {
        BuildNumber = buildNumber;
        Branch = branch;
        PullRequestNumber = null;
    }

    public CISettings(int buildNumber, int pullRequestNumber)
    {
        BuildNumber = buildNumber;
        Branch = null;
        PullRequestNumber = pullRequestNumber;
    }
}
