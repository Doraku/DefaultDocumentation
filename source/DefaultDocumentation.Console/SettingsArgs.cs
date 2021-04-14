using CommandLine;

namespace DefaultDocumentation
{
    internal sealed class SettingsArgs
    {
        [Option('a', Required = true, HelpText = "Path to the assembly file")]
        public string AssemblyFilePath { get; set; }

        [Option('d', Required = false, HelpText = "Path to the xml documentation file, if not specified DefaultDocumentation will assume it is in the same folder as the assembly")]
        public string DocumentationFilePath { get; set; }

        [Option('p', Required = false, HelpText = "Path to the project source folder")]
        public string ProjectDirectoryPath { get; set; }

        [Option('o', Required = false, HelpText = "Path to the output folder, if not specified the documentation will be generated in the same folder as the xml documentation file")]
        public string OutputDirectoryPath { get; set; }

        [Option('c', Required = false, HelpText = "Replacement for url invalid char")]
        public string InvalidCharReplacement { get; set; }

        [Option('A', Required = false, HelpText = "Name of the assembly documentaton file")]
        public string AssemblyPageName { get; set; }

        [Option('m', Required = false, HelpText = "Naming convention to use for documentation files")]
        public FileNameMode FileNameMode { get; set; }

        [Option('x', Required = false, HelpText = "If true skip file extension in generated page links")]
        public bool RemoveFileExtensionFromLinks { get; set; }

        [Option('v', Required = false, HelpText = "Emplacement of nested types in documentation")]
        public NestedTypeVisibilities NestedTypeVisibilities { get; set; }

        [Option('P', Required = false, HelpText = "State which elements should have their own page")]
        public GeneratedPages GeneratedPages { get; set; }

        [Option('l', Required = false, HelpText = "File path where the documentation will generate its links")]
        public string LinksOutputFilePath { get; set; }

        [Option('b', Required = false, HelpText = "Base url of the documentation for the generated links file")]
        public string LinksBaseUrl { get; set; }

        [Option('L', Required = false, HelpText = "| separated links files to use for external documentation")]
        public string ExternLinksFilePaths { get; set; }
    }
}
