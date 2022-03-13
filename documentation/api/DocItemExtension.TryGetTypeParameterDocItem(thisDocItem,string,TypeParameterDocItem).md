#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models](index.md#DefaultDocumentation.Models 'DefaultDocumentation.Models').[DocItemExtension](DocItemExtension.md 'DefaultDocumentation.Models.DocItemExtension')

## DocItemExtension.TryGetTypeParameterDocItem(this DocItem, string, TypeParameterDocItem) Method

Searchs recursively on the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') parent a [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem') with the provided name.

```csharp
public static bool TryGetTypeParameterDocItem(this DefaultDocumentation.Models.DocItem? item, string name, out DefaultDocumentation.Models.Parameters.TypeParameterDocItem? typeParameterDocItem);
```
#### Parameters

<a name='DefaultDocumentation.Models.DocItemExtension.TryGetTypeParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.TypeParameterDocItem).item'></a>

`item` [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') starting point from which to look for a specific [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem').

<a name='DefaultDocumentation.Models.DocItemExtension.TryGetTypeParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.TypeParameterDocItem).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem').

<a name='DefaultDocumentation.Models.DocItemExtension.TryGetTypeParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.TypeParameterDocItem).typeParameterDocItem'></a>

`typeParameterDocItem` [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem')

The [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem') if found, else [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null').

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem') was found, else [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').