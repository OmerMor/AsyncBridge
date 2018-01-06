using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyProduct("AsyncBridge")]
[assembly: AssemblyCompany("Daniel Grunwald, Omer Mor, Alex Davies")]
[assembly: AssemblyCopyright("Copyright © 2012 Daniel Grunwald")]

#if NET40
[assembly: AssemblyTitle("AsyncBridge - Async Support for .NET 4.0")]
[assembly: AssemblyDescription("Adds the new C#5 async features for .NET 4 projects")]
#elif NET35
[assembly: AssemblyTitle("AsyncBridge - Async Support for .NET 3.5")]
[assembly: AssemblyDescription("Adds the new C#5 async features for .NET 3.5 projects")]
#elif PORTABLE
[assembly: AssemblyTitle("AsyncBridge - Async Support for .NET 4.0 and Silverlight 5 (Portable Library)")]
[assembly: AssemblyDescription("Adds the new C#5 async features for .NET 4.0 and Silverlight 5 projects (portable library)")]
#else
#error Missed platform define
#endif

#if !PORTABLE
[assembly: ComVisible(false)]
#endif

[assembly: AssemblyVersion("0.0.0")] // only increment major (breaking changes)
[assembly: AssemblyFileVersion(Metadata.Version)]
[assembly: AssemblyInformationalVersion(Metadata.Version)]

internal class Metadata
{
    internal const string Version = "0.2.0";
}
