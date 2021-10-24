using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DerivedSection : ISectionWriter
    {
        public string Name => "Derived";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is TypeDocItem typeItem)
            {
                List<TypeDocItem> derived = writer.Context.Items.OfType<TypeDocItem>().Where(i => i.Type.DirectBaseTypes.Select(t => t.GetDefinition() ?? t).Contains(typeItem.Type)).OrderBy(i => i.FullName).ToList();
                if (derived.Count > 0)
                {
                    writer
                        .EnsureLineStart()
                        .AppendLine()
                        .Append("Derived");

                    foreach (TypeDocItem t in derived)
                    {
                        writer
                            .AppendLine("  ")
                            .Append("&#8627; ")
                            .AppendLink(t);
                    }
                }
            }
        }
    }
}
