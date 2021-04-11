using DefaultDocumentation.Writer;

namespace DefaultDocumentation
{
    public static class Generator
    {
        public static void Execute(Settings settings) => new MarkdownWriter(settings).Execute();
    }
}
