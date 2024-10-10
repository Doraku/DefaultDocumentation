using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ExplicitInterfaceImplementationsSectionTests;

public sealed class WriteShould : BaseSectionTester<ExplicitInterfaceImplementationsSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
        .Concat(AssemblyInfo.ExplicitPropertyDocItem)
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
@"| Explicit Interface Implementations | |
| :--- | :--- |
| [DefaultDocumentation.AssemblyInfo.IInterface.Property](DefaultDocumentation.AssemblyInfo.IInterface.Property 'DefaultDocumentation.AssemblyInfo.DefaultDocumentation.AssemblyInfo.IInterface.Property') | |
");
}
