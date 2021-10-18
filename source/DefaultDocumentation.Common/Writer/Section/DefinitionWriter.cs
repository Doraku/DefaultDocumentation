using DefaultDocumentation.Model;

namespace DefaultDocumentation.Writer.Section
{
    internal sealed class DefinitionWriter : SectionWriter
    {
        public DefinitionWriter()
            : base("definition")
        { }

        public override void Write(PageWriter writer)
        {
            if (writer.CurrentItem is IDefinedDocItem definedItem && writer.Context.ElementWriters.TryGetValue("code", out ElementWriter codeWriter))
            {
                codeWriter.Write(writer, definedItem.Definition);
            }
        }
    }
}
