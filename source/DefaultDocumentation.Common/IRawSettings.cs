using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace DefaultDocumentation;

public interface IRawSettings
{
    LogLevel? LogLevel { get; }

    string ConfigurationFilePath { get; }

    string AssemblyFilePath { get; }

    string DocumentationFilePath { get; }

    string ProjectDirectoryPath { get; }

    string OutputDirectoryPath { get; }

    string AssemblyPageName { get; }

    GeneratedAccessModifiers GeneratedAccessModifiers { get; }

    bool IncludeUndocumentedItems { get; }

    GeneratedPages GeneratedPages { get; }

    string LinksOutputFilePath { get; }

    string LinksBaseUrl { get; }

    IEnumerable<string> ExternLinksFilePaths { get; }

    IEnumerable<string> Plugins { get; }

    IEnumerable<string> DocItemGenerators { get; }

    string FileNameFactory { get; }

    IEnumerable<string> UrlFactories { get; }

    IEnumerable<string> Sections { get; }

    IEnumerable<string> Elements { get; }
}
