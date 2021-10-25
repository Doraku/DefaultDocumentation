using System;
using System.Globalization;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ListElement : IElementWriter
    {
        private static readonly XName nameList = XName.Get("list");
        private void WriteBullet(IWriter writer, XElement element)
        {
            foreach (XElement item in element.Elements())
            {
                IWriter listWriter =
                    writer
                        .EnsureLineStart()
                        .ToPrefixedWriter("  ");

                // Include sub-lists
                if (item.Name == nameList)
                {
                    Write(listWriter, item);
                }
                // Kind of a forgiving condition, but this also includes "listheader" I guess
                else
                {
                    writer.Append("- ");
                    WriteItem(listWriter, item);
                }
            }
        }

        private void WriteNumber(IWriter writer, XElement element)
        {
            int count = 1;

            foreach (XElement item in element.Elements())
            {
                IWriter listWriter =
                    writer
                        .EnsureLineStart()
                        .ToPrefixedWriter("   ");

                // Include sub-lists
                if (item.Name == nameList)
                {
                    Write(listWriter, item);
                }
                // Kind of a forgiving condition, but this also includes "listheader" I guess
                else
                {
                    writer.Append(count++.ToString(CultureInfo.InvariantCulture)).Append(". ");
                    WriteItem(listWriter, item);
                }
            }
        }

        private void WriteItem(IWriter writer, XElement element)
        {
            XElement term = element.GetTerm(),
                     description = element.GetDescription();

            // If both a term and a description are present, seperate them by an em dash 
            if (term is not null && description is not null)
            {
                writer
                    .AppendAsMarkdown(term)
                    .Append(" — ")
                    .AppendAsMarkdown(description);
            }
            // Otherwise, write one of the present items or the parent
            else
            {
                writer.AppendAsMarkdown(description ?? term ?? element);
            }
        }

        private void WriteTable(IWriter writer, XElement element)
        {
            int columnCount = 0;

            writer
                .EnsureLineStart()
                .Append("|");

            // Both include descriptions and terms
            foreach (XElement description in element.GetListHeader().Elements())
            {
                ++columnCount;

                writer
                    .SetDisplayAsSingleLine(true)
                    .AppendAsMarkdown(description)
                    .SetDisplayAsSingleLine(false)
                    .Append("|");
            }

            if (columnCount > 0)
            {
                writer
                    .EnsureLineStart()
                    .Append("|");

                while (columnCount-- > 0)
                {
                    writer.Append("-|");
                }

                foreach (XElement item in element.GetItems())
                {
                    writer
                        .EnsureLineStart()
                        .Append("|");

                    // Both include descriptions and terms
                    foreach (XElement description in item.Elements())
                    {
                        writer
                            .SetDisplayAsSingleLine(true)
                            .AppendAsMarkdown(description)
                            .SetDisplayAsSingleLine(false)
                            .Append("|");
                    }
                }
            }
        }

        public string Name => "list";

        public void Write(IWriter writer, XElement element)
        {
            if (writer.GetDisplayAsSingleLine())
            {
                return;
            }

            switch (element.GetTypeAttribute())
            {
                case "bullet":
                    WriteBullet(writer, element);
                    break;

                case "number":
                    WriteNumber(writer, element);
                    break;

                case "table":
                    WriteTable(writer, element);
                    break;
            }
        }
    }
}
