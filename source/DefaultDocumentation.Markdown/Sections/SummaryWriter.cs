using System.Xml.Linq;
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
                .AppendAsMarkdown(writer.CurrentItem switch
                {
                    TypeParameterDocItem => writer.CurrentItem.Documentation,
                    ParameterDocItem => writer.CurrentItem.Documentation,
                    _ => writer.CurrentItem.Documentation.GetSummary()
                });
        }
    }
}
