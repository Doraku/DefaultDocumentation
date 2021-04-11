using System;
using System.IO;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation
{
    public sealed class Settings
    {
        private const NestedTypeVisibility _defaultNestedTypeVisibility = NestedTypeVisibility.Namespace;
        private const GeneratedPage _defaultGeneratedPage = GeneratedPage.Namespaces | GeneratedPage.Types | GeneratedPage.Members;

        public FileInfo AssemblyFile { get; }

        public FileInfo DocumentationFile { get; }

        public DirectoryInfo ProjectDirectory { get; }

        public DirectoryInfo OutputDirectory { get; }

        public string HomeName { get; }

        public PathCleaner PathCleaner { get; }

        public FileNameMode FileNameMode { get; }

        public bool RemoveFileExtensionFromLinks { get; }

        public NestedTypeVisibility NestedTypeVisibility { get; }

        public GeneratedPage GeneratedPages { get; }

        public Settings(
            string assemblyFilePath,
            string documentationFilePath,
            string projectDirectoryPath,
            string outputDirectoryPath,
            string homeName,
            string invalidCharReplacement,
            FileNameMode fileNameMode,
            bool removeFileExtensionFromLinks,
            NestedTypeVisibility nestedTypeVisibility,
            GeneratedPage generatedPages)
        {
            AssemblyFile = !string.IsNullOrEmpty(assemblyFilePath) ? new FileInfo(assemblyFilePath) : throw new ArgumentNullException(nameof(assemblyFilePath));
            DocumentationFile = string.IsNullOrEmpty(documentationFilePath) ? new FileInfo(Path.Combine(AssemblyFile.Directory.FullName, Path.GetFileNameWithoutExtension(AssemblyFile.Name) + ".xml")) : new FileInfo(documentationFilePath);
            ProjectDirectory = string.IsNullOrEmpty(projectDirectoryPath) ? null : new DirectoryInfo(projectDirectoryPath);
            OutputDirectory = string.IsNullOrEmpty(outputDirectoryPath) ? DocumentationFile.Directory : new DirectoryInfo(outputDirectoryPath);

            HomeName = homeName;
            PathCleaner = new PathCleaner(string.IsNullOrEmpty(invalidCharReplacement) ? "_" : invalidCharReplacement);
            FileNameMode = fileNameMode;
            RemoveFileExtensionFromLinks = removeFileExtensionFromLinks;

            NestedTypeVisibility = nestedTypeVisibility == NestedTypeVisibility.Default ? _defaultNestedTypeVisibility : nestedTypeVisibility;
            GeneratedPages = generatedPages == GeneratedPage.Default ? _defaultGeneratedPage : generatedPages;
        }
    }
}
