using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.DerivedSectionTests;

public sealed class WriteShould : BaseSectionTester<DerivedSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[]
    {
        AssemblyInfo.ClassDocItem,
        AssemblyInfo.StructDocItem
    }.ToDictionary(item => item.Id);

    [Fact]
    public void NotWriteWhenNotTypeDocItem() => Test(string.Empty);

    [Fact]
    public void Write() => Test(
        AssemblyInfo.InterfaceDocItem,
@"Derived  
↳ [AssemblyInfo](T:DefaultDocumentation.AssemblyInfo 'DefaultDocumentation\.AssemblyInfo')  
↳ [Struct](T:DefaultDocumentation.AssemblyInfo.Struct 'DefaultDocumentation\.AssemblyInfo\.Struct')");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        AssemblyInfo.InterfaceDocItem,
        w => w.Append("pouet"),
@"pouet

Derived  
↳ [AssemblyInfo](T:DefaultDocumentation.AssemblyInfo 'DefaultDocumentation\.AssemblyInfo')  
↳ [Struct](T:DefaultDocumentation.AssemblyInfo.Struct 'DefaultDocumentation\.AssemblyInfo\.Struct')");
}
