#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Models](index.md#DefaultDocumentation.Models 'DefaultDocumentation.Models').[DocItemExtension](DocItemExtension.md 'DefaultDocumentation.Models.DocItemExtension')

## DocItemExtension.GetLongName(this DocItem) Method

Gets the long name of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem'), being its full name without its namespace.  
This method should not be called on [AssemblyDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/AssemblyDocItem.md 'DefaultDocumentation.Models.AssemblyDocItem') or [NamespaceDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/NamespaceDocItem.md 'DefaultDocumentation.Models.NamespaceDocItem') types.

```csharp
public static string GetLongName(this DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Models.DocItemExtension.GetLongName(thisDefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') for which to get its long name.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The long name of the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').