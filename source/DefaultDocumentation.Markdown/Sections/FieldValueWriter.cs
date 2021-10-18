using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class FieldValueWriter : SectionWriter
    {
        public FieldValueWriter()
            : base("fieldvalue")
        { }

        public override void Write(PageWriter writer)
        {
            if (writer.CurrentItem is FieldDocItem fieldItem)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("#### Field Value")
                    .AppendLink(fieldItem, fieldItem.Field.Type)
                    .AppendLine();
            }
        }
    }
}
