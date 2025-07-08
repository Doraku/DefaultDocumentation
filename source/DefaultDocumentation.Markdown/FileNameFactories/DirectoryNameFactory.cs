using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Internal;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Types;

using static DefaultDocumentation.Markdown.Internal.LoggerHelper;

namespace DefaultDocumentation.Markdown.FileNameFactories;

/// <summary>
/// <see cref="IFileNameFactory"/> implementation using <see cref="DocItem.Name"/> as file name in a directory hierarchy.
/// </summary>
public sealed class DirectoryNameFactory : IFileNameFactory
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "DirectoryName";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1851:Possible multiple enumerations of 'IEnumerable' collection", Justification = "exepected")]
    public void Clean(IGeneralContext context)
    {
        context.ThrowIfNull();

        LogCleaning(context.Settings.Logger, context.Settings.OutputDirectory);

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

    /// <inheritdoc/>
    public string GetFileName(IGeneralContext context, DocItem item)
    {
        context.ThrowIfNull();
        item.ThrowIfNull();

        static IEnumerable<string> GetParentsNames(DocItem item)
        {
            foreach (DocItem parent in item.GetParents().Skip(1))
            {
                if (parent is NamespaceDocItem)
                {
                    foreach (string @namespace in parent.Name.Split('.'))
                    {
                        yield return @namespace;
                    }
                }
                else
                {
                    yield return parent.Name;
                }
            }
        }

        static IEnumerable<string> GetNames(DocItem item)
        {
            if (item is AssemblyDocItem)
            {
                yield return item.FullName;
            }
            else if (item is NamespaceDocItem)
            {
                foreach (string @namespace in item.Name.Split('.'))
                {
                    yield return @namespace;
                }

                yield return "index";
            }
            else if (item is TypeDocItem)
            {
                yield return item.Name;
                yield return "index";
            }
            else
            {
                yield return item.Name;
            }
        }

        return PathCleaner.Clean(string.Join("/", GetParentsNames(item).Concat(GetNames(item))), context) + ".md";
    }
}
