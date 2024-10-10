using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ParametersSectionTests;

public sealed class WriteShould : BaseSectionTester<ParametersSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.MethodWithParameterDocItem.Parameters.AsEnumerable<DocItem>()
        .Concat(AssemblyInfo.OperatorDocItem.Parameters)
        .Concat(Enumerable.Repeat(AssemblyInfo.ClassDocItem, 1))
        .ToDictionary(i => i.Id);

    protected override IUrlFactory[] GetUrlFactories() => [new DocItemFactory()];

    protected override ISection[] GetSections() => [new TitleSection()];

    [Fact]
    public void NotWriteWhenNoIParameterizedDocItem() => Test(string.Empty);

    [Fact]
    public void WriteWhenTypeDocItem() => Test(
        AssemblyInfo.MethodWithParameterDocItem,
@"#### Parameters

<a name='DefaultDocumentation.AssemblyInfo.MethodWithParameter(int).parameter'></a>

`parameter` System.Int32");

    [Fact]
    public void WriteWhenConstructorDocItem() => Test(
        AssemblyInfo.ConstructorDocItem,
        string.Empty);

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItem() => Test(
        AssemblyInfo.ExplicitMethodDocItem,
        string.Empty);

    [Fact]
    public void WriteWhenOperatorDocItem() => Test(
        AssemblyInfo.OperatorDocItem,
@"#### Parameters

<a name='DefaultDocumentation.AssemblyInfo.op_Addition(DefaultDocumentation.AssemblyInfo,int)._'></a>

`_` [AssemblyInfo](AssemblyInfo 'DefaultDocumentation.AssemblyInfo')

<a name='DefaultDocumentation.AssemblyInfo.op_Addition(DefaultDocumentation.AssemblyInfo,int).__'></a>

`__` System.Int32");

    [Fact]
    public void WriteWhenPropertyDocItem() => Test(
        AssemblyInfo.PropertyDocItem,
        string.Empty);

    [Fact]
    public void WriteWhenDelegateDocItem() => Test(
        AssemblyInfo.DelegateDocItem,
        string.Empty);
}
