using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class RemarksSection : ISection
    {
        public string Name => "remarks";

        public void Write(IWriter writer)
        {
            XElement remarks = writer.GetCurrentItem().Documentation?.Element(Name);

            if (remarks != null)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .AppendLine("### Remarks")
                    .AppendAsMarkdown(remarks);
            }
        }
    }
}
