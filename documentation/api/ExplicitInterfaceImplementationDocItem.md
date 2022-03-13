#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models.Members](index.md#DefaultDocumentation.Models.Members 'DefaultDocumentation.Models.Members')

## ExplicitInterfaceImplementationDocItem Class

Represents an explicit interface implementation documentation.

```csharp
public sealed class ExplicitInterfaceImplementationDocItem : DefaultDocumentation.Models.EntityDocItem,
DefaultDocumentation.Models.ITypeParameterizedDocItem,
DefaultDocumentation.Models.IParameterizedDocItem
```

Inheritance [System.Object](https_//docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') &#129106; [EntityDocItem](EntityDocItem.md 'DefaultDocumentation.Models.EntityDocItem') &#129106; ExplicitInterfaceImplementationDocItem

Implements [ITypeParameterizedDocItem](ITypeParameterizedDocItem.md 'DefaultDocumentation.Models.ITypeParameterizedDocItem'), [IParameterizedDocItem](IParameterizedDocItem.md 'DefaultDocumentation.Models.IParameterizedDocItem')

| Constructors | |
| :--- | :--- |
| [ExplicitInterfaceImplementationDocItem(TypeDocItem, IEvent, XElement)](ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(TypeDocItem,IEvent,XElement).md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(DefaultDocumentation.Models.Types.TypeDocItem, IEvent, System.Xml.Linq.XElement)') | Initialize a new instance of the [ExplicitInterfaceImplementationDocItem](ExplicitInterfaceImplementationDocItem.md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem') type. |
| [ExplicitInterfaceImplementationDocItem(TypeDocItem, IMethod, XElement)](ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(TypeDocItem,IMethod,XElement).md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(DefaultDocumentation.Models.Types.TypeDocItem, IMethod, System.Xml.Linq.XElement)') | Initialize a new instance of the [ExplicitInterfaceImplementationDocItem](ExplicitInterfaceImplementationDocItem.md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem') type. |
| [ExplicitInterfaceImplementationDocItem(TypeDocItem, IProperty, XElement)](ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(TypeDocItem,IProperty,XElement).md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(DefaultDocumentation.Models.Types.TypeDocItem, IProperty, System.Xml.Linq.XElement)') | Initialize a new instance of the [ExplicitInterfaceImplementationDocItem](ExplicitInterfaceImplementationDocItem.md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem') type. |

| Properties | |
| :--- | :--- |
| [Member](ExplicitInterfaceImplementationDocItem.Member.md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.Member') | Gets the [IMember](https_//github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.IMember') of the current instance.<br/>It can either be an [IEvent](https_//github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.IEvent'), [IProperty](https_//github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.IProperty') or [IMethod](https_//github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.IMethod'). |
| [Parameters](ExplicitInterfaceImplementationDocItem.Parameters.md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.Parameters') | Gets the [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem') of this instance. |
| [TypeParameters](ExplicitInterfaceImplementationDocItem.TypeParameters.md 'DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.TypeParameters') | Gets the [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem') of this instance. |
