using System;
using System.Globalization;
using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ListWriter : ElementWriter
    {
        public ListWriter()
            : base("list")
        { }

        private static void WriteBullet(PageWriter writer, XElement element)
        {
            foreach (XElement item in element.GetItems())
            {
                writer
                    .EnsureLineStart()
                    .Append("- ");

                using IDisposable _ = writer.AddLinePrefix("  ");

                writer.Append(item);
            }

            writer.AppendLine();
        }

        private static void WriteNumber(PageWriter writer, XElement element)
        {
            int count = 1;

            foreach (XElement item in element.GetItems())
            {
                writer
                    .EnsureLineStart()
                    .Append(count++.ToString(CultureInfo.InvariantCulture))
                    .Append(". ");

                using IDisposable _ = writer.AddLinePrefix("  ");

                writer.Append(item);
            }

            writer.AppendLine();
        }

        private static void WriteTable(PageWriter writer, XElement element)
        {
            int columnCount = 0;

            foreach (XElement description in element.GetListHeader().GetDescriptions())
            {
                ++columnCount;

                writer
                    .EnsureLineStart()
                    .Append("|");

                using IDisposable _ = writer.ChangeDisplayAsSingleLine(true);

                writer.Append(description);
            }

            if (columnCount > 0)
            {
                writer.AppendLine("|");

                while (columnCount-- > 0)
                {
                    writer.Append("|-");
                }
                writer.AppendLine("|");

                foreach (XElement item in element.GetItems())
                {
                    foreach (XElement description in item.GetDescriptions())
                    {
                        writer.Append("|");

                        using IDisposable _ = writer.ChangeDisplayAsSingleLine(true);

                        writer.Append(description);
                    }
                    writer.AppendLine("|");
                }

                writer.AppendLine();
            }
        }

        public override void Write(PageWriter writer, XElement element)
        {
            switch (element.GetTypeAttribute())
            {
                case "bullet" when !writer.DisplayAsSingleLine:
                    WriteBullet(writer, element);
                    break;

                case "number" when !writer.DisplayAsSingleLine:
                    WriteNumber(writer, element);
                    break;

                case "table" when !writer.DisplayAsSingleLine:
                    WriteTable(writer, element);
                    break;

                default:
                    writer.AppendMultiline(element.ToString());
                    break;
            }
        }
    }
}
