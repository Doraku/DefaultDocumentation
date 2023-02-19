using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class EnumFieldsSectionTest : ASectionTest<EnumFieldsSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.EnumDocItem.IntoEnumerable<DocItem>()
            .Concat(AssemblyInfo.EnumFieldDocItem)
            .Concat(AssemblyInfo.EnumFieldWithConstantDocItem)
            .ToDictionary(i => i.Id);

        protected override IUrlFactory[] GetUrlFactories() => new IUrlFactory[]
        {
            new DocItemFactory()
        };

        protected override ISection[] GetSections() => new ISection[]
        {
            new TitleSection()
        };

        [Fact]
        public void Name_should_be_EnumFields() => Check.That(Name).IsEqualTo("EnumFields");

        [Fact]
        public void Write_should_write_When_EnumDocItem() => Test(
            AssemblyInfo.EnumDocItem,
@"### Fields

<a name='DefaultDocumentation.AssemblyInfo.Enum.Value'></a>

`Value` 0

<a name='DefaultDocumentation.AssemblyInfo.Enum.ValueWithConstant'></a>

`ValueWithConstant` 42");
    }
}
