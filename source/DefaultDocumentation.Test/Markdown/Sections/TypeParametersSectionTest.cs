using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TypeParametersSectionTest : ASectionTest<TypeParametersSection>
    {
        protected override IUrlFactory[] GetUrlFactories() => new IUrlFactory[]
        {
            new DocItemFactory()
        };

        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.MethodWithGenericConstrainsDocItem.TypeParameters
                .AsEnumerable<DocItem>()
                .Concat(AssemblyInfo.ClassWithTypeParameterDocItem.TypeParameters)
                .ToDictionary(i => i.Id);

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

<a name='DefaultDocumentation.AssemblyInfo.ClassWithTypeParameter<T>.T'></a>

`T`");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem() => Test(
            AssemblyInfo.ExplicitMethodDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            AssemblyInfo.MethodWithGenericConstrainsDocItem,
@"#### Type parameters

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains<T1,T2,T3,T4,T5>().T1'></a>

`T1`

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains<T1,T2,T3,T4,T5>().T2'></a>

`T2`

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains<T1,T2,T3,T4,T5>().T3'></a>

`T3`

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains<T1,T2,T3,T4,T5>().T4'></a>

`T4`

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains<T1,T2,T3,T4,T5>().T5'></a>

`T5`");
    }
}
