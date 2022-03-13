using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ParametersSectionTest : ASectionTest<ParametersSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.MethodWithParameterDocItem.Parameters.AsEnumerable<DocItem>()
            .Concat(AssemblyInfo.OperatorDocItem.Parameters)
            .Concat(Enumerable.Repeat(AssemblyInfo.ClassDocItem, 1))
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
        public void Name_should_be_Parameters() => Check.That(Name).IsEqualTo("Parameters");

        [Fact]
        public void Write_should_not_write_When_no_IParameterizedDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.MethodWithParameterDocItem,
@"#### Parameters

<a name='DefaultDocumentation.AssemblyInfo.MethodWithParameter(int).parameter'></a>

`parameter` System.Int32");

        [Fact]
        public void Write_should_write_When_ConstructorDocItem() => Test(
            AssemblyInfo.ConstructorDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem() => Test(
            AssemblyInfo.ExplicitMethodDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_OperatorDocItem() => Test(
            AssemblyInfo.OperatorDocItem,
@"#### Parameters

<a name='DefaultDocumentation.AssemblyInfo.op_Addition(DefaultDocumentation.AssemblyInfo, int)._'></a>

`_` [AssemblyInfo](AssemblyInfo 'DefaultDocumentation.AssemblyInfo')

<a name='DefaultDocumentation.AssemblyInfo.op_Addition(DefaultDocumentation.AssemblyInfo, int).__'></a>

`__` System.Int32");

        [Fact]
        public void Write_should_write_When_PropertyDocItem() => Test(
            AssemblyInfo.PropertyDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write_When_DelegateDocItem() => Test(
            AssemblyInfo.DelegateDocItem,
            string.Empty);
    }
}
