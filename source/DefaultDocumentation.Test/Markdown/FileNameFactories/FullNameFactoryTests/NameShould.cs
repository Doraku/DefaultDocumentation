using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.FileNameFactories.FullNameFactoryTests;

public sealed class NameShould : BaseFileNameFactoryTester<FullNameFactory>
{
    [Fact]
    public void ReturnFullName() => Check.That(Name).IsEqualTo("FullName");
}
