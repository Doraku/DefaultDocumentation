using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class CWriter : IElementWriter
    {
        public string Name => "c";

        public void Write(PageWriter writer, XElement element)
        {
            writer
                .Append("`")
                .Append(element.Value)
                .Append("`");
        }
    }
}
