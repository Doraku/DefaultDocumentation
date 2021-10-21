using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class FieldValueWriter : ISectionWriter
    {
        public string Name => "fieldvalue";

        public void Write(IWriter writer)
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
