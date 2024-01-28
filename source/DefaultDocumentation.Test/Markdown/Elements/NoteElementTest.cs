﻿using System;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class NoteElementTest : AElementTest<NoteElement>
    {
        [Fact]
        public void Name_should_be_note() => Check.That(Name).IsEqualTo("note");

        [Fact]
        public void Write_should_not_write_When_DisplayAsSingleLine_is_true() => Test(
            w => w.SetDisplayAsSingleLine(true),
            new XElement("note", "test"),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new XElement("note", "test"),
            "> test");

        [Fact]
        public void Write_should_write_When_multiline() => Test(
            new XElement("note", "test\ntest"),
@"> test
> test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            w => w.Append("pouet"),
            new XElement("note", "test"),
@"pouet
> test");

        [Fact]
        public void Write_should_write_no_header_When_unknown() => Test(
            new XElement("note", new XAttribute("type", "dummy"), "test"),
            "> test");

        [Fact]
        public void Write_should_write_Note_header_When_note() => Test(
            new XElement("note", new XAttribute("type", "note"), "test"),
@"> **Note:**  
> test");

        [Fact]
        public void Write_should_write_Tip_header_When_tip() => Test(
            new XElement("note", new XAttribute("type", "tip"), "test"),
@"> **Tip:**  
> test");

        [Fact]
        public void Write_should_write_Caution_header_When_caution() => Test(
            new XElement("note", new XAttribute("type", "caution"), "test"),
@"> **Caution:**  
> test");

        [Fact]
        public void Write_should_write_Warning_header_When_warning() => Test(
            new XElement("note", new XAttribute("type", "warning"), "test"),
@"> **Warning:**  
> test");

        [Fact]
        public void Write_should_write_Important_header_When_important() => Test(
            new XElement("note", new XAttribute("type", "important"), "test"),
@"> **Important:**  
> test");

        [Theory]
        [InlineData("security")]
        [InlineData("security note")]
        public void Write_should_write_Security_Note_header(string type) => Test(
            new XElement("note", new XAttribute("type", type), "test"),
@"> **Security Note:**  
> test");

        [Fact]
        public void Write_should_write_Notes_to_Implementers_Note_header_When_implement() => Test(
            new XElement("note", new XAttribute("type", "implement"), "test"),
@"> **Notes to Implementers:**  
> test");

        [Fact]
        public void Write_should_write_Note_to_Inheritors_header_When_inherit() => Test(
            new XElement("note", new XAttribute("type", "inherit"), "test"),
@"> **Notes to Inheritors:**  
> test");

        [Fact]
        public void Write_should_write_Note_to_Callers_header_When_caller() => Test(
            new XElement("note", new XAttribute("type", "caller"), "test"),
            $"> **Notes to Callers:**  {Environment.NewLine}> test");

        [Theory]
        [InlineData("cs")]
        [InlineData("csharp")]
        [InlineData("c#")]
        [InlineData("visual c#")]
        [InlineData("visual c# note")]
        public void Write_should_write_CS_Note_header(string type) => Test(
            new XElement("note", new XAttribute("type", type), "test"),
@"> **C# Note:**  
> test");

        [Theory]
        [InlineData("vb")]
        [InlineData("vbnet")]
        [InlineData("vb.net")]
        [InlineData("visualbasic")]
        [InlineData("visual basic")]
        [InlineData("visual basic note")]
        public void Write_should_write_VBNet_Note_header(string type) => Test(
            new XElement("note", new XAttribute("type", type), "test"),
@"> **VB.NET Note:**  
> test");

        [Theory]
        [InlineData("fs")]
        [InlineData("fsharp")]
        [InlineData("f#")]
        public void Write_should_write_FS_Note_header(string type) => Test(
            new XElement("note", new XAttribute("type", type), "test"),
@"> **F# Note:**  
> test");

        [Theory]
        [InlineData("cpp")]
        [InlineData("c++")]
        [InlineData("visual c++")]
        [InlineData("visual c++ note")]
        public void Write_should_write_Cpp_Note_header(string type) => Test(
            new XElement("note", new XAttribute("type", type), "test"),
@"> **C++ Note:**  
> test");

        [Theory]
        [InlineData("jsharp")]
        [InlineData("j#")]
        [InlineData("visual j#")]
        [InlineData("visual j# note")]
        public void Write_should_write_JS_Note_header(string type) => Test(
            new XElement("note", new XAttribute("type", type), "test"),
@"> **J# Note:**  
> test");
    }
}
