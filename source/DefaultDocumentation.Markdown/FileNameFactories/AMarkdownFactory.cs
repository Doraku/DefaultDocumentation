using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using DefaultDocumentation.Model;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    public abstract class AMarkdownFactory : IFileNameFactory
    {
        public abstract string Name { get; }

        protected abstract string GetMarkdownFileName(DocumentationContext context, DocItem item);

        public void Clean(DocumentationContext context)
        {
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
            else
            {
                context.Settings.OutputDirectory.Create();
            }
        }

        public string GetFileName(DocumentationContext context, DocItem item) => (item is AssemblyDocItem ? item.FullName : GetMarkdownFileName(context, item)) + ".md";
    }
}
