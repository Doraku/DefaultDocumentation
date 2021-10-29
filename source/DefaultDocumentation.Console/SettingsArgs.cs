using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommandLine;

namespace DefaultDocumentation
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes")]
    internal sealed class SettingsArgs
    {
        [Option('h', nameof(LogLevel), Required = false, HelpText = "Minimum level of the logs to display")]
        public string LogLevel { get; set; }

        [Option('a', nameof(AssemblyFilePath), Required = true, HelpText = "Path to the assembly file")]
        public string AssemblyFilePath { get; set; }

        [Option('d', nameof(DocumentationFilePath), Required = false, HelpText = "Path to the xml documentation file, if not specified DefaultDocumentation will assume it is in the same folder as the assembly")]
        public string DocumentationFilePath { get; set; }

        [Option('p', nameof(ProjectDirectoryPath), Required = false, HelpText = "Path to the project source folder")]
        public string ProjectDirectoryPath { get; set; }

        [Option('o', nameof(OutputDirectoryPath), Required = false, HelpText = "Path to the output folder, if not specified the documentation will be generated in the same folder as the xml documentation file")]
        public string OutputDirectoryPath { get; set; }

        [Option('c', nameof(InvalidCharReplacement), Required = false, HelpText = "Replacement for url invalid char")]
        public string InvalidCharReplacement { get; set; }

        [Option('n', nameof(AssemblyPageName), Required = false, HelpText = "Name of the assembly documentaton file")]
        public string AssemblyPageName { get; set; }

        [Option('m', nameof(FileNameFactory), Required = false, HelpText = "Name or [Assembly Type] of the IFileNameFactory to use to create documentation files")]
        public string FileNameFactory { get; set; }

        [Option('x', nameof(RemoveFileExtensionFromLinks), Required = false, HelpText = "If true skip file extension in generated page links")]
        public bool RemoveFileExtensionFromLinks { get; set; }

        [Option('v', nameof(NestedTypeVisibilities), Required = false, Separator = ',', HelpText = "Emplacement of nested types in documentation")]
        public IEnumerable<NestedTypeVisibilities> NestedTypeVisibilities { get; set; }

        [Option('g', nameof(GeneratedPages), Required = false, Separator = ',', HelpText = "State which elements should have their own page")]
        public IEnumerable<GeneratedPages> GeneratedPages { get; set; }

        [Option('s', nameof(GeneratedAccessModifiers), Required = false, Separator = ',', HelpText = "State elements with which access modifier should be generated")]
        public IEnumerable<GeneratedAccessModifiers> GeneratedAccessModifiers { get; set; }

        [Option('u', nameof(IncludeUndocumentedItems), Required = false, HelpText = "If true items with no documentation will also be included")]
        public bool IncludeUndocumentedItems { get; set; }

        [Option('i', nameof(IgnoreLineBreak), Required = false, HelpText = "If true line break in the documentation are no longer transformed as a markdown line break (two space at the end of a line)")]
        public bool IgnoreLineBreak { get; set; }

        [Option('l', nameof(LinksOutputFilePath), Required = false, HelpText = "File path where the documentation will generate its links")]
        public string LinksOutputFilePath { get; set; }

        [Option('b', nameof(LinksBaseUrl), Required = false, HelpText = "Base url of the documentation for the generated links file")]
        public string LinksBaseUrl { get; set; }

        [Option('e', nameof(ExternLinksFilePaths), Required = false, Separator = '|', HelpText = "Links files to use for external documentation")]
        public IEnumerable<string> ExternLinksFilePaths { get; set; }
    }
}
