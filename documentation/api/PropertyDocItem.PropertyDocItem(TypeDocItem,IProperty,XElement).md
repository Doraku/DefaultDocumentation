#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models.Members](index.md#DefaultDocumentation.Models.Members 'DefaultDocumentation.Models.Members').[PropertyDocItem](PropertyDocItem.md 'DefaultDocumentation.Models.Members.PropertyDocItem')

## PropertyDocItem(TypeDocItem, IProperty, XElement) Constructor

Initialize a new instance of the [PropertyDocItem](PropertyDocItem.md 'DefaultDocumentation.Models.Members.PropertyDocItem') type.

```csharp
public PropertyDocItem(DefaultDocumentation.Models.Types.TypeDocItem parent, IProperty property, System.Xml.Linq.XElement? documentation);
```
#### Parameters

<a name='DefaultDocumentation.Models.Members.PropertyDocItem.PropertyDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IProperty,System.Xml.Linq.XElement).parent'></a>

`parent` [TypeDocItem](TypeDocItem.md 'DefaultDocumentation.Models.Types.TypeDocItem')

The [TypeDocItem](TypeDocItem.md 'DefaultDocumentation.Models.Types.TypeDocItem') parent type of the property.

<a name='DefaultDocumentation.Models.Members.PropertyDocItem.PropertyDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IProperty,System.Xml.Linq.XElement).property'></a>

`property` [ICSharpCode.Decompiler.TypeSystem.IProperty](https_//docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.IProperty 'ICSharpCode.Decompiler.TypeSystem.IProperty')

The [IProperty](https_//github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.IProperty') of the property.

<a name='DefaultDocumentation.Models.Members.PropertyDocItem.PropertyDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IProperty,System.Xml.Linq.XElement).documentation'></a>

`documentation` [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') documentation element of the property.