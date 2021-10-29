using DefaultDocumentation.Model;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    public sealed class FullNameFactory : AMarkdownFactory
    {
        public override string Name => "FullName";

        protected override string GetMarkdownFileName(DocumentationContext context, DocItem item) => item.FullName;
    }
}
