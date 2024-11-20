#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [DefaultDocumentation\.Models\.Members](../../../../index.md#DefaultDocumentation.Models.Members 'DefaultDocumentation\.Models\.Members')

## ExplicitInterfaceImplementationDocItem Class

Represents an explicit interface implementation documentation\.

```csharp
public sealed class ExplicitInterfaceImplementationDocItem : DefaultDocumentation.Models.EntityDocItem, DefaultDocumentation.Models.ITypeParameterizedDocItem, DefaultDocumentation.Models.IParameterizedDocItem
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [DocItem](../../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') &#129106; [EntityDocItem](../../EntityDocItem/index.md 'DefaultDocumentation\.Models\.EntityDocItem') &#129106; ExplicitInterfaceImplementationDocItem

Implements [ITypeParameterizedDocItem](../../ITypeParameterizedDocItem/index.md 'DefaultDocumentation\.Models\.ITypeParameterizedDocItem'), [IParameterizedDocItem](../../IParameterizedDocItem/index.md 'DefaultDocumentation\.Models\.IParameterizedDocItem')

| Constructors | |
| :--- | :--- |
| [ExplicitInterfaceImplementationDocItem\(TypeDocItem, IEvent, XElement\)](ExplicitInterfaceImplementationDocItem.md#DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IEvent,System.Xml.Linq.XElement) 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem\.ExplicitInterfaceImplementationDocItem\(DefaultDocumentation\.Models\.Types\.TypeDocItem, IEvent, System\.Xml\.Linq\.XElement\)') | Initialize a new instance of the [ExplicitInterfaceImplementationDocItem](index.md 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem') type\. |
| [ExplicitInterfaceImplementationDocItem\(TypeDocItem, IMethod, XElement\)](ExplicitInterfaceImplementationDocItem.md#DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IMethod,System.Xml.Linq.XElement) 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem\.ExplicitInterfaceImplementationDocItem\(DefaultDocumentation\.Models\.Types\.TypeDocItem, IMethod, System\.Xml\.Linq\.XElement\)') | Initialize a new instance of the [ExplicitInterfaceImplementationDocItem](index.md 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem') type\. |
| [ExplicitInterfaceImplementationDocItem\(TypeDocItem, IProperty, XElement\)](ExplicitInterfaceImplementationDocItem.md#DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItem.ExplicitInterfaceImplementationDocItem(DefaultDocumentation.Models.Types.TypeDocItem,IProperty,System.Xml.Linq.XElement) 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem\.ExplicitInterfaceImplementationDocItem\(DefaultDocumentation\.Models\.Types\.TypeDocItem, IProperty, System\.Xml\.Linq\.XElement\)') | Initialize a new instance of the [ExplicitInterfaceImplementationDocItem](index.md 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem') type\. |

| Properties | |
| :--- | :--- |
| [Member](Member.md 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem\.Member') | Gets the [IMember](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMember') of the current instance\. It can either be an [IEvent](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IEvent'), [IProperty](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IProperty') or [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMethod')\. |
| [Parameters](Parameters.md 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem\.Parameters') | Gets the [ParameterDocItem](../../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem') of this instance\. |
| [TypeParameters](TypeParameters.md 'DefaultDocumentation\.Models\.Members\.ExplicitInterfaceImplementationDocItem\.TypeParameters') | Gets the [TypeParameterDocItem](../../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem') of this instance\. |
