using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models.Members;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write the <c>value</c> top level element.
/// </summary>
public sealed class ValueSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "value";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        if (writer.GetCurrentItem() is PropertyDocItem propertyItem)
        {
            writer
                .EnsureLineStartAndAppendLine()
                .AppendLine("#### Property Value")
                .AppendLink(propertyItem, propertyItem.Property.ReturnType)
                .AppendLine("  ")
                .AppendAsMarkdown(propertyItem.Documentation?.Element(Name));
        }
    }
}
