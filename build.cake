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
            .WithProperty("AdditionalPackageTags", ".NET35 .NET40 portable Silverlight")
            .WithProperty("PackageOutputPath", System.IO.Path.GetFullPath(packDir)));

        try
        {
            foreach (var singleTargetCustomizer in new Action<MSBuildSettings>[]
            {
                s => s
                    .WithProperty("TargetFramework", "net35-client")
                    .WithProperty("TargetFrameworks", "net35-client")
                    .WithProperty("PackageId", "AsyncBridge.Net35")
                    .WithProperty("AssemblyName", "AsyncBridge.Net35")
                    .WithProperty("AdditionalPackageTags", ".NET35")
                    .WithProperty("Description", "C# 5 async/await support for .NET Framework 3.5"),
                s => s
                    .WithProperty("TargetFramework", "portable-net40+sl5")
                    .WithProperty("TargetFrameworks", "portable-net40+sl5")
                    .WithProperty("PackageId", "AsyncBridge.Portable")
                    .WithProperty("AssemblyName", "AsyncBridge.Portable")
                    .WithProperty("AdditionalPackageTags", "portable Silverlight .NET40")
                    .WithProperty("Description", "C# 5 async/await support for Silverlight 5 (portable)")
            })
            {
                // Restore is necessary because otherwise nuspec shows all target frameworks
                var restoreSettings = CreateMSBuildSettings("Restore");
                singleTargetCustomizer.Invoke(restoreSettings);
                MSBuild("src/AsyncBridge", restoreSettings);

                var packSettings = CreateMSBuildSettings("Pack")
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
