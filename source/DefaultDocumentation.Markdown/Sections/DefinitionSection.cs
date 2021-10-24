using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DefinitionSection : ISectionWriter
    {
        public string Name => "definition";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is IDefinedDocItem definedItem)
            {
                writer.Append(definedItem.Definition);
            }
        }
    }
}
