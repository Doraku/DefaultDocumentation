using System.Globalization;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ListElement : IElementWriter
    {
        private static void WriteBullet(IWriter writer, XElement element)
        {
            foreach (XElement item in element.GetItems())
            {
                writer
                    .EnsureLineStart()
                    .Append("- ")
                    .ToPrefixedWriter("  ")
                    .AppendAsMarkdown(item);
            }
        }

        private static void WriteNumber(IWriter writer, XElement element)
        {
            int count = 1;

            foreach (XElement item in element.GetItems())
            {
                writer
                    .EnsureLineStart()
                    .Append(count++.ToString(CultureInfo.InvariantCulture))
                    .Append(". ")
                    .ToPrefixedWriter("  ")
                    .AppendAsMarkdown(item);
            }
        }

        private static void WriteTable(IWriter writer, XElement element)
        {
            int columnCount = 0;

            writer
                .EnsureLineStart()
                .Append("|");

            foreach (XElement description in element.GetListHeader().GetDescriptions())
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

                    foreach (XElement description in item.GetDescriptions())
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
            switch (element.GetTypeAttribute())
            {
                case "bullet" when !writer.GetDisplayAsSingleLine():
                    WriteBullet(writer, element);
                    break;

                case "number" when !writer.GetDisplayAsSingleLine():
                    WriteNumber(writer, element);
                    break;

                case "table" when !writer.GetDisplayAsSingleLine():
                    WriteTable(writer, element);
                    break;

                default:
                    writer.Append(element);
                    break;
            }
        }
    }
}
