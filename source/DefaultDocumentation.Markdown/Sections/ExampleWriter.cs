using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExampleWriter : SectionWriter
    {
        public ExampleWriter()
            : base("example")
        { }

        public override void Write(PageWriter writer)
        {
            XElement example = writer.CurrentItem.Documentation.GetExample();

            if (example != null)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("### Example")
                    .Append(example)
                    .AppendLine();
            }
        }
    }
}
