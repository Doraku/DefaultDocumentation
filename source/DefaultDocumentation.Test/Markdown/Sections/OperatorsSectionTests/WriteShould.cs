using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.OperatorsSectionTests;

public sealed class WriteShould : BaseSectionTester<OperatorsSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
        .Concat(AssemblyInfo.OperatorDocItem)
        .ToDictionary(item => item.Id);

    protected override IUrlFactory[] GetUrlFactories()
    => [
        new DocItemFactory()
    ];

    protected override ISection[] GetSections()
    => [
        new TitleSection()
    ];

    [Fact]
    public void WriteWhenTypeDocItem() => Test(
        AssemblyInfo.ClassDocItem,
@"| Operators | |
| :--- | :--- |
| [operator \+\(AssemblyInfo, int\)](operator +(AssemblyInfo, int) 'DefaultDocumentation\.AssemblyInfo\.op\_Addition\(DefaultDocumentation\.AssemblyInfo, int\)') | |
");
}
