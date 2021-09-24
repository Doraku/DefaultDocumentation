using System;
using Microsoft.Build.Framework;

namespace DefaultDocumentation
{
    public sealed class DefaultDocumentationTask : Microsoft.Build.Utilities.Task
    {
        public string LogLevel { get; set; }

        [Required]
        public string AssemblyFilePath { get; set; }

        public string DocumentationFilePath { get; set; }

        public string ProjectDirectoryPath { get; set; }

        public string OutputDirectoryPath { get; set; }

        public string InvalidCharReplacement { get; set; }

        public string AssemblyPageName { get; set; }

        public string FileNameMode { get; set; }

        public bool RemoveFileExtensionFromLinks { get; set; }

        public string NestedTypeVisibilities { get; set; }

        public string GeneratedPages { get; set; }

        public string GeneratedAccessModifiers { get; set; }

        public bool IncludeUndocumentedItems { get; set; }

        public bool IgnoreLineBreak { get; set; }

        public string LinksOutputFilePath { get; set; }

        public string LinksBaseUrl { get; set; }

        public string ExternLinksFilePaths { get; set; }

        public override bool Execute()
        {
            static T GetEnum<T>(string argumentName, string stringValue) where T : struct =>
                string.IsNullOrEmpty(stringValue)
                ? default
                : (Enum.TryParse(stringValue, out T value) ? value : throw new ArgumentException($"Unknown value \"{stringValue}\"", argumentName));

            Generator.Execute(new Settings(
                new TaskTarget("Task", Log),
                LogLevel,
                AssemblyFilePath,
                DocumentationFilePath,
                ProjectDirectoryPath,
                OutputDirectoryPath,
                AssemblyPageName,
                InvalidCharReplacement,
                GetEnum<FileNameMode>(nameof(FileNameMode), FileNameMode),
                RemoveFileExtensionFromLinks,
                GetEnum<NestedTypeVisibilities>(nameof(NestedTypeVisibilities), NestedTypeVisibilities),
                GetEnum<GeneratedPages>(nameof(GeneratedPages), GeneratedPages),
                GetEnum<GeneratedAccessModifiers>(nameof(GeneratedAccessModifiers), GeneratedAccessModifiers),
                IncludeUndocumentedItems,
                IgnoreLineBreak,
                LinksOutputFilePath,
                LinksBaseUrl,
                (ExternLinksFilePaths ?? string.Empty).Split('|')));

            return true;
        }
    }
}
