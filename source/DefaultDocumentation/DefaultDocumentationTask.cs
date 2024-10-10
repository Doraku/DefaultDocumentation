using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace DefaultDocumentation;

public sealed class DefaultDocumentationTask : Microsoft.Build.Utilities.Task, IRawSettings
{
    private static readonly char[] _separators = ['|'];

    public string LogLevel { get; set; }

    public string ConfigurationFilePath { get; set; }

    [Required]
    public string AssemblyFilePath { get; set; }

    public string DocumentationFilePath { get; set; }

    public string ProjectDirectoryPath { get; set; }

    public string OutputDirectoryPath { get; set; }

    public string AssemblyPageName { get; set; }

    public string GeneratedAccessModifiers { get; set; }

    public bool IncludeUndocumentedItems { get; set; }

    public string GeneratedPages { get; set; }

    public string LinksOutputFilePath { get; set; }

    public string LinksBaseUrl { get; set; }

    public string ExternLinksFilePaths { get; set; }

    public string Plugins { get; set; }

    public string FileNameFactory { get; set; }

    public string UrlFactories { get; set; }

    public string Sections { get; set; }

    public string Elements { get; set; }

    private static T GetEnum<T>(string argumentName, string stringValue) where T : struct
        => string.IsNullOrEmpty(stringValue)
        ? default
        : (Enum.TryParse(stringValue, out T value) ? value : throw new ArgumentException($"Unknown value \"{stringValue}\"", argumentName));

    public override bool Execute()
    {
        using TaskTarget target = new("Task", Log);

        Generator.Execute(target, this);

        return true;
    }

    GeneratedAccessModifiers IRawSettings.GeneratedAccessModifiers => GetEnum<GeneratedAccessModifiers>(nameof(GeneratedAccessModifiers), GeneratedAccessModifiers);

    GeneratedPages IRawSettings.GeneratedPages => GetEnum<GeneratedPages>(nameof(GeneratedPages), GeneratedPages);

    IEnumerable<string> IRawSettings.ExternLinksFilePaths => (ExternLinksFilePaths ?? string.Empty).Split(_separators, StringSplitOptions.RemoveEmptyEntries);

    IEnumerable<string> IRawSettings.Plugins => (Plugins ?? string.Empty).Split(_separators, StringSplitOptions.RemoveEmptyEntries);

    IEnumerable<string> IRawSettings.UrlFactories => (UrlFactories ?? string.Empty).Split(_separators, StringSplitOptions.RemoveEmptyEntries);

    IEnumerable<string> IRawSettings.Sections => (Sections ?? string.Empty).Split(_separators, StringSplitOptions.RemoveEmptyEntries);

    IEnumerable<string> IRawSettings.Elements => (Elements ?? string.Empty).Split(_separators, StringSplitOptions.RemoveEmptyEntries);
}
