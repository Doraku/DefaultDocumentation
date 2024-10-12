using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write the <c>remarks</c> top level element.
/// </summary>
public sealed class RemarksSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "remarks";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        XElement? remarks = writer.GetCurrentItem().Documentation?.Element(Name);

        if (remarks != null)
        {
            writer
                .EnsureLineStartAndAppendLine()
                .AppendLine("### Remarks")
                .AppendAsMarkdown(remarks);
        }
    }
}
