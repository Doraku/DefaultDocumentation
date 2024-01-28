using System.Xml.Linq;
using DefaultDocumentation.Models.Members;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ReturnsSectionTest : ASectionTest<ReturnsSection>
    {
        [Fact]
        public void Name_should_be_returns() => Check.That(Name).IsEqualTo("returns");

        [Fact]
        public void Write_should_not_write_When_not_correct_DocItem() => Test(
            AssemblyInfo.AssemblyDocItem,
            string.Empty);

        [Fact]
        public void Write_should_not_write_When_returns_void() => Test(
            AssemblyInfo.ExplicitMethodDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_DelegateDocItem() => Test(
            AssemblyInfo.DelegateDocItem,
@"#### Returns
[System.Int32](T:System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            AssemblyInfo.MethodWithReturnDocItem,
@"#### Returns
[System.Boolean](T:System.Boolean 'System.Boolean')");

        [Fact]
        public void Write_should_write_When_OperatorDocItem() => Test(
            AssemblyInfo.OperatorDocItem,
@"#### Returns
[System.Int32](T:System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_present() => Test(
            new MethodDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.MethodWithReturnDocItem.Method, new XElement("doc", new XElement("returns", "test"))),
@"#### Returns
[System.Boolean](T:System.Boolean 'System.Boolean')  
test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.MethodWithReturnDocItem,
            w => w.Append("pouet"),
@"pouet

#### Returns
[System.Boolean](T:System.Boolean 'System.Boolean')");
    }
}
