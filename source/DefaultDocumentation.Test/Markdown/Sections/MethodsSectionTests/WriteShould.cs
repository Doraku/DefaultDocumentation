using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.MethodsSectionTests;

public sealed class WriteShould : BaseSectionTester<MethodsSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
        .Concat(AssemblyInfo.MethodWithReturnDocItem)
        .ToDictionary(item => item.Id);

    protected override IReadOnlyCollection<DocItem> GetItemsWithOwnPage() => [AssemblyInfo.MethodWithReturnDocItem];

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
@"| Methods | |
| :--- | :--- |
| [MoveNext\(\)](MoveNext() 'DefaultDocumentation\.AssemblyInfo\.MoveNext\(\)') | |
");
}
