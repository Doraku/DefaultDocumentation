#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models](index.md#DefaultDocumentation.Models 'DefaultDocumentation.Models').[DocItemExtension](DocItemExtension.md 'DefaultDocumentation.Models.DocItemExtension')

## DocItemExtension.GetParents(this DocItem) Method

Returns all the parents of the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
public static System.Collections.Generic.IEnumerable<DefaultDocumentation.Models.DocItem> GetParents(this DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Models.DocItemExtension.GetParents(thisDefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') for which parents should be returned.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https_//docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')[&gt;](https_//docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The parents of the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') from the top parent.