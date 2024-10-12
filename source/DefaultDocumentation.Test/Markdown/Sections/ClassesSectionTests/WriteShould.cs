using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ClassesSectionTests;

public sealed class WriteShould : BaseSectionTester<ClassesSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.NamespaceDocItem.IntoEnumerable<DocItem>()
        .Concat(AssemblyInfo.ClassDocItem)
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
    public void WriteWhenNamespaceDocItem() => Test(
        AssemblyInfo.NamespaceDocItem,
@"| Classes | |
| :--- | :--- |
| [AssemblyInfo](AssemblyInfo 'DefaultDocumentation\.AssemblyInfo') | |
");
}
