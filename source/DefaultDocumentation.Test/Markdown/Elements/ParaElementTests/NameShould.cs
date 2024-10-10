using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.ParaElementTests;

public sealed class NameShould : BaseElementTester<ParaElement>
{
    [Fact]
    public void ReturnPara() => Check.That(Name).IsEqualTo("para");
}
