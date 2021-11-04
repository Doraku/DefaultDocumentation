using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SummarySection : ISectionWriter
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
