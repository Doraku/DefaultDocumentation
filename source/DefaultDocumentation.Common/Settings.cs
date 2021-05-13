using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation
{
    public sealed class Settings
    {
        private const NestedTypeVisibilities _defaultNestedTypeVisibility = NestedTypeVisibilities.Namespace;
        private const GeneratedPages _defaultGeneratedPage = GeneratedPages.Namespaces | GeneratedPages.Types | GeneratedPages.Members;

        private static readonly char[] _patternChars = new[] { '*', '?' };
        private static readonly char[] _folderChars = new[] { '/', '\\' };

        public FileInfo AssemblyFile { get; }

        public FileInfo DocumentationFile { get; }

        public DirectoryInfo ProjectDirectory { get; }

        public DirectoryInfo OutputDirectory { get; }

        public string AssemblyPageName { get; }

        public PathCleaner PathCleaner { get; }

        public FileNameMode FileNameMode { get; }

        public bool RemoveFileExtensionFromLinks { get; }

        public NestedTypeVisibilities NestedTypeVisibilities { get; }

        public GeneratedPages GeneratedPages { get; }

        public FileInfo LinksOutputFile { get; }

        public string LinksBaseUrl { get; }

        public FileInfo[] ExternLinksFiles { get; }

        public Settings(
            string assemblyFilePath,
            string documentationFilePath,
            string projectDirectoryPath,
            string outputDirectoryPath,
            string assemblyPageName,
            string invalidCharReplacement,
            FileNameMode fileNameMode,
            bool removeFileExtensionFromLinks,
            NestedTypeVisibilities nestedTypeVisibilities,
            GeneratedPages generatedPages,
            string linksOutputFile,
            string linksBaseUrl,
            IEnumerable<string> externlinksFilePaths)
        {
            AssemblyFile = !string.IsNullOrEmpty(assemblyFilePath) ? new FileInfo(assemblyFilePath) : throw new ArgumentNullException(nameof(assemblyFilePath));
            DocumentationFile = string.IsNullOrEmpty(documentationFilePath) ? new FileInfo(Path.Combine(AssemblyFile.Directory.FullName, Path.GetFileNameWithoutExtension(AssemblyFile.Name) + ".xml")) : new FileInfo(documentationFilePath);
            ProjectDirectory = string.IsNullOrEmpty(projectDirectoryPath) ? null : new DirectoryInfo(projectDirectoryPath);
            OutputDirectory = string.IsNullOrEmpty(outputDirectoryPath) ? DocumentationFile.Directory : new DirectoryInfo(outputDirectoryPath);

            AssemblyPageName = assemblyPageName;
            PathCleaner = new PathCleaner(string.IsNullOrEmpty(invalidCharReplacement) ? "_" : invalidCharReplacement);
            FileNameMode = fileNameMode;
            RemoveFileExtensionFromLinks = removeFileExtensionFromLinks;

            NestedTypeVisibilities = nestedTypeVisibilities == NestedTypeVisibilities.Default ? _defaultNestedTypeVisibility : nestedTypeVisibilities;
            GeneratedPages = generatedPages == GeneratedPages.Default ? _defaultGeneratedPage : generatedPages;

            LinksOutputFile = string.IsNullOrEmpty(linksOutputFile) ? null : new FileInfo(linksOutputFile);
            LinksBaseUrl = linksBaseUrl ?? string.Empty;
            ExternLinksFiles = (externlinksFilePaths ?? Enumerable.Empty<string>()).SelectMany(GetFiles).Where(f => f.Exists && f.FullName != LinksOutputFile?.FullName).ToArray();
        }

        private static IEnumerable<FileInfo> GetFiles(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                yield break;
            }

            if (filePath.IndexOfAny(_patternChars) < 0)
            {
                yield return new FileInfo(filePath);
                yield break;
            }

            int folderIndex = filePath.LastIndexOfAny(_folderChars) + 1;

            foreach (string file in Directory.EnumerateFiles(filePath.Substring(0, folderIndex), filePath.Substring(folderIndex)))
            {
                yield return new FileInfo(file);
            }
        }
    }
}
