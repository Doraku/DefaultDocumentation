using System.Xml.Linq;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class RemarksWriter : ISectionWriter
    {
        public string Name => "remarks";

        public void Write(IWriter writer)
        {
            XElement remarks = writer.CurrentItem.Documentation.GetRemarks();

            if (remarks != null)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine()
                    .AppendLine("### Remarks")
                    .AppendAsMarkdown(remarks);
            }
        }
    }
}
