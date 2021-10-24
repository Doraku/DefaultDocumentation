using System.Xml.Linq;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExampleSection : ISectionWriter
    {
        public string Name => "example";

        public void Write(IWriter writer)
        {
            XElement example = writer.GetCurrentItem().Documentation?.Element(Name);

            if (example != null)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine()
                    .AppendLine("### Example")
                    .AppendAsMarkdown(example);
            }
        }
    }
}
