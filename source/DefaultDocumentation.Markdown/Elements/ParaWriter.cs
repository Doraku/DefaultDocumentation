using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParaWriter : IElementWriter
    {
        public string Name => "para";

        public void Write(PageWriter writer, XElement element)
        {
            writer
                .EnsureLineStart()
                .AppendLine()
                .Append(element)
                .EnsureLineStart()
                .AppendLine();
        }
    }
}
