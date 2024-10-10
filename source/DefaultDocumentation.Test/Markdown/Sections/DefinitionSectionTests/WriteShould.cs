using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.DefinitionSectionTests;

public sealed class WriteShould : BaseSectionTester<DefinitionSection>
{
    [Fact]
    public void NotWriteWhenNoIDefinedDocItem() => Test(
        string.Empty);

    [Fact]
    public void WriteWhenTypeDocItem() => Test(
        AssemblyInfo.ClassDocItem,
@"```csharp
public sealed class AssemblyInfo : DefaultDocumentation.AssemblyInfo.IInterface, System.Collections.IEnumerator
```");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        AssemblyInfo.ClassDocItem,
        w => w.Append("pouet"),
@"pouet

```csharp
public sealed class AssemblyInfo : DefaultDocumentation.AssemblyInfo.IInterface, System.Collections.IEnumerator
```");

    [Fact]
    public void WriteWhenFieldDocItem() => Test(
        AssemblyInfo.FieldDocItem,
@"```csharp
private static readonly int _field;
```");

    [Fact]
    public void WriteWhenFieldDocItemAndConstant() => Test(
        AssemblyInfo.ConstFieldDocItem,
@"```csharp
private const int _constField = 42;
```");

    [Fact]
    public void WriteWhenFieldDocItemAndConstantString() => Test(
        AssemblyInfo.ConstStringFieldDocItem,
"""
```csharp
private const string _constStringField = "string";
```
""");

    [Fact]
    public void WriteWhenFieldDocItemAndConstantChar() => Test(
        AssemblyInfo.ConstCharFieldDocItem,
@"```csharp
private const char _constCharField = 'e';
```");

    [Fact]
    public void WriteWhenPropertyDocItem() => Test(
        AssemblyInfo.PropertyDocItem,
@"```csharp
public static int Property { get; }
```");

    [Fact]
    public void WriteWhenPropertyDocItemWithPrivateSet() => Test(
        AssemblyInfo.PropertyPrivateSetDocItem,
@"```csharp
public static int PropertyPrivateSet { get; }
```");

    [Fact]
    public void WriteWhenPropertyDocItemWithInternalSet() => Test(
        AssemblyInfo.PropertyInternalSetDocItem,
@"```csharp
public static int PropertyInternalSet { get; }
```");

    [Fact]
    public void WriteWhenPropertyDocItemWithInit() => Test(
        AssemblyInfo.RecordPropertyDocItem,
@"```csharp
public int Property { get; init; }
```");

    [Fact]
    public void WriteWhenEventDocItem() => Test(
        AssemblyInfo.EventDocItem,
@"```csharp
private static event Action? Event;
```");

    [Fact]
    public void WriteWhenConstructorDocItem() => Test(
        AssemblyInfo.ConstructorDocItem,
@"```csharp
public AssemblyInfo();
```");

    [Fact]
    public void WriteWhenOperatorDocItem() => Test(
        AssemblyInfo.OperatorDocItem,
@"```csharp
public static int operator +(DefaultDocumentation.AssemblyInfo _, int __);
```");

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItemAndProperty() => Test(
        AssemblyInfo.ExplicitPropertyDocItem,
@"```csharp
int DefaultDocumentation.AssemblyInfo.IInterface.Property { get; set; }
```");

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItemAndEvent() => Test(
        AssemblyInfo.ExplicitEventDocItem,
@"```csharp
event Action DefaultDocumentation.AssemblyInfo.IInterface.Event;
```");

    [Fact]
    public void WriteWhenExplicitInterfaceImplementationDocItemAndMethod() => Test(
        AssemblyInfo.ExplicitMethodDocItem,
@"```csharp
void DefaultDocumentation.AssemblyInfo.IInterface.Method();
```");

    [Fact]
    public void WriteWhenMethodDocItem() => Test(
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
    public void WriteWhenEnumDocItem() => Test(
        AssemblyInfo.EnumDocItem,
@"```csharp
private enum AssemblyInfo.Enum
```");

    [Fact]
    public void WriteWhenEnumDocItemAndNonInt32() => Test(
        AssemblyInfo.ShortEnumDocItem,
@"```csharp
private enum AssemblyInfo.ShortEnum : System.Int16
```");

    [Fact]
    public void WriteWhenDelegateDocItem() => Test(
        AssemblyInfo.DelegateDocItem,
@"```csharp
private delegate int AssemblyInfo.DelegateWithReturn();
```");

    [Fact]
    public void WriteWhenTypeDocItemAndImplement() => Test(
        new ClassDocItem(AssemblyInfo.NamespaceDocItem, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(WriteShould).FullName}"), null),
@"```csharp
public sealed class WriteShould : DefaultDocumentation.Markdown.Sections.BaseSectionTester<DefaultDocumentation.Markdown.Sections.DefinitionSection>
```");

    [Fact]
    public void WriteWhenTypeDocItemForRecordClass() => Test(
        AssemblyInfo.ClassRecordDocItem,
@"```csharp
public sealed record AssemblyInfo.ClassRecord : System.IEquatable<DefaultDocumentation.AssemblyInfo.ClassRecord>
```");

    [Fact]
    public void WriteWhenTypeDocItemForRecordStruct() => Test(
      AssemblyInfo.StructRecordDocItem,
@"```csharp
public readonly record struct AssemblyInfo.StructRecord : System.IEquatable<DefaultDocumentation.AssemblyInfo.StructRecord>
```");
}
