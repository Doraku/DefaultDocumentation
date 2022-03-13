#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models](index.md#DefaultDocumentation.Models 'DefaultDocumentation.Models').[DocItemExtension](DocItemExtension.md 'DefaultDocumentation.Models.DocItemExtension')

## DocItemExtension.TryGetParameterDocItem(this DocItem, string, ParameterDocItem) Method

Searchs recursively on the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') parent a [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem') with the provided name.

```csharp
public static bool TryGetParameterDocItem(this DefaultDocumentation.Models.DocItem? item, string name, out DefaultDocumentation.Models.Parameters.ParameterDocItem? parameterDocItem);
```
#### Parameters

<a name='DefaultDocumentation.Models.DocItemExtension.TryGetParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.ParameterDocItem).item'></a>

`item` [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') starting point from which to look for a specific [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem').

<a name='DefaultDocumentation.Models.DocItemExtension.TryGetParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.ParameterDocItem).name'></a>

`name` [System.String](https_//docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem').

<a name='DefaultDocumentation.Models.DocItemExtension.TryGetParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.ParameterDocItem).parameterDocItem'></a>

`parameterDocItem` [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem')

The [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem') if found, else [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null').

#### Returns
[System.Boolean](https_//docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem') was found, else [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').