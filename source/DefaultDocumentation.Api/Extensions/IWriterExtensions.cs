using System;
using System.Linq;
using System.Xml.Linq;

namespace DefaultDocumentation.Writers
{
    public static class IWriterExtensions
    {
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

                        case XElement element when writer.Context.ElementWriters.TryGetValue(element.Name.ToString(), out IElementWriter elementWriter):
                            elementWriter.Write(writer, element);
                            break;

                        case XElement element:
                            AppendMultiline(writer, element.ToString(), ref textStartIndex, ref startingNewLine);
                            break;

                        default:
                            throw new Exception($"unhandled node type {node.NodeType}");
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

        public static bool EndsWith(this IWriter writer, params string[] values) => values.Any(writer.EndsWith);

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
