using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AsyncBridge.Utils.UpdateStringResources
{
    public static class Program
    {
        public static void Main()
        {
            RegexReplaceFileContents(
                GetStringResourceFilePath(),
                @"(?<=^\s*)(public|internal)\s+((static(\s+readonly)?)|const)\s+string\s+(?<name>\w+)(\s*=\s*[^;]+)?;(?=\s*$)",
                match => GenerateLine(match.Groups["name"].Value),
                RegexOptions.Multiline);
        }

        private static string GetStringResourceFilePath([CallerFilePath] string callerFilePath = null)
        {
            return Path.Join(
                Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(callerFilePath))),
                @"src\AsyncBridge\System\SR.cs");
        }

        private static void RegexReplaceFileContents(string filePath, string pattern, MatchEvaluator evaluator, RegexOptions options)
        {
            using (var srFile = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                string text;
                using (var reader = new StreamReader(srFile, new UTF8Encoding(false), false, 4096, leaveOpen: true))
                    text = reader.ReadToEnd();

                text = Regex.Replace(text, pattern, evaluator, options);

                srFile.Seek(0, SeekOrigin.Begin);
                srFile.SetLength(0);

                using (var writer = new StreamWriter(srFile))
                    writer.Write(text);
            }
        }

        private static readonly ImmutableArray<string> AssemblyNames = ImmutableArray.Create(
            "System.Private.CoreLib",
            "System.Collections.Concurrent",
            "System.Threading",
            "System.Threading.Tasks.Parallel");

        private static readonly ImmutableArray<Type> StringResourceTypes = AssemblyNames
            .Select(assemblyName => Assembly.Load(assemblyName).GetType("System.SR"))
            .Where(type => type != null)
            .ToImmutableArray();

        private static string GenerateLine(string name)
        {
            var messages = StringResourceTypes
                .Select(t => t.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Static))
                .Where(p => p != null)
                .Select(p => (string)p.GetValue(null))
                .Distinct();

            var message = messages.Single();

            return $"public const string {name} = \"{message.Replace("\"", "\\\"")}\";";
        }
    }
}
