using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DerivedSectionTest : ASectionTest<DerivedSection>
    {
        private interface IInterface
        { }

        private class Class1 : IInterface
        { }

        private class Class2 : IInterface
        { }

        protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[]
        {
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DerivedSectionTest).FullName}.Class1"), null),
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DerivedSectionTest).FullName}.Class2"), null)
        }.ToDictionary(i => i.Id);

        [Fact]
        public void Name_should_be_Derived() => Check.That(Name).IsEqualTo("Derived");

        [Fact]
        public void Write_should_not_write_When_not_TypeDocItem() => Test(
            new AssemblyDocItem("dummy", "dummy", null),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new InterfaceDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DerivedSectionTest).FullName}.IInterface"), null),
@"Derived  
&#8627; [Class1](DefaultDocumentation_Markdown_Sections_DerivedSectionTest_Class1.md 'DefaultDocumentation.Markdown.Sections.DerivedSectionTest.Class1')  
&#8627; [Class2](DefaultDocumentation_Markdown_Sections_DerivedSectionTest_Class2.md 'DefaultDocumentation.Markdown.Sections.DerivedSectionTest.Class2')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new InterfaceDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DerivedSectionTest).FullName}.IInterface"), null),
            w => w.Append("pouet"),
@"pouet

Derived  
&#8627; [Class1](DefaultDocumentation_Markdown_Sections_DerivedSectionTest_Class1.md 'DefaultDocumentation.Markdown.Sections.DerivedSectionTest.Class1')  
&#8627; [Class2](DefaultDocumentation_Markdown_Sections_DerivedSectionTest_Class2.md 'DefaultDocumentation.Markdown.Sections.DerivedSectionTest.Class2')");
    }
}
