using System.Xml.Linq;

namespace DefaultDocumentation.Writer.Element
{
    internal sealed class ParaWriter : ElementWriter
    {
        public ParaWriter()
            : base("para")
        { }

        public override void Write(PageWriter writer, XElement element)
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
