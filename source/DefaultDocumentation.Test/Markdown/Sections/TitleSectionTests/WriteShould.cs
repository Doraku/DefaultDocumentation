using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.TitleSectionTests;

public sealed class WriteShould : BaseSectionTester<TitleSection>
{
    protected override IUrlFactory[] GetUrlFactories() => [new DocItemFactory()];

    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.MethodWithParameterDocItem.Parameters
            .AsEnumerable<DocItem>()
            .Concat(AssemblyInfo.ClassWithTypeParameterDocItem.TypeParameters)
            .Concat(AssemblyInfo.EnumFieldDocItem)
            .Concat(AssemblyInfo.EnumFieldWithConstantDocItem)
            .ToDictionary(item => item.Id);

    protected override GeneratedPages GetGeneratedPages()
        => GeneratedPages.Assembly
        | GeneratedPages.Namespaces
        | GeneratedPages.Types
        | GeneratedPages.Members;

    [Fact]
    public void NotWriteWhenUnknownDocItem() => Test(
        string.Empty);

    [Fact]
    public void WriteWhenAssemblyDocItem() => Test(
        AssemblyInfo.AssemblyDocItem,
        "## Test Assembly");

    [Fact]
    public void WriteWhenNamespaceDocItem() => Test(
        AssemblyInfo.NamespaceDocItem,
        "## DefaultDocumentation Namespace");

    [Fact]
    public void WriteWhenTypeDocItem() => Test(
        AssemblyInfo.ClassDocItem,
        "## AssemblyInfo Class");

    [Fact]
    public void WriteWhenConstructorDocItem() => Test(
        AssemblyInfo.ConstructorDocItem,
        @"## AssemblyInfo\(\) Constructor");

    [Fact]
    public void WriteWhenEventDocItem() => Test(
        AssemblyInfo.EventDocItem,
        @"## AssemblyInfo\.Event Event");

    [Fact]
    public void WriteWhenFieldDocItem() => Test(
        AssemblyInfo.FieldDocItem,
        @"## AssemblyInfo\.\_field Field");

    [Fact]
    public void WriteWhenMethodDocItem() => Test(
        AssemblyInfo.MethodWithParameterDocItem,
        @"## AssemblyInfo\.MethodWithParameter\(int\) Method");

    [Fact]
    public void WriteWhenOperatorDocItem() => Test(
        AssemblyInfo.OperatorDocItem,
        @"## AssemblyInfo\.operator \+\(AssemblyInfo, int\) Operator");

    [Fact]
    public void WriteWhenPropertyDocItem() => Test(
        AssemblyInfo.PropertyDocItem,
        @"## AssemblyInfo\.Property Property");

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItemAndEvent() => Test(
        AssemblyInfo.ExplicitEventDocItem,
        @"## AssemblyInfo\.DefaultDocumentation\.AssemblyInfo\.IInterface\.Event Event");

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItemAndProperty() => Test(
        AssemblyInfo.ExplicitPropertyDocItem,
        @"## AssemblyInfo\.DefaultDocumentation\.AssemblyInfo\.IInterface\.Property Property");

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItemAndMethod() => Test(
        AssemblyInfo.ExplicitMethodDocItem,
        @"## AssemblyInfo\.DefaultDocumentation\.AssemblyInfo\.IInterface\.Method\(\) Method");

    [Fact]
    public void WriteWhenEnumFieldDocItem() => Test(
        AssemblyInfo.EnumFieldDocItem,
@"<a name='DefaultDocumentation.AssemblyInfo.Enum.Value'></a>

`Value` 0");

    [Fact]
    public void WriteWhenEnumFieldDocItemAndConstantValue() => Test(
        AssemblyInfo.EnumFieldWithConstantDocItem,
@"<a name='DefaultDocumentation.AssemblyInfo.Enum.ValueWithConstant'></a>

`ValueWithConstant` 42");

    [Fact]
    public void WriteWhenParameterDocItem() => Test(
        AssemblyInfo.MethodWithParameterDocItem.Parameters.Single(),
@"<a name='DefaultDocumentation.AssemblyInfo.MethodWithParameter(int).parameter'></a>

`parameter` System\.Int32");

    [Fact]
    public void WriteWhenTypeParameterDocItem() => Test(
        AssemblyInfo.ClassWithTypeParameterDocItem.TypeParameters.Single(),
@"<a name='DefaultDocumentation.AssemblyInfo.ClassWithTypeParameter_T_.T'></a>

`T`");
}
