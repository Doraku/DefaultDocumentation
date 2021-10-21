using System.Xml.Linq;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class CWriter : IElementWriter
    {
        public string Name => "c";

        public void Write(IWriter writer, XElement element)
        {
            writer
                .Append("`")
                .Append(element.Value)
                .Append("`");
        }
    }
}
