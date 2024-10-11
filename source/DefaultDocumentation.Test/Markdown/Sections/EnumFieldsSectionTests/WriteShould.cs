using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.EnumFieldsSectionTests;

public sealed class WriteShould : BaseSectionTester<EnumFieldsSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.EnumDocItem.IntoEnumerable<DocItem>()
        .Concat(AssemblyInfo.EnumFieldDocItem)
        .Concat(AssemblyInfo.EnumFieldWithConstantDocItem)
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
    public void WriteWhenEnumDocItem() => Test(
        AssemblyInfo.EnumDocItem,
@"### Fields

<a name='DefaultDocumentation.AssemblyInfo.Enum.Value'></a>

`Value` 0

<a name='DefaultDocumentation.AssemblyInfo.Enum.ValueWithConstant'></a>

`ValueWithConstant` 42");
}
