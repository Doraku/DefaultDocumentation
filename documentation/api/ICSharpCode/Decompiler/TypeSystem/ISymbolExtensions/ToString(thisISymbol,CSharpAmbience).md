#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [ICSharpCode\.Decompiler\.TypeSystem](../../../../index.md#ICSharpCode.Decompiler.TypeSystem 'ICSharpCode\.Decompiler\.TypeSystem').[ISymbolExtensions](index.md 'ICSharpCode\.Decompiler\.TypeSystem\.ISymbolExtensions')

## ISymbolExtensions\.ToString\(this ISymbol, CSharpAmbience\) Method

Converts a [ICSharpCode\.Decompiler\.TypeSystem\.ISymbol](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.ISymbol 'ICSharpCode\.Decompiler\.TypeSystem\.ISymbol') into its string representation using the provided [ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.CSharp.OutputVisitor.CSharpAmbience 'ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience')\.

```csharp
public static string ToString(this ISymbol symbol, CSharpAmbience ambience);
```
#### Parameters

<a name='ICSharpCode.Decompiler.TypeSystem.ISymbolExtensions.ToString(thisISymbol,CSharpAmbience).symbol'></a>

`symbol` [ICSharpCode\.Decompiler\.TypeSystem\.ISymbol](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.ISymbol 'ICSharpCode\.Decompiler\.TypeSystem\.ISymbol')

The symbol to convert into its string representation\.

<a name='ICSharpCode.Decompiler.TypeSystem.ISymbolExtensions.ToString(thisISymbol,CSharpAmbience).ambience'></a>

`ambience` [ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.CSharp.OutputVisitor.CSharpAmbience 'ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience')

The [ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.CSharp.OutputVisitor.CSharpAmbience 'ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience') to use\.

#### Returns
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')