using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.FileNameFactories.Md5FactoryTests;

public sealed class NameShould : BaseFileNameFactoryTester<Md5Factory>
{
    [Fact]
    public void ReturnMd5() => Check.That(Name).IsEqualTo("Md5");
}
