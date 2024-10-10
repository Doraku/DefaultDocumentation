using System;
using System.Collections.Generic;
using CommandLine;

namespace DefaultDocumentation;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "will be instantiated through CommandLine")]
internal sealed class SettingsArgs : IRawSettings
{
    private static T GetEnum<T>(IEnumerable<T> values)
            where T : Enum, IConvertible
    {
        int value = 0;
        foreach (T flag in values)
        {
            value |= flag.ToInt32(null);
        }

        return (T)(object)value;
    }

    [Option('h', nameof(LogLevel), HelpText = "Minimum level of the logs to display")]
    public string LogLevel { get; set; }

    [Option('j', nameof(ConfigurationFilePath), HelpText = "Path to the json configuration file to use")]
    public string ConfigurationFilePath { get; set; }

    [Option('a', nameof(AssemblyFilePath), HelpText = "Path to the assembly file")]
    public string AssemblyFilePath { get; set; }

    [Option('d', nameof(DocumentationFilePath), HelpText = "Path to the xml documentation file, if not specified DefaultDocumentation will assume it is in the same folder as the assembly")]
    public string DocumentationFilePath { get; set; }

    [Option('p', nameof(ProjectDirectoryPath), HelpText = "Path to the project source folder")]
    public string ProjectDirectoryPath { get; set; }

    [Option('o', nameof(OutputDirectoryPath), HelpText = "Path to the output folder, if not specified the documentation will be generated in the same folder as the xml documentation file")]
    public string OutputDirectoryPath { get; set; }

    [Option('n', nameof(AssemblyPageName), HelpText = "Name of the assembly documentaton file")]
    public string AssemblyPageName { get; set; }

    [Option('s', nameof(GeneratedAccessModifiers), Separator = ',', HelpText = "State elements with which access modifier should be generated")]
    public IEnumerable<GeneratedAccessModifiers> GeneratedAccessModifiers { get; set; }

    [Option('u', nameof(IncludeUndocumentedItems), HelpText = "If true items with no documentation will also be included")]
    public bool IncludeUndocumentedItems { get; set; }

    [Option('g', nameof(GeneratedPages), Separator = ',', HelpText = "State which elements should have their own page")]
    public IEnumerable<GeneratedPages> GeneratedPages { get; set; }

    [Option('l', nameof(LinksOutputFilePath), HelpText = "File path where the documentation will generate its links")]
    public string LinksOutputFilePath { get; set; }

    [Option('b', nameof(LinksBaseUrl), HelpText = "Base url of the documentation for the generated links file")]
    public string LinksBaseUrl { get; set; }

    [Option('e', nameof(ExternLinksFilePaths), Separator = '|', HelpText = "Links files to use for external documentation")]
    public IEnumerable<string> ExternLinksFilePaths { get; set; }

    [Option(nameof(Plugins), Separator = '|', HelpText = "plugin files to use to create the documentation")]
    public IEnumerable<string> Plugins { get; set; }

    [Option(nameof(UrlFactories), Separator = '|', HelpText = "Name or [Type Assembly] of the IUrlFactory to use to create documentation url")]
    public IEnumerable<string> UrlFactories { get; set; }

    [Option(nameof(Elements), Separator = '|', HelpText = "[Type Assembly] of the explicit element implementations to use to create the documentation")]
    public IEnumerable<string> Elements { get; set; }

    [Option(nameof(FileNameFactory), HelpText = "Name or [Type Assembly] of the IFileNameFactory to use to create documentation files")]
    public string FileNameFactory { get; set; }

    [Option(nameof(Sections), Separator = '|', HelpText = "Name or [Type Assembly] of the ISectionWriter to use to create the documentation")]
    public IEnumerable<string> Sections { get; set; }

    GeneratedAccessModifiers IRawSettings.GeneratedAccessModifiers => GetEnum(GeneratedAccessModifiers);

    GeneratedPages IRawSettings.GeneratedPages => GetEnum(GeneratedPages);
}
