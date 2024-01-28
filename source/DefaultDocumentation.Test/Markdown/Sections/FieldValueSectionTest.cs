using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class FieldValueSectionTest : ASectionTest<FieldValueSection>
    {
        [Fact]
        public void Name_should_be_FieldValue() => Check.That(Name).IsEqualTo("FieldValue");

        [Fact]
        public void Write_should_not_write_When_not_FieldDocItem() => Test(
            AssemblyInfo.AssemblyDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.FieldDocItem,
@"#### Field Value
[System.Int32](T:System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.FieldDocItem,
            w => w.Append("pouet"),
@"pouet

#### Field Value
[System.Int32](T:System.Int32 'System.Int32')");
    }
}
