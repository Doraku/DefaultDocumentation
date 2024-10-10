using System.Xml.Linq;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.CElementTests;

public sealed class WriteShould : BaseElementTester<CElement>
{
    [Fact]
    public void Write() => Test(
        new XElement("c", "test"),
        "`test`");
}
