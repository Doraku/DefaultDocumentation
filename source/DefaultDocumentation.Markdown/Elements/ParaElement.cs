using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParaElement : IElement
    {
        public string Name => "para";

        public void Write(IWriter writer, XElement element)
        {
            writer
                .EnsureLineStartAndAppendLine()
                .AppendAsMarkdown(element);
        }
    }
}
