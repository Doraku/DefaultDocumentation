using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TypeParametersSectionTest : ASectionTest<TypeParametersSection>
    {
        protected override ISectionWriter[] GetSectionWriters() => new ISectionWriter[]
        {
            new TitleSection()
        };

        private static void Method<T>(T _)
        { }

        [Fact]
        public void Name_should_be_TypeParameters() => Check.That(Name).IsEqualTo("TypeParameters");

        [Fact]
        public void Write_should_not_write_When_no_TypeParameterDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_write_When_TypeParameterDocItem() => Test(
            new MethodDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(TypeParametersSectionTest).FullName}.{nameof(Method)}``1(``0)"), null),
@"#### Type parameters

<a name='DefaultDocumentation_Markdown_Sections_TypeParametersSectionTest_Method_T_(T)_T'></a>
`T`");
    }
}
