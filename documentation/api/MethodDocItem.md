#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models.Members](index.md#DefaultDocumentation.Models.Members 'DefaultDocumentation.Models.Members')

## MethodDocItem Class

Represents an [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.IMethod') documentation.

```csharp
public sealed class MethodDocItem : DefaultDocumentation.Models.EntityDocItem,
DefaultDocumentation.Models.ITypeParameterizedDocItem,
DefaultDocumentation.Models.IParameterizedDocItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') &#129106; [EntityDocItem](EntityDocItem.md 'DefaultDocumentation.Models.EntityDocItem') &#129106; MethodDocItem

Implements [ITypeParameterizedDocItem](ITypeParameterizedDocItem.md 'DefaultDocumentation.Models.ITypeParameterizedDocItem'), [IParameterizedDocItem](IParameterizedDocItem.md 'DefaultDocumentation.Models.IParameterizedDocItem')

| Constructors | |
| :--- | :--- |
| [MethodDocItem(TypeDocItem, IMethod, XElement)](MethodDocItem.MethodDocItem(TypeDocItem,IMethod,XElement).md 'DefaultDocumentation.Models.Members.MethodDocItem.MethodDocItem(DefaultDocumentation.Models.Types.TypeDocItem, IMethod, System.Xml.Linq.XElement)') | Initialize a new instance of the [MethodDocItem](MethodDocItem.md 'DefaultDocumentation.Models.Members.MethodDocItem') type. |

| Properties | |
| :--- | :--- |
| [Method](MethodDocItem.Method.md 'DefaultDocumentation.Models.Members.MethodDocItem.Method') | Gets the [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.IMethod') of the current instance. |
| [Parameters](MethodDocItem.Parameters.md 'DefaultDocumentation.Models.Members.MethodDocItem.Parameters') | Gets the [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem') of this instance. |
| [TypeParameters](MethodDocItem.TypeParameters.md 'DefaultDocumentation.Models.Members.MethodDocItem.TypeParameters') | Gets the [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem') of this instance. |
