using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ValueSection : ISectionWriter
    {
        public string Name => "value";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is PropertyDocItem propertyItem)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine()
                    .AppendLine("#### Property Value")
                    .AppendLink(propertyItem, propertyItem.Property.ReturnType)
                    .AppendLine("  ")
                    .AppendAsMarkdown(propertyItem.Documentation?.Element(Name));
            }
        }
    }
}
