using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParaWriter : ElementWriter
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
