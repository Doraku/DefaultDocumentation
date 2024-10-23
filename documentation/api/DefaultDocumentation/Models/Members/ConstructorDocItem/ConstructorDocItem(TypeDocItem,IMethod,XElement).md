#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [DefaultDocumentation\.Models\.Members](../../../../index.md#DefaultDocumentation.Models.Members 'DefaultDocumentation\.Models\.Members').[ConstructorDocItem](index.md 'DefaultDocumentation\.Models\.Members\.ConstructorDocItem')

## ConstructorDocItem\(TypeDocItem, IMethod, XElement\) Constructor

Initialize a new instance of the [ConstructorDocItem](index.md 'DefaultDocumentation\.Models\.Members\.ConstructorDocItem') type\.

```csharp
public ConstructorDocItem(DefaultDocumentation.Models.Types.TypeDocItem parent, IMethod method, System.Xml.Linq.XElement? documentation);
```
#### Parameters

<a name='DefaultDocumentation.Models.Members.ConstructorDocItem.ConstructorDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).parent'></a>

`parent` [TypeDocItem](../../Types/TypeDocItem/index.md 'DefaultDocumentation\.Models\.Types\.TypeDocItem')

The [TypeDocItem](../../Types/TypeDocItem/index.md 'DefaultDocumentation\.Models\.Types\.TypeDocItem') parent type of the constructor\.

<a name='DefaultDocumentation.Models.Members.ConstructorDocItem.ConstructorDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).method'></a>

`method` [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMethod')

The [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMethod') of the constructor\.

<a name='DefaultDocumentation.Models.Members.ConstructorDocItem.ConstructorDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).documentation'></a>

`documentation` [System\.Xml\.Linq\.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System\.Xml\.Linq\.XElement')

The [System\.Xml\.Linq\.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System\.Xml\.Linq\.XElement') documentation element of the constructor\.

#### Exceptions

[System\.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System\.ArgumentNullException')  
[parent](DefaultDocumentation/Models/Members/ConstructorDocItem/ConstructorDocItem(TypeDocItem,IMethod,XElement).md#DefaultDocumentation.Models.Members.ConstructorDocItem.ConstructorDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).parent 'DefaultDocumentation\.Models\.Members\.ConstructorDocItem\.ConstructorDocItem\(DefaultDocumentation\.Models\.Types\.TypeDocItem, IMethod, System\.Xml\.Linq\.XElement\)\.parent') or [method](DefaultDocumentation/Models/Members/ConstructorDocItem/ConstructorDocItem(TypeDocItem,IMethod,XElement).md#DefaultDocumentation.Models.Members.ConstructorDocItem.ConstructorDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement).method 'DefaultDocumentation\.Models\.Members\.ConstructorDocItem\.ConstructorDocItem\(DefaultDocumentation\.Models\.Types\.TypeDocItem, IMethod, System\.Xml\.Linq\.XElement\)\.method') is null\.