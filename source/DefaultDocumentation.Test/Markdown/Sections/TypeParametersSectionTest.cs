using DefaultDocumentation.Api;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TypeParametersSectionTest : ASectionTest<TypeParametersSection>
    {
        protected override ISection[] GetSections() => new ISection[]
        {
            new TitleSection()
        };

        [Fact]
        public void Name_should_be_TypeParameters() => Check.That(Name).IsEqualTo("TypeParameters");

        [Fact]
        public void Write_should_not_write_When_no_ITypeParameterizedDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.ClassWithTypeParameterDocItem,
@"#### Type parameters

<a name='T'></a>

`T`");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem() => Test(
            AssemblyInfo.ExplicitMethodDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            AssemblyInfo.MethodWithGenericConstrainsDocItem,
@"#### Type parameters

<a name='T1'></a>

`T1`

<a name='T2'></a>

`T2`

<a name='T3'></a>

`T3`

<a name='T4'></a>

`T4`

<a name='T5'></a>

`T5`");
    }
}
