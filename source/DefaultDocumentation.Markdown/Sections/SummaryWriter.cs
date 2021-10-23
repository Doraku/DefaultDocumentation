using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SummaryWriter : ISectionWriter
    {
        public string Name => "summary";

        public void Write(IWriter writer)
        {
            writer
                .EnsureLineStart()
                .AppendLine()
                .AppendAsMarkdown(writer.GetCurrentItem() switch
                {
                    TypeParameterDocItem item => item.Documentation,
                    ParameterDocItem item => item.Documentation,
                    DocItem item => item.Documentation?.Element(Name)
                });
        }
    }
}
