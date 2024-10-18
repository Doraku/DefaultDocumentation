using System.IO;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Internal.DocItemGenerators;

internal sealed class ExternDocItemReader : IDocItemGenerator
{
    public string Name => nameof(ExternDocItemReader);

    public void Generate(IDocItemsContext context)
    {
        foreach (FileInfo linksFile in context.Settings.ExternLinksFiles)
        {
            using StreamReader reader = linksFile.OpenText();

            string baseLink = string.Empty;
            while (!reader.EndOfStream)
            {
                string[] items = reader.ReadLine().Split(['|'], 3);

                switch (items.Length)
                {
                    case 1:
                        baseLink = items[0].Trim();
                        break;

                    case 2:
                        context.Add(new ExternDocItem(items[0].Trim(), baseLink + items[1].Trim(), null));
                        break;

                    case 3:
                        context.Add(new ExternDocItem(items[0].Trim(), baseLink + items[1].Trim(), items[2].Trim()));
                        break;
                }
            }
        }
    }
}
