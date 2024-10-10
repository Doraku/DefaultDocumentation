using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.ListElementTests;

public sealed class NameShould : BaseElementTester<ListElement>
{
    [Fact]
    public void ReturnList()
    {
        Check.That(Name).IsEqualTo("list");
    }
}
