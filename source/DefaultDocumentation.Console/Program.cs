using CommandLine;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<SettingsArgs>(args)
                .WithParsed(a =>
                {
                    Generator.Execute(new Settings(
                        a.AssemblyFilePath,
                        a.DocumentationFilePath,
                        a.ProjectDirectoryPath,
                        a.OutputDirectoryPath,
                        a.HomeName,
                        a.InvalidCharReplacement,
                        a.FileNameMode,
                        a.RemoveFileExtensionFromLinks,
                        a.NestedTypeVisibility,
                        a.GeneratedPages));
                });
        }
    }
}
