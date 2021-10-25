using System;
using System.Collections;
using System.ComponentModel;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DefinitionSectionTest : ASectionTest<DefinitionSection>, IDisposable
    {
        public void Dispose()
        { }

        private const int _constField = 42;
        private static int _field;

        private static int Property { get; }

        private static event Action Event;

        public static int operator +(DefinitionSectionTest _, int __) => 42;

        private class Enumerator : IEnumerator, INotifyPropertyChanged
        {
            object IEnumerator.Current { get; }

            bool IEnumerator.MoveNext()
            {
                throw new NotSupportedException();
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { } remove { } }
        }

        private static void Method<T1, T2, T3, T4, T5>()
            where T1 : class, IEnumerator, new()
            where T2 : unmanaged
            where T3 : struct
            where T4 : notnull
            where T5 : class?
        { }

        private enum Enum
        { }

        private enum ShortEnum : short
        { }

        private delegate void MyDelegate<in T1, T2>(in T2 t)
            where T2 : class;

        [Fact]
        public void Name_should_be_Definition() => Check.That(Name).IsEqualTo("Definition");

        [Fact]
        public void Write_should_not_write_When_no_IDefinedDocItem() => Test(
            string.Empty);

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DefinitionSectionTest).FullName}"), null),
@"```csharp
public sealed class DefinitionSectionTest : DefaultDocumentation.Markdown.Sections.ASectionTest<DefaultDocumentation.Markdown.Sections.DefinitionSection>,
System.IDisposable
```");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DefinitionSectionTest).FullName}"), null),
            w => w.Append("pouet"),
@"pouet
```csharp
public sealed class DefinitionSectionTest : DefaultDocumentation.Markdown.Sections.ASectionTest<DefaultDocumentation.Markdown.Sections.DefinitionSection>,
System.IDisposable
```");

        [Fact]
        public void Write_should_write_When_FieldDocItem() => Test(
            new FieldDocItem(null, AssemblyInfo.Get<IField>($"F:{typeof(DefinitionSectionTest).FullName}.{nameof(_field)}"), null),
@"```csharp
private static int _field;
```");

        [Fact]
        public void Write_should_write_When_FieldDocItem_and_constant() => Test(
            new FieldDocItem(null, AssemblyInfo.Get<IField>($"F:{typeof(DefinitionSectionTest).FullName}.{nameof(_constField)}"), null),
@"```csharp
private const int _constField = 42;
```");

        [Fact]
        public void Write_should_write_When_PropertyDocItem() => Test(
            new PropertyDocItem(null, AssemblyInfo.Get<IProperty>($"P:{typeof(DefinitionSectionTest).FullName}.{nameof(Property)}"), null),
@"```csharp
private static int Property { get; }
```");

        [Fact]
        public void Write_should_write_When_EventDocItem() => Test(
            new EventDocItem(null, AssemblyInfo.Get<IEvent>($"E:{typeof(DefinitionSectionTest).FullName}.{nameof(Event)}"), null),
@"```csharp
private static event Action Event;
```");

        [Fact]
        public void Write_should_write_When_ConstructorDocItem() => Test(
            new ConstructorDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(DefinitionSectionTest).FullName}.#ctor"), null),
@"```csharp
public DefinitionSectionTest();
```");

        [Fact]
        public void Write_should_write_When_OperatorDocItem() => Test(
            new OperatorDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(DefinitionSectionTest).FullName}.op_Addition({typeof(DefinitionSectionTest).FullName},System.Int32)"), null),
@"```csharp
public static int operator +(DefaultDocumentation.Markdown.Sections.DefinitionSectionTest _, int __);
```");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_property() => Test(
            new ExplicitInterfaceImplementationDocItem(null, AssemblyInfo.Get<IProperty>($"P:{typeof(DefinitionSectionTest).FullName}.Enumerator.System#Collections#IEnumerator#Current"), null),
@"```csharp
object System.Collections.IEnumerator.Current { get; }
```");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_event() => Test(
            new ExplicitInterfaceImplementationDocItem(null, AssemblyInfo.Get<IEvent>($"E:{typeof(DefinitionSectionTest).FullName}.Enumerator.System#ComponentModel#INotifyPropertyChanged#PropertyChanged"), null),
@"```csharp
event PropertyChangedEventHandler System.ComponentModel.INotifyPropertyChanged.PropertyChanged;
```");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_method() => Test(
          new ExplicitInterfaceImplementationDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(DefinitionSectionTest).FullName}.Enumerator.System#Collections#IEnumerator#MoveNext"), null),
@"```csharp
bool System.Collections.IEnumerator.MoveNext();
```");

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            new MethodDocItem(null, AssemblyInfo.Get<IMethod>($"M:{typeof(DefinitionSectionTest).FullName}.Method``5"), null),
@"```csharp
private static void Method<T1,T2,T3,T4,T5>()
    where T1 : class, System.Collections.IEnumerator, new()
    where T2 : unmanaged
    where T3 : struct
    where T4 : notnull
    where T5 : class?;
```");

        [Fact]
        public void Write_should_write_When_EnumDocItem() => Test(
          new EnumDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DefinitionSectionTest).FullName}.{nameof(Enum)}"), null),
@"```csharp
private enum DefinitionSectionTest.Enum
```");

        [Fact]
        public void Write_should_write_When_EnumDocItem_and_non_int32() => Test(
        new EnumDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DefinitionSectionTest).FullName}.{nameof(ShortEnum)}"), null),
@"```csharp
private enum DefinitionSectionTest.ShortEnum : System.Int16
```");

        [Fact]
        public void Write_should_write_When_DelegateDocItem() => Test(
        new DelegateDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DefinitionSectionTest).FullName}.MyDelegate`2"), null),
@"```csharp
private delegate void DefinitionSectionTest.MyDelegate<in T1,T2>(in T2 t)
    where T2 : class;
```");

        [Fact]
        public void Write_should_write_When_TypeDocItem_and_implement() => Test(
            new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DefinitionSectionTest).FullName}.{nameof(Enumerator)}"), null),
@"```csharp
private class DefinitionSectionTest.Enumerator :
System.Collections.IEnumerator,
System.ComponentModel.INotifyPropertyChanged
```");
    }
}
