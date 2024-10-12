using DefaultDocumentation.Api;
using DefaultDocumentation.Models.Members;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write the field type of <see cref="FieldDocItem"/>.
/// </summary>
public sealed class FieldValueSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "FieldValue";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        if (writer.GetCurrentItem() is FieldDocItem fieldItem)
        {
            writer
                .EnsureLineStartAndAppendLine()
                .AppendLine("#### Field Value")
                .AppendLink(fieldItem, fieldItem.Field.Type);
        }
    }
}
