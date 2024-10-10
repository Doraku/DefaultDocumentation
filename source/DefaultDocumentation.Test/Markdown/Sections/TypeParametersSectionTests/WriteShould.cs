using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.TypeParametersSectionTests;

public sealed class WriteShould : BaseSectionTester<TypeParametersSection>
{
    protected override IUrlFactory[] GetUrlFactories()
    => [
        new DocItemFactory()
    ];

    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.MethodWithGenericConstrainsDocItem.TypeParameters
            .AsEnumerable<DocItem>()
            .Concat(AssemblyInfo.ClassWithTypeParameterDocItem.TypeParameters)
            .ToDictionary(i => i.Id);

    protected override ISection[] GetSections()
    => [
        new TitleSection()
    ];

    [Fact]
    public void NotWriteWhenNoITypeParameterizedDocItem() => Test(string.Empty);

    [Fact]
    public void WriteWhenTypeDocItem() => Test(
        AssemblyInfo.ClassWithTypeParameterDocItem,
@"#### Type parameters

<a name='DefaultDocumentation.AssemblyInfo.ClassWithTypeParameter_T_.T'></a>

`T`");

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItem() => Test(
        AssemblyInfo.ExplicitMethodDocItem,
        string.Empty);

    [Fact]
    public void WriteWhenMethodDocItem() => Test(
        AssemblyInfo.MethodWithGenericConstrainsDocItem,
@"#### Type parameters

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains_T1,T2,T3,T4,T5_().T1'></a>

`T1`

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains_T1,T2,T3,T4,T5_().T2'></a>

`T2`

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains_T1,T2,T3,T4,T5_().T3'></a>

`T3`

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains_T1,T2,T3,T4,T5_().T4'></a>

`T4`

<a name='DefaultDocumentation.AssemblyInfo.MethodWithGenericConstrains_T1,T2,T3,T4,T5_().T5'></a>

`T5`");
}
