using System;
using System.Xml.Linq;
using DefaultDocumentation.Model;

namespace DefaultDocumentation.Writers
{
    public static class IWriterExtensions
    {
        public static IContext GetContext(this IWriter writer, DocItem item) => writer.Context.GetContext(item) ?? writer.Context;

        public static IWriter Append(this IWriter writer, XElement value)
        {
            static void AppendMultiline(IWriter writer, string text, ref int? textStartIndex, ref bool startingNewLine)
            {
                string[] lines = text.Split('\n');
                int currentLine = 0;

                if (textStartIndex is null && startingNewLine)
                {
                    for (currentLine = 0; currentLine <= lines.Length; ++currentLine)
                    {
                        string line = lines[currentLine];
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            textStartIndex = line.Length - line.TrimStart().Length;
                            break;
                        }
                    }
                }

                for (; currentLine < lines.Length; ++currentLine)
                {
                    string line = lines[currentLine];
                    if (startingNewLine)
                    {
                        line = line.Substring(Math.Min(line.Length, textStartIndex ?? 0), Math.Max(0, line.Length - (textStartIndex ?? 0)));
                    }

                    writer.Append(line);

                    startingNewLine = currentLine < lines.Length - 1;
                    if (startingNewLine)
                    {
                        writer.AppendLine();
                    }
                }
            }

            if (value != null)
            {
                int? textStartIndex = default;
                bool startingNewLine = true;

                foreach (XNode node in value.Nodes())
                {
                    switch (node)
                    {
                        case XText text:
                            AppendMultiline(writer, text.Value, ref textStartIndex, ref startingNewLine);
                            break;

                        case XElement element when writer.Context.Elements.TryGetValue(element.Name.ToString(), out IElementWriter elementWriter):
                            elementWriter.Write(writer, element);
                            break;

                        case XElement element:
                            AppendMultiline(writer, element.ToString(), ref textStartIndex, ref startingNewLine);
                            break;
                    }
                    if (node is XElement)
                    {
                        startingNewLine = false;
                    }
                }
            }

            return writer;
        }

        public static IWriter AppendLine(this IWriter writer, string value) => writer.Append(value).AppendLine();

        public static IWriter TrimEnd(this IWriter writer, params string[] values)
        {
        Start:
            foreach (string value in values)
            {
                if (!string.IsNullOrEmpty(value) && writer.EndsWith(value))
                {
                    writer.Length -= value.Length;
                    goto Start;
                }
            }

            return writer;
        }
    }
}
