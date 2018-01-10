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
        MSBuild("src/AsyncBridge", CreateMSBuildSettings("Pack")
            .WithProperty("PackageOutputPath", System.IO.Path.GetFullPath(packDir)));
    });

RunTarget(Argument("target", "Test"));
