using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ParametersSectionTest : ASectionTest<ParametersSection>
    {
        protected override ISectionWriter[] GetSectionWriters() => new ISectionWriter[]
        {
            new TitleSection()
        };

        private static void Method(int _)
        { }

        [Fact]
        public void Name_should_be_Parameters() => Check.That(Name).IsEqualTo("Parameters");

        [Fact]
        public void Write_should_not_write_When_no_TypeParameterDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_write_When_TypeParameterDocItem() => Test(
            new MethodDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(ParametersSectionTest).FullName}.{nameof(Method)}(System.Int32)"), null),
@"#### Parameters

<a name='_'></a>
`_` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')");
    }
}
