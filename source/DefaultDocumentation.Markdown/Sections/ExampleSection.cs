using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExampleSection : ISection
    {
        public string Name => "example";

        public void Write(IWriter writer)
        {
            XElement example = writer.GetCurrentItem().Documentation?.Element(Name);

            if (example != null)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .AppendLine("### Example")
                    .AppendAsMarkdown(example);
            }
        }
    }
}
