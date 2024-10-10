using System;
using System.Xml.Linq;

namespace DefaultDocumentation.Api;

/// <summary>
/// Provides extension methods on the <see cref="IWriter"/> type.
/// </summary>
public static class IWriterExtensions
{
    /// <summary>
    /// Appends an <see cref="XElement"/> to a <see cref="IWriter"/> by using the <see cref="IGeneralContext.Elements"/> of <see cref="IWriter.Context"/>.
    /// If no <see cref="IElement"/> is found, the <see cref="XElement"/> is appended as text directly.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to append to.</param>
    /// <param name="value">The <see cref="XElement"/> to append.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter Append(this IWriter writer, XElement? value)
    {
        writer.ThrowIfNull();

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

                    case XElement element when writer.Context.Elements.TryGetValue(element.Name.ToString(), out IElement elementWriter):
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

    /// <summary>
    /// Appends a line after writing the provided <see cref="string"/>.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to append to.</param>
    /// <param name="value">The <see cref="string"/> to append before the line.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter AppendLine(this IWriter writer, string value)
    {
        writer.ThrowIfNull();
        value.ThrowIfNull();

        return writer.Append(value).AppendLine();
    }

    /// <summary>
    /// Trims from the end of a <see cref="IWriter"/> all the provided values.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> to trim.</param>
    /// <param name="values">The <see cref="string"/> values to trim from the end.</param>
    /// <returns>The given <see cref="IWriter"/>.</returns>
    public static IWriter TrimEnd(this IWriter writer, params string[] values)
    {
        writer.ThrowIfNull();
        values.ThrowIfNull();

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
