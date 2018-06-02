#load lib.cake
using System.Diagnostics;

var configuration = Argument("configuration", "Release");

var packDir = Directory("pub");

if (!TryReadFromCsproj("src/AsyncBridge/AsyncBridge.csproj", out var version))
    throw new Exception("Failed to read version.");

var ciSettings = TryDetectCISettings();

if (ciSettings != null)
{
    version = ChangeVersionSuffix(version, GetCISuffix(ciSettings.Value));
    AppVeyor.UpdateBuildVersion(version);
}

MSBuildSettings CreateMSBuildSettings(string target) => new MSBuildSettings()
    .UseToolVersion(MSBuildToolVersion.VS2017)
    .SetConfiguration(configuration)
    .SetVerbosity(Verbosity.Minimal)
    .WithTarget(target)
    .WithProperty("Version", version);


Task("Clean").Does(() => DefaultClean());

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        MSBuild(".", CreateMSBuildSettings("Build")
            .WithRestore()
            .WithProperty("DebugType", "pdbonly")); // Needed for OpenCover
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        #tool OpenCover
        OpenCover(RunTests, "opencover.xml", new OpenCoverSettings { ReturnTargetCodeOffset = 0 }
            .WithFilter("+[AsyncBridge]*"));

        if (AppVeyor.IsRunningOnAppVeyor)
        {
            #tool Codecov
            #addin Cake.Codecov
            Codecov(new CodecovSettings
            {
                Files = new[] { "opencover.xml" },
                EnvironmentVariables = new Dictionary<string, string>
                {
                    // https://github.com/cake-contrib/Cake.Codecov#known-issues
                    ["APPVEYOR_BUILD_VERSION"] = version,

                    // Can’t see any way to get codecov.io to get the build URL right besides specifying it manually.
                    // https://twitter.com/jnm236/status/988191635782733825
                    // https://docs.codecov.io/reference#upload
                    // https://github.com/codecov/codecov-exe/blob/e631d74555dcf89c3de9ea83884610e2a2375482/Source/Codecov/Services/ContinuousIntegrationServers/Appveyor.cs#L51
                    ["CI_BUILD_URL"] = $"https://ci.appveyor.com/project/"
                        + EnvironmentVariable("APPVEYOR_ACCOUNT_NAME") + "/" + EnvironmentVariable("APPVEYOR_PROJECT_SLUG") + "/build/" + version
                },

                // https://twitter.com/jnm236/status/988192423049342977
                // Codecov.io defaults to displaying the name from &build, which defaults to %APPVEYOR_JOB_ID% e.g. ‘r3f42taes5j98dgw’:
                // https://github.com/codecov/codecov-exe/blob/e631d74555dcf89c3de9ea83884610e2a2375482/Source/Codecov/Services/ContinuousIntegrationServers/Appveyor.cs#L32
                // Any change to &build that I’ve tried, including switching a single letter, causes Codecov.exe to give "[Fatal] Failed to upload the report."
                // So, setting &name instead.
                Name = version
            });
        }
    });

private void RunTests(ICakeContext testToolContext)
{
    testToolContext.VSTest(
        from (string name, string framework) project in new[]
        {
            ("AsyncBridge.Tests", "net20"),
            ("AsyncBridge.Tests", "net35"),
            ("AsyncBridge.Tests", "net40"),
            ("AsyncTargetingPack.Tests", "net40"),
            ("ReferenceAsync.Net45", "net45")
        }
        select File($"tests/{project.name}/bin/{configuration}/{project.framework}/{project.name}.dll").Path,
        FixToolPath(new VSTestSettings
        {
            Parallel = true
        }));

    VSTestSettings FixToolPath(VSTestSettings settings)
    {
        #tool vswhere
        settings.ToolPath =
            VSWhereLatest(new VSWhereLatestSettings { Requires = "Microsoft.VisualStudio.PackageGroup.TestTools.Core" })
            .CombineWithFilePath(File(@"Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"));
        return settings;
    }
}

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        MSBuild(
            "src/AsyncBridge",
            CreateMSBuildSettings("Rebuild") // Rebuilds the shipped assemblies as needed to create portable PDBs
                .WithTarget("Pack")          // since the OpenCover forces the Build target to build with Windows PDBs.
                .WithProperty("PackageOutputPath", System.IO.Path.GetFullPath(packDir)));

        if (ciSettings?.Branch == "master")
        {
            AppVeyor.UploadArtifact(packDir.Path.CombineWithFilePath($"AsyncBridge.{version}.nupkg"));
        }
    });

RunTarget(Argument("target", "Test"));
