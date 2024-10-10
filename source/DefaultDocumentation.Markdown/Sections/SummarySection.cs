using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write the <c>summary</c> top level element.
/// </summary>
public sealed class SummarySection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "summary";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        writer
            .EnsureLineStartAndAppendLine()
            .AppendAsMarkdown(writer.GetCurrentItem() switch
            {
                TypeParameterDocItem item => item.Documentation,
                ParameterDocItem item => item.Documentation,
                DocItem item => item.Documentation?.Element(Name)
            });
    }
}
