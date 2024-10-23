#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtensions](index.md 'DefaultDocumentation\.IGeneralContextExtensions')

## IGeneralContextExtensions\.GetContext\(this IGeneralContext, DocItem\) Method

Gets the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') for the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') kind\.

```csharp
public static DefaultDocumentation.IContext GetContext(this DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtensions.GetContext(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation file\.

<a name='DefaultDocumentation.IGeneralContextExtensions.GetContext(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which to get a specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext')\.

#### Returns
[IContext](../IContext/index.md 'DefaultDocumentation\.IContext')  
The [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') specific to the provided [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.