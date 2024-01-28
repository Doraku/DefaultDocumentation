using System.Xml.Linq;
using DefaultDocumentation.Models.Members;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ValueSectionTest : ASectionTest<ValueSection>
    {
        [Fact]
        public void Name_should_be_value() => Check.That(Name).IsEqualTo("value");

        [Fact]
        public void Write_should_not_write_When_not_PropertyDocItem() => Test(
            AssemblyInfo.AssemblyDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.PropertyDocItem,
@"#### Property Value
[System.Int32](T:System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_value_When_present() => Test(
            new PropertyDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.PropertyDocItem.Property, new XElement("doc", new XElement("value", "test"))),
@"#### Property Value
[System.Int32](T:System.Int32 'System.Int32')  
test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.PropertyDocItem,
            w => w.Append("pouet"),
@"pouet

#### Property Value
[System.Int32](T:System.Int32 'System.Int32')");
    }
}
