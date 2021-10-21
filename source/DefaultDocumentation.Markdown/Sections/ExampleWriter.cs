using System.Xml.Linq;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExampleWriter : ISectionWriter
    {
        public string Name => "example";

        public void Write(IWriter writer)
        {
            XElement example = writer.CurrentItem.Documentation.GetExample();

            if (example != null)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("### Example")
                    .AppendAsMarkdown(example);
            }
        }
    }
}
