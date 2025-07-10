#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Models](../../../index.md#DefaultDocumentation.Models 'DefaultDocumentation\.Models').[DocItemExtensions](index.md 'DefaultDocumentation\.Models\.DocItemExtensions')

## DocItemExtensions\.TryGetTypeParameterDocItem\(this DocItem, string, TypeParameterDocItem\) Method

Searchs recursively on the given [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') parent a [TypeParameterDocItem](../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem') with the provided name\.

```csharp
public static bool TryGetTypeParameterDocItem(this DefaultDocumentation.Models.DocItem item, string name, out DefaultDocumentation.Models.Parameters.TypeParameterDocItem? typeParameterDocItem);
```
#### Parameters

<a name='DefaultDocumentation.Models.DocItemExtensions.TryGetTypeParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.TypeParameterDocItem).item'></a>

`item` [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') starting point from which to look for a specific [TypeParameterDocItem](../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem')\.

<a name='DefaultDocumentation.Models.DocItemExtensions.TryGetTypeParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.TypeParameterDocItem).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the [TypeParameterDocItem](../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem')\.

<a name='DefaultDocumentation.Models.DocItemExtensions.TryGetTypeParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.TypeParameterDocItem).typeParameterDocItem'></a>

`typeParameterDocItem` [TypeParameterDocItem](../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem')

The [TypeParameterDocItem](../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem') if found, else [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the [TypeParameterDocItem](../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem') was found, else [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.