using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ValueSection : ISection
    {
        public string Name => "value";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is PropertyDocItem propertyItem)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .AppendLine("#### Property Value")
                    .AppendLink(propertyItem, propertyItem.Property.ReturnType)
                    .AppendLine("  ")
                    .AppendAsMarkdown(propertyItem.Documentation?.Element(Name));
            }
        }
    }
}
