﻿using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.FieldsSectionTests;

public sealed class WriteShould : BaseSectionTester<FieldsSection>
{
    protected override IReadOnlyDictionary<string, DocItem> GetItems()
        => AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
        .Concat(AssemblyInfo.FieldDocItem)
        .ToDictionary(item => item.Id);

    protected override IReadOnlyCollection<DocItem> GetItemsWithOwnPage() => [AssemblyInfo.FieldDocItem];

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
@"| Fields | |
| :--- | :--- |
| [\_field](_field 'DefaultDocumentation\.AssemblyInfo\.\_field') | |
");
}
