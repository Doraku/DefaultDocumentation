using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using ICSharpCode.Decompiler.TypeSystem;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ImplementSectionTests;

public sealed class WriteShould : BaseSectionTester<ImplementSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[]
    {
        AssemblyInfo.InterfaceDocItem,
        AssemblyInfo.InterfaceMethodDocItem,
        AssemblyInfo.InterfaceEventDocItem
    }.ToDictionary(item => item.Id);

    [Fact]
    public void NotWriteWhenNoImplementation() => Test(string.Empty);

    [Fact]
    public void WriteWhenTypeDocItem() => Test(
        AssemblyInfo.ClassDocItem,
        "Implements [IInterface](T:DefaultDocumentation.AssemblyInfo.IInterface 'DefaultDocumentation.AssemblyInfo.IInterface'), [System.Collections.IEnumerator](T:System.Collections.IEnumerator 'System.Collections.IEnumerator')");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        AssemblyInfo.ClassDocItem,
        w => w.Append("pouet"),
@"pouet

Implements [IInterface](T:DefaultDocumentation.AssemblyInfo.IInterface 'DefaultDocumentation.AssemblyInfo.IInterface'), [System.Collections.IEnumerator](T:System.Collections.IEnumerator 'System.Collections.IEnumerator')");

    [Fact]
    public void WriteWhenMethodDocItem() => Test(
        new MethodDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.Get<IMethod>($"M:{typeof(AssemblyInfo).FullName}.{nameof(AssemblyInfo.MoveNext)}"), null),
        "Implements [MoveNext()](M:System.Collections.IEnumerator.MoveNext 'System.Collections.IEnumerator.MoveNext')");

    [Fact]
    public void WriteWhenPropertyDocItem() => Test(
        new PropertyDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.Get<IProperty>($"P:{typeof(AssemblyInfo).FullName}.{nameof(AssemblyInfo.Current)}"), null),
        "Implements [Current](P:System.Collections.IEnumerator.Current 'System.Collections.IEnumerator.Current')");

    [Fact]
    public void WriteWhenEventDocItem() => Test(
        new EventDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.Get<IEvent>($"E:{typeof(AssemblyInfo).FullName}.{nameof(AssemblyInfo.SecondEvent)}"), null),
        "Implements [SecondEvent](E:DefaultDocumentation.AssemblyInfo.IInterface.SecondEvent 'DefaultDocumentation.AssemblyInfo.IInterface.SecondEvent')");

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItem() => Test(
        AssemblyInfo.ExplicitMethodDocItem,
        "Implements [Method()](M:DefaultDocumentation.AssemblyInfo.IInterface.Method 'DefaultDocumentation.AssemblyInfo.IInterface.Method()')");
}
