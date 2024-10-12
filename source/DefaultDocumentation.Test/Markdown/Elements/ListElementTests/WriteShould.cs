using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.ListElementTests;

public sealed class WriteShould : BaseElementTester<ListElement>
{
    protected override IReadOnlyDictionary<string, IElement> GetElements() => new IElement[]
    {
        new ListElement()
    }.ToDictionary(element => element.Name);

    [Fact]
    public void WriteWhenTypeIsBulletAndDisplayAsSingleLine() => Test(
        w => w.SetDisplayAsSingleLine(true),
        new XElement("list", new XAttribute("type", "bullet")),
        string.Empty);

    [Fact]
    public void NotWriteWhenTypeIsUnknown() => Test(
        new XElement("list", new XAttribute("type", "unknown")),
        string.Empty);

    [Fact]
    public void NotWriteWhenTypeIsNumberAndDisplayAsSingleLine() => Test(
        w => w.SetDisplayAsSingleLine(true),
        new XElement("list", new XAttribute("type", "number")),
        string.Empty);

    [Fact]
    public void NotWriteWhenTypeIsTableAndDisplayAsSingleLine() => Test(
        w => w.SetDisplayAsSingleLine(true),
        new XElement("list", new XAttribute("type", "table")),
        string.Empty);

    [Fact]
    public void WriteWhenTypeIsBullet() => Test(
        new XElement("list", new XAttribute("type", "bullet"), new XElement("item", "item1"), new XElement("item", "item2")),
@"- item1
- item2");

    [Fact]
    public void WriteWhenNested() => Test(
        new XElement("list", new XAttribute("type", "bullet"),
            new XElement("item", "item1"),
            new XElement("item",
                "item2",
                new XElement("list", new XAttribute("type", "number"),
                    new XElement("item", "item3"),
                    new XElement("item", "item4"))),
            new XElement("item", "item5")),
@"- item1
- item2
  1. item3
  2. item4
- item5");

    [Fact]
    public void SeparateTermAndDescription() => Test(
        new XElement("list", new XAttribute("type", "bullet"), new XElement("item", new XElement("term", "Term"), new XElement("description", "Description"))),
        "- Term — Description"
    );

    [Fact]
    public void NotSeparateLonelyDescriptionAndTerm() => Test(
        new XElement("list", new XAttribute("type", "bullet"),
            new XElement("item", new XElement("term", "Term")),
            new XElement("item", new XElement("description", "Description"))
        ),
@"- Term
- Description"
    );

    [Fact]
    public void WritePrefixWhenTypeIsBulletAndItemIsMultiline() => Test(
        new XElement("list", new XAttribute("type", "bullet"), new XElement("item", "item1\nect..."), new XElement("item", "item2")),
@"- item1
  ect...
- item2");

    [Fact]
    public void WriteNewlineWhenNeededAndTypeIsBullet() => Test(
        w => w.Append("pouet"),
        new XElement("list", new XAttribute("type", "bullet"), new XElement("item", "item1"), new XElement("item", "item2")),
@"pouet
- item1
- item2");

    [Fact]
    public void WriteWhenTypeIsNumber() => Test(
        new XElement("list", new XAttribute("type", "number"), new XElement("item", "item1"), new XElement("item", "item2")),
@"1. item1
2. item2");

    [Fact]
    public void WritePrefixWhenTypeIsNumberAndItemIsMultiline() => Test(
        new XElement("list", new XAttribute("type", "number"), new XElement("item", "item1\nect..."), new XElement("item", "item2")),
@"1. item1
  ect...
2. item2");

    [Fact]
    public void WriteNewlineWhenNeededAndTypeIsNumber() => Test(
        w => w.Append("pouet"),
        new XElement("list", new XAttribute("type", "number"), new XElement("item", "item1"), new XElement("item", "item2")),
@"pouet
1. item1
2. item2");

    [Fact]
    public void WriteWhenTypeIsTable() => Test(
        new XElement("list", new XAttribute("type", "table"),
            new XElement("listheader", new XElement("term", "col1"), new XElement("term", "col2")),
            new XElement("item", new XElement("description", "item11"), new XElement("description", "item12")),
            new XElement("item", new XElement("description", "item21"), new XElement("description", "item22"))),
@"|col1|col2|
|-|-|
|item11|item12|
|item21|item22|

");

    [Fact]
    public void WritePrefixWhenTypeIsTableAndItemIsMultiline() => Test(
        w => w.SetHandleLineBreak(true),
        new XElement("list", new XAttribute("type", "table"),
            new XElement("listheader", new XElement("term", "col1\nect..."), new XElement("term", "col2")),
            new XElement("item", new XElement("description", "item11\nect..."), new XElement("description", "item12")),
            new XElement("item", new XElement("description", "item21"), new XElement("description", "item22"))),
@"|col1<br/>ect...|col2|
|-|-|
|item11<br/>ect...|item12|
|item21|item22|

");

    [Fact]
    public void WriteNewlineWhenNeededAndTypeIsTable() => Test(
        w => w.Append("pouet"),
        new XElement("list", new XAttribute("type", "table"),
            new XElement("listheader", new XElement("term", "col1"), new XElement("term", "col2")),
            new XElement("item", new XElement("description", "item11"), new XElement("description", "item12")),
            new XElement("item", new XElement("description", "item21"), new XElement("description", "item22"))),
@"pouet

|col1|col2|
|-|-|
|item11|item12|
|item21|item22|

");
}
