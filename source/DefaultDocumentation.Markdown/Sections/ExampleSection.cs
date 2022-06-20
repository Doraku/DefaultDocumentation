using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    /// <summary>
    /// <see cref="ISection"/> implementation to write the <c>example</c> top level element.
    /// </summary>
    public sealed class ExampleSection : ISection
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "example";

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
        public void Write(IWriter writer)
        {
            XElement? example = writer.GetCurrentItem().Documentation?.Element(Name);

            if (example != null)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .AppendLine("### Example")
                    .AppendAsMarkdown(example);
            }
        }
    }
}
