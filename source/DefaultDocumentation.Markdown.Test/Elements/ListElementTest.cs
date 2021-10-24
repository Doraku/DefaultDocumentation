using System.Xml.Linq;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ListElementTest : AElementTest<ListElement>
    {
        [Fact]
        public void Name_should_be_list() => Check.That(Name).IsEqualTo("list");

        [Fact]
        public void Write_should_write_When_type_is_bullet() => Test(
            new XElement("list", new XAttribute("type", "bullet"), new XElement("item", "item1"), new XElement("item", "item2")),
@"- item1
- item2");

        [Fact]
        public void Write_should_write_prefix_When_type_is_bullet_and_item_is_multiline() => Test(
            new XElement("list", new XAttribute("type", "bullet"), new XElement("item", "item1\nect..."), new XElement("item", "item2")),
@"- item1  
  ect...
- item2");

        [Fact]
        public void Write_should_write_newline_When_needed_and_type_is_bullet() => Test(
            w => w.Append("pouet"),
            new XElement("list", new XAttribute("type", "bullet"), new XElement("item", "item1"), new XElement("item", "item2")),
@"pouet
- item1
- item2");

        [Fact]
        public void Write_should_write_When_type_is_number() => Test(
            new XElement("list", new XAttribute("type", "number"), new XElement("item", "item1"), new XElement("item", "item2")),
@"1. item1
2. item2");

        [Fact]
        public void Write_should_write_prefix_When_type_is_number_and_item_is_multiline() => Test(
            new XElement("list", new XAttribute("type", "number"), new XElement("item", "item1\nect..."), new XElement("item", "item2")),
@"1. item1  
  ect...
2. item2");

        [Fact]
        public void Write_should_write_newline_When_needed_and_type_is_number() => Test(
            w => w.Append("pouet"),
            new XElement("list", new XAttribute("type", "number"), new XElement("item", "item1"), new XElement("item", "item2")),
@"pouet
1. item1
2. item2");

        [Fact]
        public void Write_should_write_When_type_is_table() => Test(
            new XElement("list", new XAttribute("type", "table"),
                new XElement("listheader", new XElement("description", "col1"), new XElement("description", "col2")),
                new XElement("item", new XElement("description", "item11"), new XElement("description", "item12")),
                new XElement("item", new XElement("description", "item21"), new XElement("description", "item22"))),
@"|col1|col2|
|-|-|
|item11|item12|
|item21|item22|");

        [Fact]
        public void Write_should_write_prefix_When_type_is_table_and_item_is_multiline() => Test(
            new XElement("list", new XAttribute("type", "table"),
                new XElement("listheader", new XElement("description", "col1\nect..."), new XElement("description", "col2")),
                new XElement("item", new XElement("description", "item11\nect..."), new XElement("description", "item12")),
                new XElement("item", new XElement("description", "item21"), new XElement("description", "item22"))),
@"|col1<br/>ect...|col2|
|-|-|
|item11<br/>ect...|item12|
|item21|item22|");

        [Fact]
        public void Write_should_write_newline_When_needed_and_type_is_table() => Test(
            w => w.Append("pouet"),
            new XElement("list", new XAttribute("type", "table"),
                new XElement("listheader", new XElement("description", "col1"), new XElement("description", "col2")),
                new XElement("item", new XElement("description", "item11"), new XElement("description", "item12")),
                new XElement("item", new XElement("description", "item21"), new XElement("description", "item22"))),
@"pouet
|col1|col2|
|-|-|
|item11|item12|
|item21|item22|");
    }
}
