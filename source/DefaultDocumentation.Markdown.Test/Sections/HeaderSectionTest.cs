using System.Collections.Generic;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class HeaderSectionTest : ASectionTest<HeaderSection>
    {
        private static readonly AssemblyDocItem _assemblyItem = new("dummy", "dummy", null);
        private static readonly NamespaceDocItem _namespaceItem = new(_assemblyItem, "dummy", null);
        private static readonly TypeDocItem _typeItem = new ClassDocItem(_namespaceItem, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(HeaderSectionTest).FullName}"), null);

        private static void Method()
        { }

        protected override GeneratedPages GetGeneratedPages() =>
            GeneratedPages.Assembly
            | GeneratedPages.Namespaces
            | GeneratedPages.Types
            | GeneratedPages.Members;

        protected override IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>
        {
            [_assemblyItem.Id] = _assemblyItem
        };

        [Fact]
        public void Name_should_be_Header() => Check.That(Name).IsEqualTo("Header");

        [Fact]
        public void Write_should_not_write_When_not_PageItem() => Test(
            w => w.SetCurrentItem(_namespaceItem),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new MethodDocItem(_typeItem, AssemblyInfo.Get<IMethod>($"M:{typeof(HeaderSectionTest).FullName}.{nameof(Method)}"), null),
@"#### [dummy](dummy.md 'dummy')
### [dummy](dummy.md 'dummy').[HeaderSectionTest](DefaultDocumentation_Markdown_Sections_HeaderSectionTest.md 'DefaultDocumentation.Markdown.Sections.HeaderSectionTest')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new MethodDocItem(_typeItem, AssemblyInfo.Get<IMethod>($"M:{typeof(HeaderSectionTest).FullName}.{nameof(Method)}"), null),
            w => w.Append("pouet"),
@"pouet
#### [dummy](dummy.md 'dummy')
### [dummy](dummy.md 'dummy').[HeaderSectionTest](DefaultDocumentation_Markdown_Sections_HeaderSectionTest.md 'DefaultDocumentation.Markdown.Sections.HeaderSectionTest')");
    }
}
