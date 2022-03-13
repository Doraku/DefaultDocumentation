#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Api](index.md#DefaultDocumentation.Api 'DefaultDocumentation.Api').[IFileNameFactory](IFileNameFactory.md 'DefaultDocumentation.Api.IFileNameFactory')

## IFileNameFactory.GetFileName(IGeneralContext, DocItem) Method

Gets the documentation file name for the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
string GetFileName(DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Api.IFileNameFactory.GetFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process.

<a name='DefaultDocumentation.Api.IFileNameFactory.GetFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') for which to get the documentation file name.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The documentation file name of the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem').