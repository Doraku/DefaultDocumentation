using System.Xml.Linq;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ValueWriter : ISectionWriter
    {
        public string Name => "value";

        public void Write(IWriter writer)
        {
            if (writer.CurrentItem is PropertyDocItem propertyItem)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine()
                    .AppendLine("#### Property Value")
                    .AppendLink(propertyItem, propertyItem.Property.ReturnType);

                XElement value = propertyItem.Documentation?.Element(Name);

                if (value != null)
                {
                    writer
                        .AppendLine()
                        .AppendLine()
                        .AppendAsMarkdown(value);
                }
            }
        }
    }
}
