using Xunit;

namespace DefaultDocumentation.Markdown.FileNameFactories.NameFactoryTests;

public sealed class GetFileNameShould : BaseFileNameFactoryTester<NameFactory>
{
    [Fact]
    public void ReturnName() => Test(AssemblyInfo.ClassDocItem, $"{AssemblyInfo.ClassDocItem.Name}.md");
}
