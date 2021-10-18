using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Member;

namespace DefaultDocumentation.Writer.Section
{
    internal sealed class PropertyValueWriter : SectionWriter
    {
        public PropertyValueWriter()
            : base("propertyvalue")
        { }

        public override void Write(PageWriter writer)
        {
            if (writer.CurrentItem is PropertyDocItem propertyItem)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("#### Property Value")
                    .AppendLink(propertyItem, propertyItem.Property.ReturnType)
                    .AppendLine()
                    .Append(propertyItem.Documentation.GetValue())
                    .AppendLine();
            }
        }
    }
}
