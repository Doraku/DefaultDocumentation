using System.Xml.Linq;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class PropertyValueWriter : ISectionWriter
    {
        public string Name => "propertyvalue";

        public void Write(IWriter writer)
        {
            if (writer.CurrentItem is PropertyDocItem propertyItem)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("#### Property Value")
                    .AppendLink(propertyItem, propertyItem.Property.ReturnType);

                XElement value = propertyItem.Documentation.GetValue();

                if (value != null)
                {
                    writer
                        .EnsureLineStart()
                        .AppendAsMarkdown(value);
                }
            }
        }
    }
}
