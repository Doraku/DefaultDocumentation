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
    public sealed class ClassesSectionTest : ASectionTest<ClassesSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.NamespaceDocItem.IntoEnumerable<DocItem>()
            .Concat(AssemblyInfo.ClassDocItem)
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
        public void Name_should_be_Classes() => Check.That(Name).IsEqualTo("Classes");

        [Fact]
        public void Write_should_write_When_NamespaceDocItem() => Test(
            AssemblyInfo.NamespaceDocItem,
@"| Classes | |
| :--- | :--- |
| [AssemblyInfo](AssemblyInfo 'DefaultDocumentation.AssemblyInfo') | |
");
    }
}
