#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [DefaultDocumentation\.Models\.Types](../../../../index.md#DefaultDocumentation.Models.Types 'DefaultDocumentation\.Models\.Types').[InterfaceDocItem](index.md 'DefaultDocumentation\.Models\.Types\.InterfaceDocItem')

## InterfaceDocItem\(DocItem, ITypeDefinition, XElement\) Constructor

Initialize a new instance of the [StructDocItem](../StructDocItem/index.md 'DefaultDocumentation\.Models\.Types\.StructDocItem') type\.

```csharp
public InterfaceDocItem(DefaultDocumentation.Models.DocItem parent, ITypeDefinition type, System.Xml.Linq.XElement? documentation);
```
#### Parameters

<a name='DefaultDocumentation.Models.Types.InterfaceDocItem.InterfaceDocItem(DefaultDocumentation.Models.DocItem,ITypeDefinition,System.Xml.Linq.XElement).parent'></a>

`parent` [DocItem](../../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](../../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') parent type or namespace of the interface\.

<a name='DefaultDocumentation.Models.Types.InterfaceDocItem.InterfaceDocItem(DefaultDocumentation.Models.DocItem,ITypeDefinition,System.Xml.Linq.XElement).type'></a>

`type` [ITypeDefinition](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.ITypeDefinition')

The [ITypeDefinition](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.ITypeDefinition') of the interface\.

<a name='DefaultDocumentation.Models.Types.InterfaceDocItem.InterfaceDocItem(DefaultDocumentation.Models.DocItem,ITypeDefinition,System.Xml.Linq.XElement).documentation'></a>

`documentation` [System\.Xml\.Linq\.XElement](https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement 'System\.Xml\.Linq\.XElement')

The [System\.Xml\.Linq\.XElement](https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement 'System\.Xml\.Linq\.XElement') documentation element of the interface\.