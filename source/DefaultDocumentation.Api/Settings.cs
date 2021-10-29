using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace DefaultDocumentation
{
    public sealed class Settings
    {
        private const NestedTypeVisibilities _defaultNestedTypeVisibilities = NestedTypeVisibilities.Namespace;
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

        public string FileNameFactory { get; }

        public bool RemoveFileExtensionFromLinks { get; }

        public NestedTypeVisibilities NestedTypeVisibilities { get; }

        public GeneratedPages GeneratedPages { get; }

        public GeneratedAccessModifiers GeneratedAccessModifiers { get; }

        public bool IncludeUndocumentedItems { get; }

        public bool IgnoreLineBreak { get; }

        public FileInfo LinksOutputFile { get; }

        public string LinksBaseUrl { get; }

        public IEnumerable<FileInfo> ExternLinksFiles { get; }

        public JObject Configuration { get; }

        public Settings(
            Target loggerTarget,
            string logLevel,
            string assemblyFilePath,
            string documentationFilePath,
            string projectDirectoryPath,
            string outputDirectoryPath,
            string assemblyPageName,
            string invalidCharReplacement,
            string fileNameFactory,
            bool removeFileExtensionFromLinks,
            NestedTypeVisibilities nestedTypeVisibilities,
            GeneratedPages generatedPages,
            GeneratedAccessModifiers generatedAccessModifiers,
            bool includeUndocumentedItems,
            bool ignoreLineBreak,
            string linksOutputFile,
            string linksBaseUrl,
            IEnumerable<string> externlinksFilePaths)
        {
            if (loggerTarget != null)
            {
                LoggingConfiguration logConfiguration = new();
                logConfiguration.AddTarget(loggerTarget);
                logConfiguration.AddRule(LogLevel.FromString(string.IsNullOrEmpty(logLevel) ? nameof(LogLevel.Info) : logLevel), LogLevel.Fatal, loggerTarget);
                LogManager.Configuration = logConfiguration;
            }

            Logger = LogManager.GetLogger("DefaultDocumentation");

            Logger.Info("Starting DefaultDocumentation with those settings");

            Logger.Info($"{nameof(LogLevel)}: {logLevel}");

            AssemblyFile = !string.IsNullOrEmpty(assemblyFilePath) ? new FileInfo(assemblyFilePath) : throw new ArgumentNullException(nameof(assemblyFilePath));
            Logger.Info($"{nameof(AssemblyFile)}: {AssemblyFile.FullName}");

            DocumentationFile = string.IsNullOrEmpty(documentationFilePath) ? new FileInfo(Path.Combine(AssemblyFile.Directory.FullName, Path.GetFileNameWithoutExtension(AssemblyFile.Name) + ".xml")) : new FileInfo(documentationFilePath);
            Logger.Info($"{nameof(DocumentationFile)}: {DocumentationFile.FullName}");

            ProjectDirectory = string.IsNullOrEmpty(projectDirectoryPath) ? null : new DirectoryInfo(projectDirectoryPath);
            Logger.Info($"{nameof(ProjectDirectory)}: {ProjectDirectory?.FullName}");

            OutputDirectory = string.IsNullOrEmpty(outputDirectoryPath) ? DocumentationFile.Directory : new DirectoryInfo(outputDirectoryPath);
            Logger.Info($"{nameof(OutputDirectory)}: {OutputDirectory.FullName}");

            AssemblyPageName = assemblyPageName;
            Logger.Info($"{nameof(AssemblyPageName)}: {AssemblyPageName}");

            InvalidCharReplacement = string.IsNullOrEmpty(invalidCharReplacement) ? "_" : invalidCharReplacement;
            Logger.Info($"{nameof(InvalidCharReplacement)}: {InvalidCharReplacement}");

            FileNameFactory = string.IsNullOrEmpty(fileNameFactory) ? "FullName" : fileNameFactory;
            Logger.Info($"{nameof(FileNameFactory)}: {FileNameFactory}");

            RemoveFileExtensionFromLinks = removeFileExtensionFromLinks;
            Logger.Info($"{nameof(RemoveFileExtensionFromLinks)}: {RemoveFileExtensionFromLinks}");

            NestedTypeVisibilities = nestedTypeVisibilities == NestedTypeVisibilities.Default ? _defaultNestedTypeVisibilities : nestedTypeVisibilities;
            Logger.Info($"{nameof(NestedTypeVisibilities)}: {NestedTypeVisibilities}");

            GeneratedPages = generatedPages == GeneratedPages.Default ? _defaultGeneratedPages : generatedPages;
            Logger.Info($"{nameof(GeneratedPages)}: {GeneratedPages}");

            GeneratedAccessModifiers = generatedAccessModifiers == GeneratedAccessModifiers.Default ? _defaultGeneratedAccessModifiers : generatedAccessModifiers;
            Logger.Info($"{nameof(GeneratedAccessModifiers)}: {GeneratedAccessModifiers}");

            IncludeUndocumentedItems = includeUndocumentedItems;
            Logger.Info($"{nameof(IncludeUndocumentedItems)}: {IncludeUndocumentedItems}");

            IgnoreLineBreak = ignoreLineBreak;
            Logger.Info($"{nameof(IgnoreLineBreak)}: {IgnoreLineBreak}");

            LinksOutputFile = string.IsNullOrEmpty(linksOutputFile) ? null : new FileInfo(linksOutputFile);
            Logger.Info($"{nameof(LinksOutputFile)}: {LinksOutputFile?.FullName}");

            LinksBaseUrl = linksBaseUrl ?? string.Empty;
            Logger.Info($"{nameof(LinksBaseUrl)}: {LinksBaseUrl}");

            ExternLinksFiles = (externlinksFilePaths ?? Enumerable.Empty<string>()).SelectMany(GetFilePaths).Distinct().Select(f => new FileInfo(f)).Where(f => f.Exists && f.FullName != LinksOutputFile?.FullName).ToArray();
            Logger.Info($"{nameof(ExternLinksFiles)}:{string.Concat(ExternLinksFiles.Select(f => $"{Environment.NewLine}\t{f.FullName}"))}");
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
