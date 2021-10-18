using DefaultDocumentation.Model;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DefinitionWriter : ISectionWriter
    {
        public string Name => "definition";

        public void Write(PageWriter writer)
        {
            if (writer.CurrentItem is IDefinedDocItem definedItem && writer.Context.ElementWriters.TryGetValue("code", out IElementWriter codeWriter))
            {
                codeWriter.Write(writer, definedItem.Definition);
            }
        }
    }
}
