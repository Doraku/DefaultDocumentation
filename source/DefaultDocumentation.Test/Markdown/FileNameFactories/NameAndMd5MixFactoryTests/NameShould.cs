using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.FileNameFactories.NameAndMd5MixFactoryTests;

public sealed class NameShould : BaseFileNameFactoryTester<NameAndMd5MixFactory>
{
    [Fact]
    public void ReturnNameAndMd5Mix() => Check.That(Name).IsEqualTo("NameAndMd5Mix");
}
