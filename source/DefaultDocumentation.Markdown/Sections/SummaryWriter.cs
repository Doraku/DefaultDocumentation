using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SummaryWriter : ISectionWriter
    {
        public string Name => "summary";

        public void Write(PageWriter writer)
        {
            writer
                .EnsureLineStart()
                .Append(writer.CurrentItem switch
                {
                    TypeParameterDocItem => writer.CurrentItem.Documentation,
                    ParameterDocItem => writer.CurrentItem.Documentation,
                    _ => writer.CurrentItem.Documentation.GetSummary()
                })
                .EnsureLineStart();
        }
    }
}
