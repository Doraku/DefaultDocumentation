using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DefinitionSectionTest : ASectionTest<DefinitionSection>
    {
        [Fact]
        public void Name_should_be_Definition() => Check.That(Name).IsEqualTo("Definition");

        [Fact]
        public void Write_should_not_write_When_no_IDefinedDocItem() => Test(
            string.Empty);

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.ClassDocItem,
@"```csharp
public sealed class AssemblyInfo :
DefaultDocumentation.Markdown.AssemblyInfo.IInterface,
System.Collections.IEnumerator
```");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.ClassDocItem,
            w => w.Append("pouet"),
@"pouet

```csharp
public sealed class AssemblyInfo :
DefaultDocumentation.Markdown.AssemblyInfo.IInterface,
System.Collections.IEnumerator
```");

        [Fact]
        public void Write_should_write_When_FieldDocItem() => Test(
            AssemblyInfo.FieldDocItem,
@"```csharp
private static readonly int _field;
```");

        [Fact]
        public void Write_should_write_When_FieldDocItem_and_constant() => Test(
            AssemblyInfo.ConstFieldDocItem,
@"```csharp
private const int _constField = 42;
```");

        [Fact]
        public void Write_should_write_When_PropertyDocItem() => Test(
            AssemblyInfo.PropertyDocItem,
@"```csharp
private static int Property { get; }
```");

        [Fact]
        public void Write_should_write_When_EventDocItem() => Test(
            AssemblyInfo.EventDocItem,
@"```csharp
private static event Action Event;
```");

        [Fact]
        public void Write_should_write_When_ConstructorDocItem() => Test(
            AssemblyInfo.ConstructorDocItem,
@"```csharp
public AssemblyInfo();
```");

        [Fact]
        public void Write_should_write_When_OperatorDocItem() => Test(
            AssemblyInfo.OperatorDocItem,
@"```csharp
public static int operator +(DefaultDocumentation.Markdown.AssemblyInfo _, int __);
```");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_property() => Test(
            AssemblyInfo.ExplicitPropertyDocItem,
@"```csharp
int DefaultDocumentation.Markdown.AssemblyInfo.IInterface.Property { get; set; }
```");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_event() => Test(
            AssemblyInfo.ExplicitEventDocItem,
@"```csharp
event Action DefaultDocumentation.Markdown.AssemblyInfo.IInterface.Event;
```");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem_and_method() => Test(
            AssemblyInfo.ExplicitMethodDocItem,
@"```csharp
void DefaultDocumentation.Markdown.AssemblyInfo.IInterface.Method();
```");

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            AssemblyInfo.MethodWithGenericConstrainsDocItem,
@"```csharp
private static void MethodWithGenericConstrains<T1,T2,T3,T4,T5>()
    where T1 : class, System.Collections.IEnumerator, new()
    where T2 : unmanaged, System.ValueType, System.ValueType
    where T3 : struct, System.ValueType, System.ValueType
    where T4 : notnull
    where T5 : class?;
```");

        [Fact]
        public void Write_should_write_When_EnumDocItem() => Test(
            AssemblyInfo.EnumDocItem,
@"```csharp
private enum AssemblyInfo.Enum
```");

        [Fact]
        public void Write_should_write_When_EnumDocItem_and_non_int32() => Test(
            AssemblyInfo.ShortEnumDocItem,
@"```csharp
private enum AssemblyInfo.ShortEnum : System.Int16
```");

        [Fact]
        public void Write_should_write_When_DelegateDocItem() => Test(
            AssemblyInfo.DelegateDocItem,
@"```csharp
private delegate int AssemblyInfo.DelegateWithReturn();
```");

        [Fact]
        public void Write_should_write_When_TypeDocItem_and_implement() => Test(
            new ClassDocItem(AssemblyInfo.NamespaceDocItem, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(DefinitionSectionTest).FullName}"), null),
@"```csharp
public sealed class DefinitionSectionTest : DefaultDocumentation.Markdown.Sections.ASectionTest<DefaultDocumentation.Markdown.Sections.DefinitionSection>
```");
    }
}
