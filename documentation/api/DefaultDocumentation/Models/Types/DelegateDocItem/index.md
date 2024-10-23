#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [DefaultDocumentation\.Models\.Types](../../../../index.md#DefaultDocumentation.Models.Types 'DefaultDocumentation\.Models\.Types')

## DelegateDocItem Class

Represents a [ITypeDefinition](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.ITypeDefinition') of the [TypeKind\.Delegate](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.TypeKind\.Delegate') kind documentation\.

```csharp
public sealed class DelegateDocItem : DefaultDocumentation.Models.Types.TypeDocItem, DefaultDocumentation.Models.IParameterizedDocItem
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; [DocItem](../../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') &#129106; [EntityDocItem](../../EntityDocItem/index.md 'DefaultDocumentation\.Models\.EntityDocItem') &#129106; [TypeDocItem](../TypeDocItem/index.md 'DefaultDocumentation\.Models\.Types\.TypeDocItem') &#129106; DelegateDocItem

Implements [IParameterizedDocItem](../../IParameterizedDocItem/index.md 'DefaultDocumentation\.Models\.IParameterizedDocItem')

| Constructors | |
| :--- | :--- |
| [DelegateDocItem\(DocItem, ITypeDefinition, XElement\)](DelegateDocItem(DocItem,ITypeDefinition,XElement).md 'DefaultDocumentation\.Models\.Types\.DelegateDocItem\.DelegateDocItem\(DefaultDocumentation\.Models\.DocItem, ITypeDefinition, System\.Xml\.Linq\.XElement\)') | Initialize a new instance of the [StructDocItem](../StructDocItem/index.md 'DefaultDocumentation\.Models\.Types\.StructDocItem') type\. |

| Properties | |
| :--- | :--- |
| [InvokeMethod](InvokeMethod.md 'DefaultDocumentation\.Models\.Types\.DelegateDocItem\.InvokeMethod') | Gets the [IMethod](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IMethod') of the current instance\. |
| [Parameters](Parameters.md 'DefaultDocumentation\.Models\.Types\.DelegateDocItem\.Parameters') | Gets the [ParameterDocItem](../../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem') of this instance\. |
