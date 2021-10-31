using DefaultDocumentation.Model;

namespace DefaultDocumentation.Markdown.FileNameFactories
{
    public sealed class NameFactory : AMarkdownFactory
    {
        public override string Name => "Name";

        protected override string GetMarkdownFileName(IGeneralContext context, DocItem item) => item.LongName;
    }
}
