#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtension](IGeneralContextExtension.md 'DefaultDocumentation.IGeneralContextExtension')

## IGeneralContextExtension.GetChildren<T>(this IGeneralContext, DocItem) Method

Gets the children of a specific [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') type of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') instance.

```csharp
public static System.Collections.Generic.IEnumerable<T> GetChildren<T>(this DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item)
    where T : DefaultDocumentation.Models.DocItem;
```
#### Type parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetChildren_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).T'></a>

`T`

The type of the children to look for.
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetChildren_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation file.

<a name='DefaultDocumentation.IGeneralContextExtension.GetChildren_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') instance for which to get its children.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](IGeneralContextExtension.GetChildren_T_(thisIGeneralContext,DocItem).md#DefaultDocumentation.IGeneralContextExtension.GetChildren_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).T 'DefaultDocumentation.IGeneralContextExtension.GetChildren<T>(this DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The children of the provided [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').