using System.Xml.Linq;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExampleSectionTest : ASectionTest<ExampleSection>
    {
        [Fact]
        public void Name_should_be_example() => Check.That(Name).IsEqualTo("example");

        [Fact]
        public void Write_should_not_write_When_not_present() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ExampleSectionTest).FullName}"), null),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ExampleSectionTest).FullName}"), new XElement("doc", new XElement("example", "test"))),
@"### Example
test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(ExampleSectionTest).FullName}"), new XElement("doc", new XElement("example", "test"))),
            w => w.Append("pouet"),
@"pouet

### Example
test");
    }
}
