using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SummarySection : ISection
    {
        public string Name => "summary";

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
}
