using DefaultDocumentation.Model;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    public sealed class NameFactory : AMarkdownFactory
    {
        public override string Name => "Name";

        protected override string GetMarkdownFileName(DocumentationContext context, DocItem item) => item.LongName;
    }
}
