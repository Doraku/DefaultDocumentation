#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models.Types](index.md#DefaultDocumentation.Models.Types 'DefaultDocumentation.Models.Types').[EnumDocItem](EnumDocItem.md 'DefaultDocumentation.Models.Types.EnumDocItem')

## EnumDocItem(DocItem, ITypeDefinition, XElement) Constructor

Initialize a new instance of the [StructDocItem](StructDocItem.md 'DefaultDocumentation.Models.Types.StructDocItem') type.

```csharp
public EnumDocItem(DefaultDocumentation.Models.DocItem parent, ITypeDefinition type, System.Xml.Linq.XElement? documentation);
```
#### Parameters

<a name='DefaultDocumentation.Models.Types.EnumDocItem.EnumDocItem(DefaultDocumentation.Models.DocItem,ITypeDefinition,System.Xml.Linq.XElement).parent'></a>

`parent` [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') parent type or namespace of the enum.

<a name='DefaultDocumentation.Models.Types.EnumDocItem.EnumDocItem(DefaultDocumentation.Models.DocItem,ITypeDefinition,System.Xml.Linq.XElement).type'></a>

`type` [ICSharpCode.Decompiler.TypeSystem.ITypeDefinition](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.ITypeDefinition 'ICSharpCode.Decompiler.TypeSystem.ITypeDefinition')

The [ITypeDefinition](https://github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.ITypeDefinition') of the enum.

<a name='DefaultDocumentation.Models.Types.EnumDocItem.EnumDocItem(DefaultDocumentation.Models.DocItem,ITypeDefinition,System.Xml.Linq.XElement).documentation'></a>

`documentation` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') documentation element of the enum.