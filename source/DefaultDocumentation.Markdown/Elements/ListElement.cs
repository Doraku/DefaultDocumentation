using System;
using System.Globalization;
using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Elements;

/// <summary>
/// Handles <c>list</c> xml element.
/// </summary>
public sealed class ListElement : IElement
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "list";

    private static void WriteItem(IWriter writer, XElement element)
    {
        XElement? term = element.GetTerm();
        XElement? description = element.GetDescription();

        if (term is not null && description is not null)
        {
            writer
                .AppendAsMarkdown(term)
                .Append(" — ")
                .AppendAsMarkdown(description);
        }
        else
        {
            writer.AppendAsMarkdown(description ?? term ?? element);
        }
    }

    private static void WriteBullet(IWriter writer, XElement element)
    {
        foreach (XElement item in element.GetItems())
        {
            WriteItem(
                writer
                    .EnsureLineStart()
                    .Append("- ")
                    .ToPrefixedWriter("  "),
                item);
        }
    }

    private static void WriteNumber(IWriter writer, XElement element)
    {
        int count = 1;

        foreach (XElement item in element.GetItems())
        {
            WriteItem(
                writer
                    .EnsureLineStart()
                    .Append(count++.ToString(CultureInfo.InvariantCulture))
                    .Append(". ")
                    .ToPrefixedWriter("  "),
                item);
        }
    }

    private static void WriteTable(IWriter writer, XElement element)
    {
        int columnCount = 0;

        writer
            .EnsureLineStartAndAppendLine()
            .Append("|");

        foreach (XElement description in element.GetListHeader()?.GetTerms() ?? [])
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

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer, XElement element)
    {
        writer.ThrowIfNull();
        element.ThrowIfNull();

        if (writer.GetDisplayAsSingleLine())
        {
            return;
        }

        using (writer.AppendAsRaw())
        {
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

            writer.EnsureLineStart();
        }
    }
}
