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
        public void Write_should_not_write_When_no_TypeParameterDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_write_When_TypeParameterDocItem() => Test(
            AssemblyInfo.ClassWithTypeParameterDocItem,
@"#### Type parameters

<a name='T'></a>

`T`");
    }
}
