using System.Xml.Linq;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParaWriter : IElementWriter
    {
        public string Name => "para";

        public void Write(IWriter writer, XElement element)
        {
            writer
                .EnsureLineStart()
                .AppendLine()
                .AppendAsMarkdown(element);
        }
    }
}
