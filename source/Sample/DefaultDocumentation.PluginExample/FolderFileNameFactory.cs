using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.PluginExample
{
    public sealed class FolderFileNameFactory : IFileNameFactory
    {
        #region Markdown members not yet available in nuget

        private const string InvalidCharReplacementKey = "Markdown.InvalidCharReplacement";

        public static string GetInvalidCharReplacement(IGeneralContext context) => context.GetSetting<string>(InvalidCharReplacementKey);

        private static class PathCleaner
        {
            private static readonly string[] toTrimChars = new[] { '=', ' ' }.Select(c => $"{c}").ToArray();
            private static readonly string[] invalidChars = new[] { '\"', '<', '>', ':', '*', '?' }.Concat(Path.GetInvalidPathChars()).Select(c => $"{c}").ToArray();

            public static string Clean(string value, string invalidCharReplacement)
            {
                foreach (string toTrimChar in toTrimChars)
                {
                    value = value.Replace(toTrimChar, string.Empty);
                }

                invalidCharReplacement = string.IsNullOrEmpty(invalidCharReplacement) ? "_" : invalidCharReplacement;

                foreach (string invalidChar in invalidChars)
                {
                    value = value.Replace(invalidChar, invalidCharReplacement);
                }

                return value.Trim('/');
            }
        }

        #endregion

        public string Name => "Folder";

        public void Clean(IGeneralContext context)
        {
            context.Settings.Logger.Debug($"Cleaning output folder \"{context.Settings.OutputDirectory}\"");

            if (context.Settings.OutputDirectory.Exists)
            {
                IEnumerable<FileInfo> files = context.Settings.OutputDirectory.EnumerateFiles("*.md", SearchOption.AllDirectories).Where(f => !string.Equals(f.Name, "readme.md", StringComparison.OrdinalIgnoreCase));

                int i;

                foreach (FileInfo file in files)
                {
                    i = 3;
                start:
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                        if (--i > 0)
                        {
                            Thread.Sleep(100);
                            goto start;
                        }

                        throw;
                    }
                }

                i = 3;
                while (files.Any() && i-- > 0)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public string GetFileName(IGeneralContext context, DocItem item)
        {
            return PathCleaner.Clean(item is AssemblyDocItem ? item.FullName : string.Join("/", item.GetParents().Skip(1).Select(p => p.Name).Concat(Enumerable.Repeat(item.Name, 1))), GetInvalidCharReplacement(context)) + ".md";
        }
    }
}
