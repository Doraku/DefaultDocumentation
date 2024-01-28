using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Internal;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    /// <summary>
    /// Base implementation of the <see cref="IFileNameFactory"/> to generate file with a <c>.md</c> extension.
    /// It will also replace invalid char that may be present with the <see href="https://github.com/Doraku/DefaultDocumentation#invalidcharreplacement">Markdown.InvalidCharReplacement</see> setting.
    /// </summary>
    public abstract class BaseMarkdownFileNameFactory : IFileNameFactory
    {
        /// <inheritdoc/>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the file name to use for the given <see cref="DocItem"/>.
        /// </summary>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
        /// <param name="item">The <see cref="DocItem"/> for which to get the documentation file name.</param>
        /// <returns>The file name to use.</returns>
        protected abstract string GetMarkdownFileName(IGeneralContext context, DocItem item);

        /// <inheritdoc/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1851:Possible multiple enumerations of 'IEnumerable' collection", Justification = "Exepected")]
        public void Clean(IGeneralContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Settings.Logger.Debug($"Cleaning output folder \"{context.Settings.OutputDirectory}\"");

            if (context.Settings.OutputDirectory.Exists)
            {
                IEnumerable<FileInfo> files = context.Settings.OutputDirectory.EnumerateFiles("*.md").Where(f => !string.Equals(f.Name, "readme.md", StringComparison.OrdinalIgnoreCase));

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
        public string GetFileName(IGeneralContext context, DocItem item) => PathCleaner.Clean(item is AssemblyDocItem ? item.FullName : GetMarkdownFileName(context, item), context.GetInvalidCharReplacement()) + ".md";
    }
}
