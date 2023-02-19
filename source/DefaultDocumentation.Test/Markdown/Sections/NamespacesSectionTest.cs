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
    public sealed class NamespacesSectionTest : ASectionTest<NamespacesSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.AssemblyDocItem.IntoEnumerable<DocItem>()
            .Concat(AssemblyInfo.NamespaceDocItem)
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
        public void Name_should_be_Namespaces() => Check.That(Name).IsEqualTo("Namespaces");

        [Fact]
        public void Write_should_write_When_AssemblyDocItem() => Test(
            AssemblyInfo.AssemblyDocItem,
@"| Namespaces | |
| :--- | :--- |
| [DefaultDocumentation](DefaultDocumentation 'DefaultDocumentation') | |
");
    }
}
