using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Elements
{
    /// <summary>
    /// Handles <c>c</c> xml element.
    /// </summary>
    public sealed class CElement : IElement
    {
        /// <inheritdoc/>
        public string Name => "c";

        /// <inheritdoc/>
        public void Write(IWriter writer, XElement element)
        {
            writer
                .Append("`")
                .Append(element.Value)
                .Append("`");
        }
    }
}
