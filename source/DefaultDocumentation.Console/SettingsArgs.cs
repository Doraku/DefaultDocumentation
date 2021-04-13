using CommandLine;

namespace DefaultDocumentation
{
    internal sealed class SettingsArgs
    {
        [Option(Required = true, HelpText = "Path to the assembly file")]
        public string AssemblyFilePath { get; set; }

        [Option(Required = false, HelpText = "Path to the xml documentation file, if not specified DefaultDocumentation will assume it is in the same folder as the assembly")]
        public string DocumentationFilePath { get; set; }

        [Option(Required = false, HelpText = "Path to the project source folder")]
        public string ProjectDirectoryPath { get; set; }

        [Option(Required = false, HelpText = "Path to the output folder, if not specified the documentation will be generated in the same folder as the xml documentation file")]
        public string OutputDirectoryPath { get; set; }

        [Option(Required = false, HelpText = "Replacement for url invalid char")]
        public string InvalidCharReplacement { get; set; }

        [Option(Required = false, HelpText = "Name of the home documentaton file")]
        public string HomeName { get; set; }

        [Option(Required = false, HelpText = "Naming convention to use for documentation files")]
        public FileNameMode FileNameMode { get; set; }

        [Option(Required = false, HelpText = "If true skip file extension in generated page links")]
        public bool RemoveFileExtensionFromLinks { get; set; }

        [Option(Required = false, HelpText = "Emplacement of nested types in documentation")]
        public NestedTypeVisibilities NestedTypeVisibilities { get; set; }

        [Option(Required = false, HelpText = "State which elements should have their own page")]
        public GeneratedPages GeneratedPages { get; set; }
    }
}
