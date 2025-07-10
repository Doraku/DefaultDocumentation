#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [DefaultDocumentation\.Models\.Members](../../../../index.md#DefaultDocumentation.Models.Members 'DefaultDocumentation\.Models\.Members')

## MethodDocItem Class

Represents an [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMethod') documentation\.

```csharp
public sealed class MethodDocItem : DefaultDocumentation.Models.EntityDocItem, DefaultDocumentation.Models.ITypeParameterizedDocItem, DefaultDocumentation.Models.IParameterizedDocItem
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [DocItem](../../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') &#129106; [EntityDocItem](../../EntityDocItem/index.md 'DefaultDocumentation\.Models\.EntityDocItem') &#129106; MethodDocItem

Implements [ITypeParameterizedDocItem](../../ITypeParameterizedDocItem/index.md 'DefaultDocumentation\.Models\.ITypeParameterizedDocItem'), [IParameterizedDocItem](../../IParameterizedDocItem/index.md 'DefaultDocumentation\.Models\.IParameterizedDocItem')

| Constructors | |
| :--- | :--- |
| [MethodDocItem\(TypeDocItem, IMethod, XElement\)](MethodDocItem(TypeDocItem,IMethod,XElement).md 'DefaultDocumentation\.Models\.Members\.MethodDocItem\.MethodDocItem\(DefaultDocumentation\.Models\.Types\.TypeDocItem, IMethod, System\.Xml\.Linq\.XElement\)') | Initialize a new instance of the [MethodDocItem](index.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem') type\. |

| Properties | |
| :--- | :--- |
| [Method](Method.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem\.Method') | Gets the [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMethod') of the current instance\. |
| [Parameters](Parameters.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem\.Parameters') | Gets the [ParameterDocItem](../../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem') of this instance\. |
| [TypeParameters](TypeParameters.md 'DefaultDocumentation\.Models\.Members\.MethodDocItem\.TypeParameters') | Gets the [TypeParameterDocItem](../../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem') of this instance\. |
