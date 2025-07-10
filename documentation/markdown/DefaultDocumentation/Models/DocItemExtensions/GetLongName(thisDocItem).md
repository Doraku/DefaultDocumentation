#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Models](../../../index.md#DefaultDocumentation.Models 'DefaultDocumentation\.Models').[DocItemExtensions](index.md 'DefaultDocumentation\.Models\.DocItemExtensions')

## DocItemExtensions\.GetLongName\(this DocItem\) Method

Gets the long name of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem'), being its full name without its namespace\.
This method should not be called on [AssemblyDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/AssemblyDocItem/index.md 'DefaultDocumentation\.Models\.AssemblyDocItem') or [NamespaceDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/NamespaceDocItem/index.md 'DefaultDocumentation\.Models\.NamespaceDocItem') types\.

```csharp
public static string GetLongName(this DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Models.DocItemExtensions.GetLongName(thisDefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which to get its long name\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The long name of the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.