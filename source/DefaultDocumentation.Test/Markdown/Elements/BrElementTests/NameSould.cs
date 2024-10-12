using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.BrElementTests;

public sealed class NameSould : BaseElementTester<BrElement>
{
    [Fact]
    public void ReturnBr() => Check.That(Name).IsEqualTo("br");
}
