using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements.NoteElementTests;

public sealed class WriteShould : BaseElementTester<NoteElement>
{
    [Fact]
    public void WriteExceteraWhenDisplayAsSingleLineIsTrue() => Test(
        w => w.SetDisplayAsSingleLine(true),
        new XElement("note", "test"),
        "...");

    [Fact]
    public void Write() => Test(
        new XElement("note", "test"),
        "> test");

    [Fact]
    public void WriteWhenMultiline() => Test(
        new XElement("note", "test\ntest"),
@"> test
> test");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        w => w.Append("pouet"),
        new XElement("note", "test"),
@"pouet
> test");

    [Fact]
    public void WriteNoHeaderWhenUnknown() => Test(
        new XElement("note", new XAttribute("type", "dummy"), "test"),
        "> test");

    [Fact]
    public void WriteNoteHeaderWhenNote() => Test(
        new XElement("note", new XAttribute("type", "note"), "test"),
@"> **Note:**  
> test");

    [Fact]
    public void WriteTipHeaderWhenTip() => Test(
        new XElement("note", new XAttribute("type", "tip"), "test"),
@"> **Tip:**  
> test");

    [Fact]
    public void WriteCautionHeaderWhenCaution() => Test(
        new XElement("note", new XAttribute("type", "caution"), "test"),
@"> **Caution:**  
> test");

    [Fact]
    public void WriteWarningHeaderWhenWarning() => Test(
        new XElement("note", new XAttribute("type", "warning"), "test"),
@"> **Warning:**  
> test");

    [Fact]
    public void WriteImportantHeaderWhenImportant() => Test(
        new XElement("note", new XAttribute("type", "important"), "test"),
@"> **Important:**  
> test");

    [Theory]
    [InlineData("security")]
    [InlineData("security note")]
    public void WriteSecurityNoteHeader(string type) => Test(
        new XElement("note", new XAttribute("type", type), "test"),
@"> **Security Note:**  
> test");

    [Fact]
    public void WriteNotesToImplementersNoteHeaderWhenImplement() => Test(
        new XElement("note", new XAttribute("type", "implement"), "test"),
@"> **Notes to Implementers:**  
> test");

    [Fact]
    public void WriteNoteToInheritorsHeaderWhenInherit() => Test(
        new XElement("note", new XAttribute("type", "inherit"), "test"),
@"> **Notes to Inheritors:**  
> test");

    [Fact]
    public void WriteNoteToCallersHeaderWhenCaller() => Test(
        new XElement("note", new XAttribute("type", "caller"), "test"),
        $"> **Notes to Callers:**  {Environment.NewLine}> test");

    [Theory]
    [InlineData("cs")]
    [InlineData("csharp")]
    [InlineData("c#")]
    [InlineData("visual c#")]
    [InlineData("visual c# note")]
    public void WriteCSNoteHeader(string type) => Test(
        new XElement("note", new XAttribute("type", type), "test"),
@"> **C\# Note:**  
> test");

    [Theory]
    [InlineData("vb")]
    [InlineData("vbnet")]
    [InlineData("vb.net")]
    [InlineData("visualbasic")]
    [InlineData("visual basic")]
    [InlineData("visual basic note")]
    public void WriteVBNetNoteHeader(string type) => Test(
        new XElement("note", new XAttribute("type", type), "test"),
@"> **VB\.NET Note:**  
> test");

    [Theory]
    [InlineData("fs")]
    [InlineData("fsharp")]
    [InlineData("f#")]
    public void WriteFSNoteHeader(string type) => Test(
        new XElement("note", new XAttribute("type", type), "test"),
@"> **F\# Note:**  
> test");

    [Theory]
    [InlineData("cpp")]
    [InlineData("c++")]
    [InlineData("visual c++")]
    [InlineData("visual c++ note")]
    public void WriteCppNoteHeader(string type) => Test(
        new XElement("note", new XAttribute("type", type), "test"),
@"> **C\+\+ Note:**  
> test");

    [Theory]
    [InlineData("jsharp")]
    [InlineData("j#")]
    [InlineData("visual j#")]
    [InlineData("visual j# note")]
    public void WriteJSNoteHeader(string type) => Test(
        new XElement("note", new XAttribute("type", type), "test"),
@"> **J\# Note:**  
> test");
}
