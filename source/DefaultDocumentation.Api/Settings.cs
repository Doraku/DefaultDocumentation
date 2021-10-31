using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;

namespace DefaultDocumentation
{
    public sealed class Settings
    {
        private const GeneratedPages _defaultGeneratedPages = GeneratedPages.Namespaces | GeneratedPages.Types | GeneratedPages.Members;
        private const GeneratedAccessModifiers _defaultGeneratedAccessModifiers = GeneratedAccessModifiers.Public | GeneratedAccessModifiers.Private | GeneratedAccessModifiers.Protected | GeneratedAccessModifiers.Internal | GeneratedAccessModifiers.ProtectedInternal | GeneratedAccessModifiers.PrivateProtected;

        private static readonly char[] _patternChars = new[] { '*', '?' };
        private static readonly char[] _folderChars = new[] { '/', '\\' };

        public ILogger Logger { get; }

        public FileInfo AssemblyFile { get; }

        public FileInfo DocumentationFile { get; }

        public DirectoryInfo ProjectDirectory { get; }

        public DirectoryInfo OutputDirectory { get; }

        public string AssemblyPageName { get; }

        public string InvalidCharReplacement { get; }

        public bool RemoveFileExtensionFromLinks { get; }

        public GeneratedPages GeneratedPages { get; }

        public GeneratedAccessModifiers GeneratedAccessModifiers { get; }

        public bool IncludeUndocumentedItems { get; }

        public FileInfo LinksOutputFile { get; }

        public string LinksBaseUrl { get; }

        public IEnumerable<FileInfo> ExternLinksFiles { get; }

        public Settings(
            ILogger logger,
            string assemblyFilePath,
            string documentationFilePath,
            string projectDirectoryPath,
            string outputDirectoryPath,
            string assemblyPageName,
            GeneratedAccessModifiers generatedAccessModifiers,
            GeneratedPages generatedPages,
            bool includeUndocumentedItems,
            string invalidCharReplacement,
            bool removeFileExtensionFromLinks,
            string linksOutputFile,
            string linksBaseUrl,
            IEnumerable<string> externlinksFilePaths)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Logger.Info("Starting DefaultDocumentation with those settings:");

            AssemblyFile = !string.IsNullOrEmpty(assemblyFilePath) ? new FileInfo(assemblyFilePath) : throw new ArgumentNullException(nameof(assemblyFilePath));
            Logger.Info($"\t{nameof(AssemblyFile)}: {AssemblyFile.FullName}");

            DocumentationFile = string.IsNullOrEmpty(documentationFilePath) ? new FileInfo(Path.Combine(AssemblyFile.Directory.FullName, Path.GetFileNameWithoutExtension(AssemblyFile.Name) + ".xml")) : new FileInfo(documentationFilePath);
            Logger.Info($"\t{nameof(DocumentationFile)}: {DocumentationFile.FullName}");

            ProjectDirectory = string.IsNullOrEmpty(projectDirectoryPath) ? null : new DirectoryInfo(projectDirectoryPath);
            Logger.Info($"\t{nameof(ProjectDirectory)}: {ProjectDirectory?.FullName}");

            OutputDirectory = string.IsNullOrEmpty(outputDirectoryPath) ? DocumentationFile.Directory : new DirectoryInfo(outputDirectoryPath);
            Logger.Info($"\t{nameof(OutputDirectory)}: {OutputDirectory.FullName}");

            AssemblyPageName = assemblyPageName;
            Logger.Info($"\t{nameof(AssemblyPageName)}: {AssemblyPageName}");

            GeneratedAccessModifiers = generatedAccessModifiers == GeneratedAccessModifiers.Default ? _defaultGeneratedAccessModifiers : generatedAccessModifiers;
            Logger.Info($"\t{nameof(GeneratedAccessModifiers)}: {GeneratedAccessModifiers}");

            GeneratedPages = generatedPages == GeneratedPages.Default ? _defaultGeneratedPages : generatedPages;
            Logger.Info($"\t{nameof(GeneratedPages)}: {GeneratedPages}");

            IncludeUndocumentedItems = includeUndocumentedItems;
            Logger.Info($"\t{nameof(IncludeUndocumentedItems)}: {IncludeUndocumentedItems}");

            InvalidCharReplacement = string.IsNullOrEmpty(invalidCharReplacement) ? "_" : invalidCharReplacement;
            Logger.Info($"\t{nameof(InvalidCharReplacement)}: {InvalidCharReplacement}");

            RemoveFileExtensionFromLinks = removeFileExtensionFromLinks;
            Logger.Info($"\t{nameof(RemoveFileExtensionFromLinks)}: {RemoveFileExtensionFromLinks}");

            LinksOutputFile = string.IsNullOrEmpty(linksOutputFile) ? null : new FileInfo(linksOutputFile);
            Logger.Info($"\t{nameof(LinksOutputFile)}: {LinksOutputFile?.FullName}");

            LinksBaseUrl = linksBaseUrl ?? string.Empty;
            Logger.Info($"\t{nameof(LinksBaseUrl)}: {LinksBaseUrl}");

            ExternLinksFiles = (externlinksFilePaths ?? Enumerable.Empty<string>()).SelectMany(GetFilePaths).Distinct().Select(f => new FileInfo(f)).Where(f => f.Exists && f.FullName != LinksOutputFile?.FullName).ToArray();
            Logger.Info($"\t{nameof(ExternLinksFiles)}:{string.Concat(ExternLinksFiles.Select(f => $"{Environment.NewLine}\t{f.FullName}"))}");
        }

        private static IEnumerable<string> GetFilePaths(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                yield break;
            }

            if (filePath.IndexOfAny(_patternChars) < 0)
            {
                yield return filePath;
                yield break;
            }

            int folderIndex = filePath.LastIndexOfAny(_folderChars) + 1;

            foreach (string file in Directory.EnumerateFiles(filePath.Substring(0, folderIndex), filePath.Substring(folderIndex)))
            {
                yield return file;
            }
        }
    }
}
