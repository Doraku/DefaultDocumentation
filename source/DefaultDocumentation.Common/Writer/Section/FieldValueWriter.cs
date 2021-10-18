using DefaultDocumentation.Model.Member;

namespace DefaultDocumentation.Writer.Section
{
    internal sealed class FieldValueWriter : SectionWriter
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
