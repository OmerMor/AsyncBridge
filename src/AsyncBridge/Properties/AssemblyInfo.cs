using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyProduct("AsyncBridge")]
[assembly: AssemblyCompany("Daniel Grunwald, Omer Mor, Alex Davies")]
[assembly: AssemblyCopyright("Copyright © 2012 Daniel Grunwald")]

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
