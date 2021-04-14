using System;
using System.IO;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation
{
    public sealed class Settings
    {
        private const NestedTypeVisibilities _defaultNestedTypeVisibility = NestedTypeVisibilities.Namespace;
        private const GeneratedPages _defaultGeneratedPage = GeneratedPages.Namespaces | GeneratedPages.Types | GeneratedPages.Members;

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
            GeneratedPages generatedPages)
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
        }
    }
}
