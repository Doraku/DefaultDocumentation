using System.Xml.Linq;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExampleWriter : ISectionWriter
    {
        public string Name => "example";

        public void Write(IWriter writer)
        {
            XElement example = writer.CurrentItem.Documentation?.Element(Name);

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
