using DefaultDocumentation.Markdown.FileNameFactories;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Markdown.FileNameFactories
{
    public sealed class NameFactoryTest : AFileNameFactoryTest<NameFactory>
    {
        [Fact]
        public void Name_Should_return_FullName() => Check.That(Name).IsEqualTo("Name");

        [Fact]
        public void GetFileName_Should_return_Name() => Test(AssemblyInfo.ClassDocItem, $"{AssemblyInfo.ClassDocItem.Name}.md");
    }
}
