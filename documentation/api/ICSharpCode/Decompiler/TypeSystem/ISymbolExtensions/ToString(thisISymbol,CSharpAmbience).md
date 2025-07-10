#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [ICSharpCode\.Decompiler\.TypeSystem](../../../../index.md#ICSharpCode.Decompiler.TypeSystem 'ICSharpCode\.Decompiler\.TypeSystem').[ISymbolExtensions](index.md 'ICSharpCode\.Decompiler\.TypeSystem\.ISymbolExtensions')

## ISymbolExtensions\.ToString\(this ISymbol, CSharpAmbience\) Method

Converts a [ICSharpCode\.Decompiler\.TypeSystem\.ISymbol](https://learn.microsoft.com/en-us/dotnet/api/icsharpcode.decompiler.typesystem.isymbol 'ICSharpCode\.Decompiler\.TypeSystem\.ISymbol') into its string representation using the provided [ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience](https://learn.microsoft.com/en-us/dotnet/api/icsharpcode.decompiler.csharp.outputvisitor.csharpambience 'ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience')\.

```csharp
public static string ToString(this ISymbol symbol, CSharpAmbience ambience);
```
#### Parameters

<a name='ICSharpCode.Decompiler.TypeSystem.ISymbolExtensions.ToString(thisISymbol,CSharpAmbience).symbol'></a>

`symbol` [ICSharpCode\.Decompiler\.TypeSystem\.ISymbol](https://learn.microsoft.com/en-us/dotnet/api/icsharpcode.decompiler.typesystem.isymbol 'ICSharpCode\.Decompiler\.TypeSystem\.ISymbol')

The symbol to convert into its string representation\.

<a name='ICSharpCode.Decompiler.TypeSystem.ISymbolExtensions.ToString(thisISymbol,CSharpAmbience).ambience'></a>

`ambience` [ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience](https://learn.microsoft.com/en-us/dotnet/api/icsharpcode.decompiler.csharp.outputvisitor.csharpambience 'ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience')

The [ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience](https://learn.microsoft.com/en-us/dotnet/api/icsharpcode.decompiler.csharp.outputvisitor.csharpambience 'ICSharpCode\.Decompiler\.CSharp\.OutputVisitor\.CSharpAmbience') to use\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')