using DefaultDocumentation.Markdown.FileNameFactories;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Markdown.FileNameFactories
{
    public sealed class Md5FactoryTest : AFileNameFactoryTest<Md5Factory>
    {
        [Fact]
        public void Name_Should_return_FullName() => Check.That(Name).IsEqualTo("Md5");

        [Fact]
        public void GetFileName_Should_return_Md5() => Test(AssemblyInfo.ClassDocItem, "07ucmh7NagP7qlcO1w9snQ.md");
    }
}
