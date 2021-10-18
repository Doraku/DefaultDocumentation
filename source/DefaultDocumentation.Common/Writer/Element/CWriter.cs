using System.Xml.Linq;

namespace DefaultDocumentation.Writer.Element
{
    internal sealed class CWriter : ElementWriter
    {
        public CWriter()
            : base("c")
        { }

        public override void Write(PageWriter writer, XElement element)
        {
            writer
                .Append("`")
                .Append(element.Value)
                .Append("`");
        }
    }
}
