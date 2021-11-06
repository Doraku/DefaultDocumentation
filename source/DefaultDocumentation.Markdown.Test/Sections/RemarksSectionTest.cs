using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class RemarksSectionTest : ASectionTest<RemarksSection>
    {
        [Fact]
        public void Name_should_be_remarks() => Check.That(Name).IsEqualTo("remarks");

        [Fact]
        public void Write_should_not_write_When_not_present() => Test(
            AssemblyInfo.ClassDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new ClassDocItem(AssemblyInfo.NamespaceDocItem, AssemblyInfo.ClassDocItem.Type, new XElement("doc", new XElement("remarks", "test"))),
@"### Remarks
test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(AssemblyInfo.NamespaceDocItem, AssemblyInfo.ClassDocItem.Type, new XElement("doc", new XElement("remarks", "test"))),
            w => w.Append("pouet"),
@"pouet

### Remarks
test");
    }
}
