using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class FieldValueSection : ISection
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
