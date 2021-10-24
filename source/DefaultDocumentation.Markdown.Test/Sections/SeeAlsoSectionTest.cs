using System.Xml.Linq;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SeeAlsoSectionTest : ASectionTest<SeeAlsoSection>
    {
        [Fact]
        public void Name_should_be_seealso() => Check.That(Name).IsEqualTo("seealso");

        [Fact]
        public void Write_should_not_write_When_not_present() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(SeeAlsoSectionTest).FullName}"), null),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new ClassDocItem(
                null,
                AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(SeeAlsoSectionTest).FullName}"),
                new XElement("doc",
                    new XElement("seealso", new XAttribute("cref", "T:System.Int32")),
                    new XElement("seealso", new XAttribute("href", "dummyurl")),
                    new XElement("seealso", new XAttribute("cref", "T:System.Int32"), "test"),
                    new XElement("seealso", new XAttribute("href", "dummyurl"), "test"))),
@"### See Also
- [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
- [dummyurl](dummyurl 'dummyurl')
- [test](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
- [test](dummyurl 'dummyurl')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(SeeAlsoSectionTest).FullName}"), new XElement("doc", new XElement("seealso", new XAttribute("cref", "T:System.Int32")))),
            w => w.Append("pouet"),
@"pouet

### See Also
- [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");
    }
}
