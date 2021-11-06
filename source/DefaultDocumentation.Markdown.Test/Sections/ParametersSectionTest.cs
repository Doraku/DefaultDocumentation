using DefaultDocumentation.Api;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ParametersSectionTest : ASectionTest<ParametersSection>
    {
        protected override ISection[] GetSections() => new ISection[]
        {
            new TitleSection()
        };

        [Fact]
        public void Name_should_be_Parameters() => Check.That(Name).IsEqualTo("Parameters");

        [Fact]
        public void Write_should_not_write_When_no_TypeParameterDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_write_When_TypeParameterDocItem() => Test(
            AssemblyInfo.MethodWithParameterDocItem,
@"#### Parameters

<a name='parameter'></a>

`parameter` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");
    }
}
