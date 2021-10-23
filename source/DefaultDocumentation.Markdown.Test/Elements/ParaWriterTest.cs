using System.Xml.Linq;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParaWriterTest : AElementWriterTest<ParaWriter>
    {
        [Fact]
        public void Name_should_be_para() => Check.That(Name).IsEqualTo("para");

        [Fact]
        public void Write_should_write() => Test(
            new XElement("para", "test"),
            "test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            w => w.Append("pouet"),
            new XElement("para", "test"),
@"pouet

test");

        [Fact]
        public void Write_should_not_write_newline_When_not_needed() => Test(
            w => w
                .Append("pouet")
                .AppendLine(),
            new XElement("para", "test\n"),
@"pouet

test");
    }
}
