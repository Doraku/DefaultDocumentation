using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.CElementTests;

public sealed class NameSould : BaseElementTester<CElement>
{
    [Fact]
    public void ReturnC() => Check.That(Name).IsEqualTo("c");
}
