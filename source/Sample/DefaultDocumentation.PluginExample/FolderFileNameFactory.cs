using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.PluginExample;

public sealed class FolderFileNameFactory : IFileNameFactory
{
    #region Markdown members not yet available in nuget

    private const string _invalidCharReplacementKey = "Markdown.InvalidCharReplacement";

    private static string? GetInvalidCharReplacement(IGeneralContext context)
    {
        context.ThrowIfNull();

        return context.GetSetting<string>(_invalidCharReplacementKey);
    }

    private static class PathCleaner
    {
        private static readonly string[] _toTrimChars = new[] { '=', ' ' }.Select(@char => $"{@char}").ToArray();
        private static readonly string[] _invalidChars = new[] { '\"', '<', '>', ':', '*', '?' }.Concat(Path.GetInvalidPathChars()).Select(@char => $"{@char}").ToArray();

        public static string Clean(string value, string? invalidCharReplacement)
        {
            foreach (string toTrimChar in _toTrimChars)
            {
                value = value.Replace(toTrimChar, string.Empty);
            }

            invalidCharReplacement = string.IsNullOrEmpty(invalidCharReplacement) ? "_" : invalidCharReplacement;

            foreach (string invalidChar in _invalidChars)
            {
                value = value.Replace(invalidChar, invalidCharReplacement);
            }

            return value.Trim('/');
        }
    }

    #endregion

    public string Name => "Folder";

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1851:Possible multiple enumerations of 'IEnumerable' collection", Justification = "expected")]
    public void Clean(IGeneralContext context)
    {
        context.ThrowIfNull();

        context.Settings.Logger.Debug($"Cleaning output folder \"{context.Settings.OutputDirectory}\"");

        if (context.Settings.OutputDirectory.Exists)
        {
            IEnumerable<FileInfo> files = context.Settings.OutputDirectory.EnumerateFiles("*.md", SearchOption.AllDirectories).Where(file => !string.Equals(file.Name, "readme.md", StringComparison.OrdinalIgnoreCase));

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
        context.ThrowIfNull();
        item.ThrowIfNull();

        return PathCleaner.Clean(item is AssemblyDocItem ? item.FullName : string.Join("/", item.GetParents().Skip(1).Select(parent => parent.Name).Concat(Enumerable.Repeat(item.Name, 1))), GetInvalidCharReplacement(context)) + ".md";
    }
}
