using Xunit;

namespace DefaultDocumentation.Markdown.FileNameFactories.FullNameFactoryTests;

public sealed class GetFileNameShould : BaseFileNameFactoryTester<FullNameFactory>
{
    [Fact]
    public void ReturnFullName() => Test(AssemblyInfo.ClassDocItem, $"{AssemblyInfo.ClassDocItem.FullName}.md");
}
