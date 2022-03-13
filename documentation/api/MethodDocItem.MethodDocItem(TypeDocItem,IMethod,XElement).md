#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models.Members](index.md#DefaultDocumentation.Models.Members 'DefaultDocumentation.Models.Members').[MethodDocItem](MethodDocItem.md 'DefaultDocumentation.Models.Members.MethodDocItem')

## MethodDocItem(TypeDocItem, IMethod, XElement) Constructor

Initialize a new instance of the [MethodDocItem](MethodDocItem.md 'DefaultDocumentation.Models.Members.MethodDocItem') type.

```csharp
public MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem parent, IMethod method, System.Xml.Linq.XElement? documentation);
```
#### Parameters

<a name='DefaultDocumentation.Models.Members.MethodDocItem.MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).parent'></a>

`parent` [TypeDocItem](TypeDocItem.md 'DefaultDocumentation.Models.Types.TypeDocItem')

The [TypeDocItem](TypeDocItem.md 'DefaultDocumentation.Models.Types.TypeDocItem') parent type of the method.

<a name='DefaultDocumentation.Models.Members.MethodDocItem.MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).method'></a>

`method` [ICSharpCode.Decompiler.TypeSystem.IMethod](https_//docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.IMethod 'ICSharpCode.Decompiler.TypeSystem.IMethod')

The [IMethod](https_//github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.IMethod') of the method.

<a name='DefaultDocumentation.Models.Members.MethodDocItem.MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).documentation'></a>

`documentation` [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') documentation element of the method.