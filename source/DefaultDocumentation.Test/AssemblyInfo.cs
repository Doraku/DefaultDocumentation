using System;
using System.Collections;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Resolver;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1003:Use generic event handler instances", Justification = "for test purpose")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "for test purpose")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "for test purpose")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "for test purpose")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0251:Make member 'readonly'", Justification = "for test purpose")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1163:Unused parameter", Justification = "for test purpose")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1170:Use read-only auto-implemented property", Justification = "for test purpose")]
#pragma warning disable CS0067, CS0649
public sealed class AssemblyInfo : AssemblyInfo.IInterface, IEnumerator
{
    private delegate int DelegateWithReturn();

    private enum Enum
    {
        Value,
        ValueWithConstant = 42,
        AnotherValue
    }

    private enum ShortEnum : short
    { }

    private struct Struct : IInterface
    {
        public int Property { get; set; }

        public event Action Event;
        public event Action SecondEvent;

        public void Method()
        { }
    }

    public interface IInterface
    {
        int Property { get; set; }

        void Method();

        event Action Event;

        event Action SecondEvent;
    }

    private static class ClassWithTypeParameter<T>;

    public sealed record ClassRecord(
        int Property);

    public readonly record struct StructRecord;

    private static event Action? Event;

    private const int _constField = 42;

    private const string _constStringField = "string";

    private const char _constCharField = 'e';

    private static readonly int _field;

    public static int Property { get; }

    public static int PropertyPrivateSet { get; private set; }

    public static int PropertyInternalSet { get; internal set; }

    private static void MethodWithParameter(int parameter)
    { }

    private static void MethodWithGenericConstrains<T1, T2, T3, T4, T5>()
        where T1 : class, IEnumerator, new()
        where T2 : unmanaged
        where T3 : struct
        where T4 : notnull
        where T5 : class?
    { }

    public object? Current { get; }

    public bool MoveNext() => false;

    public void Reset()
    { }

    int IInterface.Property { get; set; }

    public event Action? SecondEvent;

    event Action IInterface.Event
    {
        add
        { }

        remove
        { }
    }

    void IInterface.Method()
    { }

    public static int operator +(AssemblyInfo _, int __) => 42;

    private static readonly CSharpDecompiler _decompiler = new(typeof(AssemblyInfo).Assembly.Location, new DecompilerSettings { ThrowOnAssemblyResolveErrors = false });
    private static readonly CSharpResolver _resolver = new(_decompiler.TypeSystem);

    public static T Get<T>(string id) => (T)IdStringProvider.FindEntity(id.Replace('+', '.'), _resolver);

    public static readonly AssemblyDocItem AssemblyDocItem = new("Test", "Test", null);

    public static readonly NamespaceDocItem NamespaceDocItem = new(AssemblyDocItem, typeof(AssemblyInfo).Namespace!, null);

    public static readonly ClassDocItem ClassDocItem = new(NamespaceDocItem, Get<ITypeDefinition>($"T:{typeof(AssemblyInfo).FullName}"), null);
    public static readonly EventDocItem EventDocItem = new(ClassDocItem, Get<IEvent>($"E:{typeof(AssemblyInfo).FullName}.{nameof(Event)}"), null);
    public static readonly FieldDocItem ConstFieldDocItem = new(ClassDocItem, Get<IField>($"F:{typeof(AssemblyInfo).FullName}.{nameof(_constField)}"), null);
    public static readonly FieldDocItem ConstStringFieldDocItem = new(ClassDocItem, Get<IField>($"F:{typeof(AssemblyInfo).FullName}.{nameof(_constStringField)}"), null);
    public static readonly FieldDocItem ConstCharFieldDocItem = new(ClassDocItem, Get<IField>($"F:{typeof(AssemblyInfo).FullName}.{nameof(_constCharField)}"), null);
    public static readonly FieldDocItem FieldDocItem = new(ClassDocItem, Get<IField>($"F:{typeof(AssemblyInfo).FullName}.{nameof(_field)}"), null);
    public static readonly PropertyDocItem PropertyDocItem = new(ClassDocItem, Get<IProperty>($"P:{typeof(AssemblyInfo).FullName}.{nameof(Property)}"), null);
    public static readonly PropertyDocItem PropertyPrivateSetDocItem = new(ClassDocItem, Get<IProperty>($"P:{typeof(AssemblyInfo).FullName}.{nameof(PropertyPrivateSet)}"), null);
    public static readonly PropertyDocItem PropertyInternalSetDocItem = new(ClassDocItem, Get<IProperty>($"P:{typeof(AssemblyInfo).FullName}.{nameof(PropertyInternalSet)}"), null);
    public static readonly MethodDocItem MethodWithGenericConstrainsDocItem = new(ClassDocItem, Get<IMethod>($"M:{typeof(AssemblyInfo).FullName}.{nameof(MethodWithGenericConstrains)}``5"), null);
    public static readonly MethodDocItem MethodWithParameterDocItem = new(ClassDocItem, Get<IMethod>($"M:{typeof(AssemblyInfo).FullName}.{nameof(MethodWithParameter)}({typeof(int).FullName})"), null);
    public static readonly MethodDocItem MethodWithReturnDocItem = new(ClassDocItem, Get<IMethod>($"M:{typeof(AssemblyInfo).FullName}.{nameof(MoveNext)}"), null);
    public static readonly ConstructorDocItem ConstructorDocItem = new(ClassDocItem, Get<IMethod>($"M:{typeof(AssemblyInfo).FullName}.#ctor"), null);
    public static readonly OperatorDocItem OperatorDocItem = new(ClassDocItem, Get<IMethod>($"M:{typeof(AssemblyInfo).FullName}.op_Addition({typeof(AssemblyInfo).FullName},System.Int32)"), null);
    public static readonly ExplicitInterfaceImplementationDocItem ExplicitEventDocItem = new(ClassDocItem, Get<IEvent>($"E:{typeof(AssemblyInfo).FullName}.{typeof(IInterface).FullName!.Replace('.', '#').Replace('+', '#')}#{nameof(IInterface.Event)}"), null);
    public static readonly ExplicitInterfaceImplementationDocItem ExplicitPropertyDocItem = new(ClassDocItem, Get<IProperty>($"P:{typeof(AssemblyInfo).FullName}.{typeof(IInterface).FullName!.Replace('.', '#').Replace('+', '#')}#{nameof(IInterface.Property)}"), null);
    public static readonly ExplicitInterfaceImplementationDocItem ExplicitMethodDocItem = new(ClassDocItem, Get<IMethod>($"M:{typeof(AssemblyInfo).FullName}.{typeof(IInterface).FullName!.Replace('.', '#').Replace('+', '#')}#{nameof(IInterface.Method)}"), null);

    public static readonly EnumDocItem EnumDocItem = new(ClassDocItem, Get<ITypeDefinition>($"T:{typeof(Enum).FullName}"), null);
    public static readonly EnumFieldDocItem EnumFieldDocItem = new(EnumDocItem, Get<IField>($"F:{typeof(Enum).FullName}.{nameof(Enum.Value)}"), null);
    public static readonly EnumFieldDocItem EnumFieldWithConstantDocItem = new(EnumDocItem, Get<IField>($"F:{typeof(Enum).FullName}.{nameof(Enum.ValueWithConstant)}"), null);
    public static readonly EnumFieldDocItem AnotherEnumFieldDocItem = new(EnumDocItem, Get<IField>($"F:{typeof(Enum).FullName}.{nameof(Enum.AnotherValue)}"), null);

    public static readonly EnumDocItem ShortEnumDocItem = new(ClassDocItem, Get<ITypeDefinition>($"T:{typeof(ShortEnum).FullName}"), null);

    public static readonly DelegateDocItem DelegateDocItem = new(ClassDocItem, Get<ITypeDefinition>($"T:{typeof(DelegateWithReturn).FullName}"), null);

    public static readonly StructDocItem StructDocItem = new(ClassDocItem, Get<ITypeDefinition>($"T:{typeof(Struct).FullName}"), null);

    public static readonly ClassDocItem ClassWithTypeParameterDocItem = new(ClassDocItem, Get<ITypeDefinition>($"T:{typeof(AssemblyInfo).FullName}.ClassWithTypeParameter`1"), null);

    public static readonly InterfaceDocItem InterfaceDocItem = new(ClassDocItem, Get<ITypeDefinition>($"T:{typeof(IInterface).FullName}"), null);
    public static readonly MethodDocItem InterfaceMethodDocItem = new(InterfaceDocItem, Get<IMethod>($"M:{typeof(IInterface).FullName}.{nameof(IInterface.Method)}"), null);
    public static readonly EventDocItem InterfaceEventDocItem = new(InterfaceDocItem, Get<IEvent>($"E:{typeof(IInterface).FullName}.{nameof(IInterface.SecondEvent)}"), null);

    public static readonly ClassDocItem ClassRecordDocItem = new(NamespaceDocItem, Get<ITypeDefinition>($"T:{typeof(AssemblyInfo).FullName}.{nameof(ClassRecord)}"), null);
    public static readonly PropertyDocItem RecordPropertyDocItem = new(ClassRecordDocItem, Get<IProperty>($"P:{typeof(AssemblyInfo).FullName}.{nameof(ClassRecord)}.{nameof(ClassRecord.Property)}"), null);

    public static readonly StructDocItem StructRecordDocItem = new(NamespaceDocItem, Get<ITypeDefinition>($"T:{typeof(AssemblyInfo).FullName}.{nameof(StructRecord)}"), null);
}
