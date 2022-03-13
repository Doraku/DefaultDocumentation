#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtension](IGeneralContextExtension.md 'DefaultDocumentation.IGeneralContextExtension')

## IGeneralContextExtension.GetContext(this IGeneralContext, DocItem) Method

Gets the specific [IContext](IContext.md 'DefaultDocumentation.IContext') for the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') kind.

```csharp
public static DefaultDocumentation.IContext GetContext(this DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetContext(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation file.

<a name='DefaultDocumentation.IGeneralContextExtension.GetContext(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') for which to get a specific [IContext](IContext.md 'DefaultDocumentation.IContext').

#### Returns
[IContext](IContext.md 'DefaultDocumentation.IContext')  
The [IContext](IContext.md 'DefaultDocumentation.IContext') specific to the provided [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem').