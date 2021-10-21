using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DefinitionWriter : ISectionWriter
    {
        public string Name => "definition";

        public void Write(IWriter writer)
        {
            if (writer.CurrentItem is IDefinedDocItem definedItem)
            {
                writer.Append(definedItem.Definition);
            }
        }
    }
}
