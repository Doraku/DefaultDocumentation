using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class RemarksWriter : ISectionWriter
    {
        public string Name => "remarks";

        public void Write(PageWriter writer)
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
