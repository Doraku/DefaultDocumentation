using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace DefaultDocumentation
{
    public sealed class DefaultDocumentationTask : Microsoft.Build.Utilities.Task, ISettings
    {
        public string LogLevel { get; set; }

        public string ConfigurationFilePath { get; set; }

        [Required]
        public string AssemblyFilePath { get; set; }

        public string DocumentationFilePath { get; set; }

        public string ProjectDirectoryPath { get; set; }

        public string OutputDirectoryPath { get; set; }

        public string AssemblyPageName { get; set; }

        public string GeneratedAccessModifiers { get; set; }

        public bool IncludeUndocumentedItems { get; set; }

        public string GeneratedPages { get; set; }

        public string InvalidCharReplacement { get; set; }

        public bool RemoveFileExtensionFromLinks { get; set; }

        public string LinksOutputFilePath { get; set; }

        public string LinksBaseUrl { get; set; }

        public string ExternLinksFilePaths { get; set; }

        public string Plugins { get; set; }

        public string FileNameFactory { get; set; }

        public string Sections { get; set; }

        public string Elements { get; set; }

        public string NestedTypeVisibilities { get; set; }

        public bool IgnoreLineBreak { get; set; }

        private static T GetEnum<T>(string argumentName, string stringValue) where T : struct =>
            string.IsNullOrEmpty(stringValue)
            ? default
            : (Enum.TryParse(stringValue, out T value) ? value : throw new ArgumentException($"Unknown value \"{stringValue}\"", argumentName));

        public override bool Execute()
        {
            using TaskTarget target = new("Task", Log);

            Generator.Execute(target, this);

            return true;
        }

        GeneratedAccessModifiers ISettings.GeneratedAccessModifiers => GetEnum<GeneratedAccessModifiers>(nameof(GeneratedAccessModifiers), GeneratedAccessModifiers);

        GeneratedPages ISettings.GeneratedPages => GetEnum<GeneratedPages>(nameof(GeneratedPages), GeneratedPages);

        IEnumerable<string> ISettings.ExternLinksFilePaths => (ExternLinksFilePaths ?? string.Empty).Split('|');

        NestedTypeVisibilities ISettings.NestedTypeVisibilities => GetEnum<NestedTypeVisibilities>(nameof(NestedTypeVisibilities), NestedTypeVisibilities);

        IEnumerable<string> ISettings.Plugins => (Plugins ?? string.Empty).Split('|');

        IEnumerable<string> ISettings.Sections => (Sections ?? string.Empty).Split('|');

        IEnumerable<string> ISettings.Elements => (Elements ?? string.Empty).Split('|');
    }
}
