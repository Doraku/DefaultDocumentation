using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.NamespacesSectionTests;

public sealed class WriteShould : BaseSectionTester<NamespacesSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.AssemblyDocItem.IntoEnumerable<DocItem>()
        .Concat(AssemblyInfo.NamespaceDocItem)
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
    public void WriteWhenAssemblyDocItem() => Test(
        AssemblyInfo.AssemblyDocItem,
@"| Namespaces | |
| :--- | :--- |
| [DefaultDocumentation](DefaultDocumentation 'DefaultDocumentation') | |
");
}
