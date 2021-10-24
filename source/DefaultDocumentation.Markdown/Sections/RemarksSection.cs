using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class RemarksSection : ISectionWriter
    {
        public string Name => "remarks";

        public void Write(IWriter writer)
        {
            XElement remarks = writer.GetCurrentItem().Documentation?.Element(Name);

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
