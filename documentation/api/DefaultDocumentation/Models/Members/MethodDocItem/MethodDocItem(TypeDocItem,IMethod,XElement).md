#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [DefaultDocumentation\.Models\.Members](../../../../index.md#DefaultDocumentation.Models.Members 'DefaultDocumentation\.Models\.Members').[MethodDocItem](index.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem')

## MethodDocItem\(TypeDocItem, IMethod, XElement\) Constructor

Initialize a new instance of the [MethodDocItem](index.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem') type\.

```csharp
public MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem parent, IMethod method, System.Xml.Linq.XElement? documentation);
```
#### Parameters

<a name='DefaultDocumentation.Models.Members.MethodDocItem.MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).parent'></a>

`parent` [TypeDocItem](../../Types/TypeDocItem/index.md 'DefaultDocumentation\.Models\.Types\.TypeDocItem')

The [TypeDocItem](../../Types/TypeDocItem/index.md 'DefaultDocumentation\.Models\.Types\.TypeDocItem') parent type of the method\.

<a name='DefaultDocumentation.Models.Members.MethodDocItem.MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).method'></a>

`method` [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMethod')

The [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMethod') of the method\.

<a name='DefaultDocumentation.Models.Members.MethodDocItem.MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).documentation'></a>

`documentation` [System\.Xml\.Linq\.XElement](https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement 'System\.Xml\.Linq\.XElement')

The [System\.Xml\.Linq\.XElement](https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement 'System\.Xml\.Linq\.XElement') documentation element of the method\.