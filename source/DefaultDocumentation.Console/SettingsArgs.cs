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

        [Option('i', Required = false, HelpText = "Replacement for url invalid char")]
        public string InvalidCharReplacement { get; set; }

        [Option('n', Required = false, HelpText = "Name of the home documentaton file")]
        public string HomeName { get; set; }

        [Option('f', Required = false, HelpText = "Naming convention to use for documentation files")]
        public FileNameMode FileNameMode { get; set; }

        [Option('r', Required = false, HelpText = "If true skip file extension in generated page links")]
        public bool RemoveFileExtensionFromLinks { get; set; }

        [Option('v', Required = false, HelpText = "Emplacement of nested types in documentation")]
        public NestedTypeVisibilities NestedTypeVisibilities { get; set; }

        [Option('g', Required = false, HelpText = "State which elements should have their own page")]
        public GeneratedPages GeneratedPages { get; set; }
    }
}
