using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExampleWriter : ISectionWriter
    {
        public string Name => "example";

        public void Write(PageWriter writer)
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
