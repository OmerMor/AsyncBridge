using System.Diagnostics;

var configuration = Argument("configuration", "Release");

var packDir = Directory("pub");

MSBuildSettings CreateMSBuildSettings(string target) => new MSBuildSettings()
    .UseToolVersion(MSBuildToolVersion.VS2017)
    .SetConfiguration(configuration)
    .WithTarget(target);

Task("Clean")
    .Does(() => MSBuild(".", CreateMSBuildSettings("Clean")));

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() => MSBuild(".", CreateMSBuildSettings("Restore")));

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => MSBuild(".", CreateMSBuildSettings("Build")));

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        VSTest(
            from (string name, string framework) project in new[]
            {
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
    });

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        // Build unified package
        MSBuild("src/AsyncBridge", CreateMSBuildSettings("Pack")
            .WithProperty("AdditionalPackageTags", ".NET Framework 3.5 4.0 portable Silverlight net35 net40 sl5")
            .WithProperty("PackageOutputPath", System.IO.Path.GetFullPath(packDir)));

        try
        {
            foreach (var singleTargetCustomizer in new Action<MSBuildSettings>[]
            {
                s => s
                    .WithProperty("TargetFramework", "net35-client")
                    .WithProperty("TargetFrameworks", "net35-client")
                    .WithProperty("PackageId", "AsyncBridge.Net35")
                    .WithProperty("Title", "AsyncBridge.Net35 (deprecated)")
                    .WithProperty("AssemblyName", "AsyncBridge.Net35")
                    .WithProperty("AdditionalPackageTags", ".NET Framework 3.5 net35"),
                s => s
                    .WithProperty("TargetFramework", "portable-net40+sl5")
                    .WithProperty("TargetFrameworks", "portable-net40+sl5")
                    .WithProperty("PackageId", "AsyncBridge.Portable")
                    .WithProperty("Title", "AsyncBridge.Portable (deprecated)")
                    .WithProperty("AssemblyName", "AsyncBridge.Portable")
                    .WithProperty("AdditionalPackageTags", "portable Silverlight sl5")
            })
            {
                // Restore is necessary because otherwise nuspec shows all target frameworks
                var restoreSettings = CreateMSBuildSettings("Restore");
                singleTargetCustomizer.Invoke(restoreSettings);
                MSBuild("src/AsyncBridge", restoreSettings);

                var packSettings = CreateMSBuildSettings("Pack")
                    .WithProperty("IsPackingSingleTarget", "true")
                    .WithProperty("Description", "Deprecated. Use the unified package AsyncBridge instead.")
                    .WithProperty("PackageOutputPath", System.IO.Path.GetFullPath(packDir));
                singleTargetCustomizer.Invoke(packSettings);
                MSBuild("src/AsyncBridge", packSettings);
            }
        }
        finally
        {
            // Don’t leave restore in a weird state
            MSBuild("src/AsyncBridge", CreateMSBuildSettings("Restore"));
        }
    });

RunTarget(Argument("target", "Test"));
