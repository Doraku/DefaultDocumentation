using CommandLine;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            new Parser(s => s.CaseSensitive = false)
                .ParseArguments<SettingsArgs>(args)
                .WithParsed(a =>
                {
                    Generator.Execute(new Settings(
                        a.AssemblyFilePath,
                        a.DocumentationFilePath,
                        a.ProjectDirectoryPath,
                        a.OutputDirectoryPath,
                        a.AssemblyPageName,
                        a.InvalidCharReplacement,
                        a.FileNameMode,
                        a.RemoveFileExtensionFromLinks,
                        a.NestedTypeVisibilities,
                        a.GeneratedPages));
                });
        }
    }
}
