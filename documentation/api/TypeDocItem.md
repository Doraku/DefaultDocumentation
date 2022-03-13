#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models.Types](index.md#DefaultDocumentation.Models.Types 'DefaultDocumentation.Models.Types')

## TypeDocItem Class

Represents a [ITypeDefinition](https://github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.ITypeDefinition') documentation.

```csharp
public abstract class TypeDocItem : DefaultDocumentation.Models.EntityDocItem,
DefaultDocumentation.Models.ITypeParameterizedDocItem
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') &#129106; [EntityDocItem](EntityDocItem.md 'DefaultDocumentation.Models.EntityDocItem') &#129106; TypeDocItem

Derived  
&#8627; [ClassDocItem](ClassDocItem.md 'DefaultDocumentation.Models.Types.ClassDocItem')  
&#8627; [DelegateDocItem](DelegateDocItem.md 'DefaultDocumentation.Models.Types.DelegateDocItem')  
&#8627; [EnumDocItem](EnumDocItem.md 'DefaultDocumentation.Models.Types.EnumDocItem')  
&#8627; [InterfaceDocItem](InterfaceDocItem.md 'DefaultDocumentation.Models.Types.InterfaceDocItem')  
&#8627; [StructDocItem](StructDocItem.md 'DefaultDocumentation.Models.Types.StructDocItem')

Implements [ITypeParameterizedDocItem](ITypeParameterizedDocItem.md 'DefaultDocumentation.Models.ITypeParameterizedDocItem')

| Properties | |
| :--- | :--- |
| [Type](TypeDocItem.Type.md 'DefaultDocumentation.Models.Types.TypeDocItem.Type') | Gets the [ITypeDefinition](https://github.com/icsharpcode/ILSpy 'ICSharpCode.Decompiler.TypeSystem.ITypeDefinition') of the current instance. |
| [TypeParameters](TypeDocItem.TypeParameters.md 'DefaultDocumentation.Models.Types.TypeDocItem.TypeParameters') | Gets the [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem') of this instance. |
