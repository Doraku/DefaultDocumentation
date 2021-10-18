using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class RemarksWriter : SectionWriter
    {
        public RemarksWriter()
            : base("remarks")
        { }

        public override void Write(PageWriter writer)
        {
            XElement remarks = writer.CurrentItem.Documentation.GetRemarks();

            if (remarks != null)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("### Remarks")
                    .Append(remarks)
                    .AppendLine();
            }
        }
    }
}
