#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [DefaultDocumentation\.Models\.Types](../../../../index.md#DefaultDocumentation.Models.Types 'DefaultDocumentation\.Models\.Types')

## TypeDocItem Class

Represents a [ITypeDefinition](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.ITypeDefinition') documentation\.

```csharp
public abstract class TypeDocItem : DefaultDocumentation.Models.EntityDocItem, DefaultDocumentation.Models.ITypeParameterizedDocItem
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DocItem](../../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') → [EntityDocItem](../../EntityDocItem/index.md 'DefaultDocumentation\.Models\.EntityDocItem') → TypeDocItem

Derived  
↳ [ClassDocItem](../ClassDocItem/index.md 'DefaultDocumentation\.Models\.Types\.ClassDocItem')  
↳ [DelegateDocItem](../DelegateDocItem/index.md 'DefaultDocumentation\.Models\.Types\.DelegateDocItem')  
↳ [EnumDocItem](../EnumDocItem/index.md 'DefaultDocumentation\.Models\.Types\.EnumDocItem')  
↳ [InterfaceDocItem](../InterfaceDocItem/index.md 'DefaultDocumentation\.Models\.Types\.InterfaceDocItem')  
↳ [StructDocItem](../StructDocItem/index.md 'DefaultDocumentation\.Models\.Types\.StructDocItem')

Implements [ITypeParameterizedDocItem](../../ITypeParameterizedDocItem/index.md 'DefaultDocumentation\.Models\.ITypeParameterizedDocItem')

| Properties | |
| :--- | :--- |
| [Type](Type.md 'DefaultDocumentation\.Models\.Types\.TypeDocItem\.Type') | Gets the [ITypeDefinition](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.ITypeDefinition') of the current instance\. |
| [TypeParameters](TypeParameters.md 'DefaultDocumentation\.Models\.Types\.TypeDocItem\.TypeParameters') | Gets the [TypeParameterDocItem](../../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem') of this instance\. |
