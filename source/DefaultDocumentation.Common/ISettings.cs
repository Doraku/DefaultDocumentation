using System.Collections.Generic;

namespace DefaultDocumentation
{
    public interface ISettings
    {
        public string LogLevel { get; }

        public string ConfigurationFilePath { get; }

        public string AssemblyFilePath { get; }

        public string DocumentationFilePath { get; }

        public string ProjectDirectoryPath { get; }

        public string OutputDirectoryPath { get; }

        public string AssemblyPageName { get; }

        public GeneratedAccessModifiers GeneratedAccessModifiers { get; }

        public bool IncludeUndocumentedItems { get; }

        public GeneratedPages GeneratedPages { get; }

        public string InvalidCharReplacement { get; }

        public bool RemoveFileExtensionFromLinks { get; }

        public string LinksOutputFilePath { get; }

        public string LinksBaseUrl { get; }

        public IEnumerable<string> ExternLinksFilePaths { get; }

        public IEnumerable<string> Plugins { get; }

        public string FileNameFactory { get; }

        public IEnumerable<string> Sections { get; }

        public IEnumerable<string> Elements { get; }

        public NestedTypeVisibilities NestedTypeVisibilities { get; }

        public bool IgnoreLineBreak { get; }
    }
}
