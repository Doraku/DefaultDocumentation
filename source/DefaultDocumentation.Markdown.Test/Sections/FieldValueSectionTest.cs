using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class FieldValueSectionTest : ASectionTest<FieldValueSection>
    {
#pragma warning disable CS0649
        private static readonly int _field;
#pragma warning restore CS0649

        [Fact]
        public void Name_should_be_FieldValue() => Check.That(Name).IsEqualTo("FieldValue");

        [Fact]
        public void Write_should_not_write_When_not_FieldDocItem() => Test(
            default(DocItem),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new FieldDocItem(null, AssemblyInfo.Get<IField>($"F:{typeof(FieldValueSectionTest).FullName}.{nameof(_field)}"), null),
@"#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new FieldDocItem(null, AssemblyInfo.Get<IField>($"F:{typeof(FieldValueSectionTest).FullName}.{nameof(_field)}"), null),
            w => w.Append("pouet"),
@"pouet

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");
    }
}
