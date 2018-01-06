using System.Diagnostics;

var configuration = Argument("configuration", "Release");

var packDir = Directory("pub");

Task("Clean")
    .Does(() => MSBuild(".", settings => settings.SetConfiguration(configuration).WithTarget("Clean")));

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() => MSBuild(".", settings => settings.SetConfiguration(configuration).WithTarget("Restore")));

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => MSBuild(".", settings => settings.SetConfiguration(configuration).WithTarget("Build")));

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        VSTest(
            from project in new[]
            {
                "AsyncBridge.Net35.Tests",
                "AsyncBridge.Tests",
                "AsyncTargetingPack.Tests",
                "ReferenceAsync.Net45"
            } select File($"tests/{project}/bin/{configuration}/{project}.dll").Path,
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
    });

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        foreach (var (project, settingsCustomizer) in new (string, Action<NuGetPackSettings>)[]
        {
            ("AsyncBridge", s =>
            {
                s.Tags = s.Tags.Concat(new[] { ".NET40" }).ToList();
            }),
            ("AsyncBridge.Net35", s =>
            {
                s.Tags = s.Tags.Concat(new[] { ".NET35" }).ToList();
                s.Dependencies = new[] { new NuSpecDependency { Id = "TaskParallelLibrary", Version = "1.0.2856" } };
            }),
            ("AsyncBridge.Portable", s =>
            {
                s.Tags = s.Tags.Concat(new[] { "portable", "Silverlight", ".NET40" }).ToList();
            }),
        })
        {
            var binDir = Directory($"src/{project}/bin/{configuration}");
            var versionInfo = FileVersionInfo.GetVersionInfo(binDir + File($"{project}.dll"));

            EnsureDirectoryExists(packDir);
            var settings = new NuGetPackSettings
            {
                Id = project,
                Version = versionInfo.ProductVersion,
                Title = versionInfo.ProductName,
                Authors = new[] { versionInfo.CompanyName },
                Description = versionInfo.Comments,
                Copyright = versionInfo.LegalCopyright,
                Tags = new[] { "async", "bridge", "C#", "C#5" },
                Files = new[]
                {
                    new NuSpecContent { Source = File($"{project}.dll"), Target = "lib" },
                    new NuSpecContent { Source = File($"{project}.xml"), Target = "lib" }
                },
                ProjectUrl = new Uri("https://omermor.github.com/AsyncBridge/"),
                LicenseUrl = new Uri("https://github.com/OmerMor/AsyncBridge/blob/master/LICENSE.md"),
                BasePath = binDir,
                OutputDirectory = packDir
            };
            settingsCustomizer?.Invoke(settings);
            NuGetPack(settings);
        }
    });

RunTarget(Argument("target", "Test"));
