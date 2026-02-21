using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write the <c>exception</c> top level elements.
/// </summary>
public sealed class ExceptionSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "exception";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        ArgumentNullException.ThrowIfNull(writer);

        bool titleWritten = false;

        foreach (XElement exception in writer.GetCurrentItem().Documentation?.Elements(Name) ?? [])
        {
            if (!titleWritten)
            {
                titleWritten = true;
                writer
                    .EnsureLineStartAndAppendLine()
                    .Append("#### Exceptions");
            }

            string? cref = exception.GetCRefAttribute();

            if (cref != null)
            {
                writer
                    .AppendLine()
                    .AppendLine()
                    .AppendLink(cref)
                    .AppendLine("  ")
                    .AppendAsMarkdown(exception);
            }
        }
    }
}
