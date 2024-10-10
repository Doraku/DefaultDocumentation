using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.FileNameFactories.NameFactoryTests;

public sealed class NameFactoryTest : BaseFileNameFactoryTester<NameFactory>
{
    [Fact]
    public void ReturnName() => Check.That(Name).IsEqualTo("Name");
}
