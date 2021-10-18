using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Writer.Section
{
    internal sealed class RemarksWriter : SectionWriter
    {
        public RemarksWriter()
            : base("remarks")
        { }

        public override void Write(PageWriter writer)
        {
            XElement example = writer.CurrentItem.Documentation.GetRemarks();

            if (example != null)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("### Remarks")
                    .Append(example)
                    .AppendLine();
            }
        }
    }
}
