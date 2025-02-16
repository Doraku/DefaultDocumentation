using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace DefaultDocumentation;

/// <summary>
/// Exposes all the settings of the documentation generation process.
/// </summary>
public interface ISettings
{
    /// <summary>
    /// Gets the <see cref="ILogger"/> of the process.
    /// </summary>
    ILogger Logger { get; }

    /// <summary>
    /// Gets the assembly file for which the documentation is being generated.
    /// </summary>
    FileInfo AssemblyFile { get; }

    /// <summary>
    /// Gets the xml documentation file of the <see cref="AssemblyFile"/>.
    /// </summary>
    FileInfo DocumentationFile { get; }

    /// <summary>
    /// Gets the root project directory where the sources of the <see cref="AssemblyFile"/> are.
    /// </summary>
    DirectoryInfo? ProjectDirectory { get; }

    /// <summary>
    /// Gets the output directory where the documentation is being generated.
    /// </summary>
    DirectoryInfo OutputDirectory { get; }

    /// <summary>
    /// Gets the name of the assembly page name.
    /// </summary>
    string? AssemblyPageName { get; }

    /// <summary>
    /// Gets the <see cref="DefaultDocumentation.GeneratedPages"/> flags stating which kind should have their own page and which should be inlined.
    /// </summary>
    GeneratedPages GeneratedPages { get; }

    /// <summary>
    /// Gets the <see cref="DefaultDocumentation.GeneratedAccessModifiers"/> flags stating which access modifiers should have their documentation generated.
    /// </summary>
    GeneratedAccessModifiers GeneratedAccessModifiers { get; }

    /// <summary>
    /// Gets wether item with no xml documentation should have their documentation generated or not.
    /// </summary>
    bool IncludeUndocumentedItems { get; }

    /// <summary>
    /// Gets the file name where all the url of the generated documentation should be writen to, to be used for referencing documentation generation.
    /// </summary>
    FileInfo? LinksOutputFile { get; }

    /// <summary>
    /// Gets the base url to prefix item url with when generating the links output file.
    /// </summary>
    string? LinksBaseUrl { get; }

    /// <summary>
    /// Gets the links files of external items which are not part of the dotnet api.
    /// </summary>
    IEnumerable<FileInfo> ExternLinksFiles { get; }
}
