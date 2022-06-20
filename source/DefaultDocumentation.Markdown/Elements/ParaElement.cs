using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Elements
{
    /// <summary>
    /// Handles <c>para</c> xml element.
    /// </summary>
    public sealed class ParaElement : IElement
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "para";

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
        public void Write(IWriter writer, XElement element)
        {
            writer
                .EnsureLineStartAndAppendLine()
                .AppendAsMarkdown(element);
        }
    }
}
