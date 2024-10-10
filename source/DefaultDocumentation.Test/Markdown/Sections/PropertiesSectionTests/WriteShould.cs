using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.PropertiesSectionTests;

public sealed class WriteShould : BaseSectionTester<PropertiesSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
        .Concat(AssemblyInfo.PropertyDocItem)
        .ToDictionary(i => i.Id);

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
@"| Properties | |
| :--- | :--- |
| [Property](Property 'DefaultDocumentation.AssemblyInfo.Property') | |
");
}
