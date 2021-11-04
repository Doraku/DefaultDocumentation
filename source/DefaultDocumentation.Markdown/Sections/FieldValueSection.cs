using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class FieldValueSection : ISectionWriter
    {
        public string Name => "FieldValue";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is FieldDocItem fieldItem)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .AppendLine("#### Field Value")
                    .AppendLink(fieldItem, fieldItem.Field.Type);
            }
        }
    }
}
