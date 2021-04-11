using System;
using Microsoft.Build.Framework;

namespace DefaultDocumentation
{
    public sealed class DefaultDocumentationTask : Microsoft.Build.Utilities.Task
    {
        [Required]
        public string AssemblyFilePath { get; set; }

        public string DocumentationFilePath { get; set; }

        public string ProjectDirectoryPath { get; set; }

        public string OutputDirectoryPath { get; set; }

        public string InvalidCharReplacement { get; set; }

        public string HomeName { get; set; }

        public string FileNameMode { get; set; }

        public bool RemoveFileExtensionFromLinks { get; set; }

        public string NestedTypeVisibility { get; set; }

        public string GeneratedPages { get; set; }

        public override bool Execute()
        {
            static T GetEnum<T>(string argumentName, string stringValue) where T : struct =>
                string.IsNullOrEmpty(stringValue)
                ? default
                : (Enum.TryParse(stringValue, out T value) ? value : throw new ArgumentException($"Unknown value \"{stringValue}\"", argumentName));

            Generator.Execute(new Settings(
                AssemblyFilePath,
                DocumentationFilePath,
                ProjectDirectoryPath,
                OutputDirectoryPath,
                HomeName,
                InvalidCharReplacement,
                GetEnum<FileNameMode>(nameof(FileNameMode), FileNameMode),
                RemoveFileExtensionFromLinks,
                GetEnum<NestedTypeVisibility>(nameof(NestedTypeVisibility), NestedTypeVisibility),
                GetEnum<GeneratedPage>(nameof(GeneratedPages), GeneratedPages)));

            return true;
        }
    }
}
