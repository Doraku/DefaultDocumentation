using System.Collections.Generic;
using System.IO;
using NLog;

namespace DefaultDocumentation
{
    /// <summary>
    /// Exposes all the settings of the documentation generation process.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Gets the <see cref="ILogger"/> of the process.
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>
        /// Gets the assembly file for which the documentation is being generated.
        /// </summary>
        public FileInfo AssemblyFile { get; }

        /// <summary>
        /// Gets the xml documentation file of the <see cref="AssemblyFile"/>.
        /// </summary>
        public FileInfo DocumentationFile { get; }

        /// <summary>
        /// Gets the root project directory where the sources of the <see cref="AssemblyFile"/> are.
        /// </summary>
        public DirectoryInfo? ProjectDirectory { get; }

        /// <summary>
        /// Gets the output directory where the documentation is being generated.
        /// </summary>
        public DirectoryInfo OutputDirectory { get; }

        /// <summary>
        /// Gets the name of the assembly page name.
        /// </summary>
        public string? AssemblyPageName { get; }

        /// <summary>
        /// Gets the <see cref="string"/> used to replace characters that are invalid for a path or a file name.
        /// </summary>
        public string InvalidCharReplacement { get; }

        /// <summary>
        /// Gets the <see cref="DefaultDocumentation.GeneratedPages"/> flags stating which kind should have their own page and which should be inlined.
        /// </summary>
        public GeneratedPages GeneratedPages { get; }

        /// <summary>
        /// Gets the <see cref="DefaultDocumentation.GeneratedAccessModifiers"/> flags stating which access modifiers should have their documentation generated.
        /// </summary>
        public GeneratedAccessModifiers GeneratedAccessModifiers { get; }

        /// <summary>
        /// Gets wether item with no xml documentation should have their documentation generated or not.
        /// </summary>
        public bool IncludeUndocumentedItems { get; }

        /// <summary>
        /// Gets the file name where all the url of the generated documentation should be writen to, to be used for referencing documentation generation.
        /// </summary>
        public FileInfo? LinksOutputFile { get; }

        /// <summary>
        /// Gets the base url to prefix item url with when generating the links output file.
        /// </summary>
        public string? LinksBaseUrl { get; }

        /// <summary>
        /// Gets the links files of external items which are not part of the dotnet api.
        /// </summary>
        public IEnumerable<FileInfo> ExternLinksFiles { get; }
    }
}
