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
        public void Write_should_not_write_When_no_IParameterizedDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.MethodWithParameterDocItem,
@"#### Parameters

<a name='parameter'></a>

`parameter` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_ConstructorDocItem() => Test(
            AssemblyInfo.ConstructorDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem() => Test(
            AssemblyInfo.ExplicitMethodDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_OperatorDocItem() => Test(
            AssemblyInfo.OperatorDocItem,
@"#### Parameters

<a name='_'></a>

`_` [DefaultDocumentation.Markdown.AssemblyInfo](https://docs.microsoft.com/en-us/dotnet/api/DefaultDocumentation.Markdown.AssemblyInfo 'DefaultDocumentation.Markdown.AssemblyInfo')

<a name='__'></a>

`__` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");

        [Fact]
        public void Write_should_write_When_PropertyDocItem() => Test(
            AssemblyInfo.PropertyDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_DelegateDocItem() => Test(
            AssemblyInfo.DelegateDocItem,
            string.Empty);
    }
}
