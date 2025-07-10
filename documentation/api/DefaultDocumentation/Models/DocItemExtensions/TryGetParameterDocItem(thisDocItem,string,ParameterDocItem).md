#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Models](../../../index.md#DefaultDocumentation.Models 'DefaultDocumentation\.Models').[DocItemExtensions](index.md 'DefaultDocumentation\.Models\.DocItemExtensions')

## DocItemExtensions\.TryGetParameterDocItem\(this DocItem, string, ParameterDocItem\) Method

Searchs recursively on the given [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') parent a [ParameterDocItem](../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem') with the provided name\.

```csharp
public static bool TryGetParameterDocItem(this DefaultDocumentation.Models.DocItem item, string name, out DefaultDocumentation.Models.Parameters.ParameterDocItem? parameterDocItem);
```
#### Parameters

<a name='DefaultDocumentation.Models.DocItemExtensions.TryGetParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.ParameterDocItem).item'></a>

`item` [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') starting point from which to look for a specific [ParameterDocItem](../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem')\.

<a name='DefaultDocumentation.Models.DocItemExtensions.TryGetParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.ParameterDocItem).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the [ParameterDocItem](../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem')\.

<a name='DefaultDocumentation.Models.DocItemExtensions.TryGetParameterDocItem(thisDefaultDocumentation.Models.DocItem,string,DefaultDocumentation.Models.Parameters.ParameterDocItem).parameterDocItem'></a>

`parameterDocItem` [ParameterDocItem](../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem')

The [ParameterDocItem](../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem') if found, else [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the [ParameterDocItem](../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem') was found, else [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.