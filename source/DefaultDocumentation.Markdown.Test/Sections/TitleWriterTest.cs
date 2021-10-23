using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class TitleWriterTest : ASectionWriterTest<TitleWriter>, TitleWriterTest.IInterface
    {
        private sealed class DummyDocItem : DocItem
        {
            public override GeneratedPages Page => GeneratedPages.Classes;

            public DummyDocItem()
                : base(null, "dummy", "dummy", "dummy", null)
            { }
        }

        private interface IInterface
        {
            int Property { get; set; }

            void Method();
        }

        private enum Enum
        {
            Value1,
            Value2 = 42
        }

        private static event Action Event;

#pragma warning disable CS0649
        private static readonly int _field;
#pragma warning restore CS0649

        private static int Property { get; }

        int IInterface.Property { get; set; }

        void IInterface.Method()
        { }

        private static void Method<T>(T _)
        { }

        [SuppressMessage("Style", "IDE0060:Remove unused parameter")]
        public static int operator +(TitleWriterTest _, int __) => 42;

        private static readonly ClassDocItem _typeDocItem = new(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(TitleWriterTest).FullName}"), null);
        private static readonly EnumDocItem _enumDocItem = new(_typeDocItem, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(TitleWriterTest).FullName}.Enum"), null);
        private static readonly MethodDocItem _methodDocItem = new(_typeDocItem, AssemblyInfo.Get<IMethod>($"M:{typeof(TitleWriterTest).FullName}.{nameof(Method)}``1(``0)"), null);

        protected override GeneratedPages GetGeneratedPages() =>
            GeneratedPages.Assembly
            | GeneratedPages.Namespaces
            | GeneratedPages.Types
            | GeneratedPages.Members;

        [Fact]
        public void Name_should_be_Title() => Check.That(Name).IsEqualTo("Title");

        [Fact]
        public void Write_should_not_write_When_unknown_DocItem() => Test(
            new DummyDocItem(),
            string.Empty);

        [Fact]
        public void Write_should_write_When_AssemblyDocItem() => Test(
            new AssemblyDocItem("dummy", "dummy", null),
            "## dummy Assembly");

        [Fact]
        public void Write_should_write_When_NamespaceDocItem() => Test(
            new NamespaceDocItem(null, "dummy", null),
            "## dummy Namespace");

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            _typeDocItem,
            "## TitleWriterTest Class");

        [Fact]
        public void Write_should_write_When_ConstructorDocItem() => Test(
            new ConstructorDocItem(_typeDocItem, AssemblyInfo.Get<IMethod>($"M:{typeof(TitleWriterTest).FullName}.#ctor"), null),
            "## TitleWriterTest() Constructor");

        [Fact]
        public void Write_should_write_When_EventDocItem() => Test(
            new EventDocItem(_typeDocItem, AssemblyInfo.Get<IEvent>($"E:{typeof(TitleWriterTest).FullName}.{nameof(Event)}"), null),
            "## TitleWriterTest.Event Event");

        [Fact]
        public void Write_should_write_When_FieldDocItem() => Test(
            new FieldDocItem(_typeDocItem, AssemblyInfo.Get<IField>($"F:{typeof(TitleWriterTest).FullName}.{nameof(_field)}"), null),
            "## TitleWriterTest._field Field");

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            _methodDocItem,
            "## TitleWriterTest.Method&lt;T&gt;(T) Method");

        [Fact]
        public void Write_should_write_When_OperatorDocItem() => Test(
            new OperatorDocItem(_typeDocItem, AssemblyInfo.Get<IMethod>($"M:{typeof(TitleWriterTest).FullName}.op_Addition({typeof(TitleWriterTest).FullName},System.Int32)"), null),
            "## TitleWriterTest.operator +(TitleWriterTest, int) Operator");

        [Fact]
        public void Write_should_write_When_PropertyDocItem() => Test(
            new PropertyDocItem(_typeDocItem, AssemblyInfo.Get<IProperty>($"P:{typeof(TitleWriterTest).FullName}.{nameof(Property)}"), null),
            "## TitleWriterTest.Property Property");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_property() => Test(
            new ExplicitInterfaceImplementationDocItem(_typeDocItem, AssemblyInfo.Get<IProperty>($"P:{typeof(TitleWriterTest).FullName}.DefaultDocumentation#Markdown#Sections#TitleWriterTest#IInterface#Property"), null),
            "## TitleWriterTest.DefaultDocumentation.Markdown.Sections.TitleWriterTest.IInterface.Property Property");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_method() => Test(
            new ExplicitInterfaceImplementationDocItem(_typeDocItem, AssemblyInfo.Get<IMethod>($"M:{typeof(TitleWriterTest).FullName}.DefaultDocumentation#Markdown#Sections#TitleWriterTest#IInterface#Method"), null),
            "## TitleWriterTest.DefaultDocumentation.Markdown.Sections.TitleWriterTest.IInterface.Method() Method");

        [Fact]
        public void Write_should_write_When_EnumFieldDocItem() => Test(
            new EnumFieldDocItem(_enumDocItem, AssemblyInfo.Get<IField>($"F:{typeof(TitleWriterTest).FullName}.Enum.{nameof(Enum.Value1)}"), null),
@"<a name='DefaultDocumentation_Markdown_Sections_TitleWriterTest_Enum_Value1'></a>
`Value1` 0");

        [Fact]
        public void Write_should_write_When_EnumFieldDocItem_and_constant_value() => Test(
            new EnumFieldDocItem(_enumDocItem, AssemblyInfo.Get<IField>($"F:{typeof(TitleWriterTest).FullName}.Enum.{nameof(Enum.Value2)}"), null),
@"<a name='DefaultDocumentation_Markdown_Sections_TitleWriterTest_Enum_Value2'></a>
`Value2` 42");

        [Fact]
        public void Write_should_write_When_ParameterDocItem() => Test(
            _methodDocItem.TypeParameters.Single(),
@"<a name='DefaultDocumentation_Markdown_Sections_TitleWriterTest_Method_T_(T)_T'></a>
`T`");

        [Fact]
        public void Write_should_write_When_TypeParameterDocItem() => Test(
            _methodDocItem.Parameters.Single(),
@"<a name='DefaultDocumentation_Markdown_Sections_TitleWriterTest_Method_T_(T)__'></a>
`_` [T](DefaultDocumentation_Markdown_Sections_TitleWriterTest_Method_T_(T).md#DefaultDocumentation_Markdown_Sections_TitleWriterTest_Method_T_(T)_T 'DefaultDocumentation.Markdown.Sections.TitleWriterTest.Method&lt;T&gt;(T).T')");
    }
}
