using DefaultDocumentation.Markdown.FileNameFactories;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Markdown.FileNameFactories
{
    public sealed class FullNameFactoryTest : AFileNameFactoryTest<FullNameFactory>
    {
        [Fact]
        public void Name_Should_return_FullName() => Check.That(Name).IsEqualTo("FullName");

        [Fact]
        public void GetFileName_Should_return_FullName() => Test(AssemblyInfo.ClassDocItem, $"{AssemblyInfo.ClassDocItem.FullName}.md");
    }
}
