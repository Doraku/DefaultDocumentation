using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;

namespace DefaultDocumentation.Markdown.Elements
{
    /// <summary>
    /// Handles <c>para</c> xml element.
    /// </summary>
    public sealed class ParaElement : IElement
    {
        /// <inheritdoc/>
        public string Name => "para";

        /// <inheritdoc/>
        public void Write(IWriter writer, XElement element)
        {
            writer
                .EnsureLineStartAndAppendLine()
                .AppendAsMarkdown(element);
        }
    }
}
