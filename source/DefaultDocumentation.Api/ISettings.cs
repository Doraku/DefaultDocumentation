using System.Collections.Generic;
using System.IO;
using NLog;

namespace DefaultDocumentation
{
    public interface ISettings
    {
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
    }
}
