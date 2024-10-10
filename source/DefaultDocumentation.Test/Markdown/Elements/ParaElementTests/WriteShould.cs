using System.Xml.Linq;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.ParaElementTests;

public sealed class WriteShould : BaseElementTester<ParaElement>
{
    [Fact]
    public void Write() => Test(
        new XElement("para", "test"),
        "test");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        w => w.Append("pouet"),
        new XElement("para", "test"),
@"pouet

test");

    [Fact]
    public void NotWriteNewlineWhenNotNeeded() => Test(
        w => w
            .Append("pouet")
            .AppendLine(),
        new XElement("para", "test\n"),
@"pouet

test");
}
