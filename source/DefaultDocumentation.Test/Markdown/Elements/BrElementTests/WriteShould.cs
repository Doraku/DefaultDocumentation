using System.Xml.Linq;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.BrElementTests;

public sealed class WriteShould : BaseElementTester<BrElement>
{
    [Fact]
    public void Write() => Test(
        new XElement("br"),
        "<br/>");
}
