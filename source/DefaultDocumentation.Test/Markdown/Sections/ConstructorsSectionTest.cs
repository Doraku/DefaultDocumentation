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
    public sealed class ConstructorsSectionTest : ASectionTest<ConstructorsSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
            .Concat(AssemblyInfo.ConstructorDocItem)
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
        public void Name_should_be_Constructors() => Check.That(Name).IsEqualTo("Constructors");

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.ClassDocItem,
@"| Constructors | |
| :--- | :--- |
| [AssemblyInfo()](AssemblyInfo() 'DefaultDocumentation.AssemblyInfo.AssemblyInfo()') | |
");
    }
}
