#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IFileNameFactory](index.md 'DefaultDocumentation\.Api\.IFileNameFactory')

## IFileNameFactory\.GetFileName\(IGeneralContext, DocItem\) Method

Gets the documentation file name for the given [DocItem](../../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
string GetFileName(DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Api.IFileNameFactory.GetFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](../../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](../../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation generation process\.

<a name='DefaultDocumentation.Api.IFileNameFactory.GetFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](../../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](../../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which to get the documentation file name\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The documentation file name of the given [DocItem](../../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.