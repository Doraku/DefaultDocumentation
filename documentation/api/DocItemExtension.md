#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models](index.md#DefaultDocumentation.Models 'DefaultDocumentation.Models')

## DocItemExtension Class

Provides extension methods on the [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') type.

```csharp
public static class DocItemExtension
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DocItemExtension

| Methods | |
| :--- | :--- |
| [GetParents(this DocItem)](DocItemExtension.GetParents(thisDocItem).md 'DefaultDocumentation.Models.DocItemExtension.GetParents(this DefaultDocumentation.Models.DocItem)') | Returns all the parents of the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem'). |
| [HasOwnPage(this DocItem, IGeneralContext)](DocItemExtension.HasOwnPage(thisDocItem,IGeneralContext).md 'DefaultDocumentation.Models.DocItemExtension.HasOwnPage(this DefaultDocumentation.Models.DocItem, DefaultDocumentation.IGeneralContext)') | Gets wether the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') has its own page generated based on a [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext'). |
| [TryGetParameterDocItem(this DocItem, string, ParameterDocItem)](DocItemExtension.TryGetParameterDocItem(thisDocItem,string,ParameterDocItem).md 'DefaultDocumentation.Models.DocItemExtension.TryGetParameterDocItem(this DefaultDocumentation.Models.DocItem, string, DefaultDocumentation.Models.Parameters.ParameterDocItem)') | Searchs recursively on the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') parent a [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem') with the provided name. |
| [TryGetTypeParameterDocItem(this DocItem, string, TypeParameterDocItem)](DocItemExtension.TryGetTypeParameterDocItem(thisDocItem,string,TypeParameterDocItem).md 'DefaultDocumentation.Models.DocItemExtension.TryGetTypeParameterDocItem(this DefaultDocumentation.Models.DocItem, string, DefaultDocumentation.Models.Parameters.TypeParameterDocItem)') | Searchs recursively on the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') parent a [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem') with the provided name. |
