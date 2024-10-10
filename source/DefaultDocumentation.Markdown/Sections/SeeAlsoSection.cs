using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write the <c>seealso</c> top level elements.
/// </summary>
public sealed class SeeAlsoSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "seealso";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        writer.ThrowIfNull();

        bool titleWritten = false;

        foreach (XElement seeAlso in writer.GetCurrentItem().Documentation?.Elements(Name) ?? [])
        {
            if (!titleWritten)
            {
                titleWritten = true;
                writer
                    .EnsureLineStartAndAppendLine()
                    .Append("### See Also");
            }

            string? @ref = seeAlso.GetCRefAttribute();
            if (@ref is not null)
            {
                writer
                    .AppendLine()
                    .Append("- ")
                    .AppendLink(@ref, seeAlso.Value.NullIfEmpty());

                continue;
            }

            @ref = seeAlso.GetHRefAttribute();
            if (@ref is not null)
            {
                writer
                    .AppendLine()
                    .Append("- ")
                    .AppendUrl(@ref, seeAlso.Value.NullIfEmpty());
            }
        }
    }
}
