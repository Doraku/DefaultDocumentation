#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.FileNameFactories](index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation.Markdown.FileNameFactories').[AMarkdownFactory](AMarkdownFactory.md 'DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory')

## AMarkdownFactory.GetFileName(IGeneralContext, DocItem) Method

Gets the documentation file name for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
public string GetFileName(DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory.GetFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process.

<a name='DefaultDocumentation.Markdown.FileNameFactories.AMarkdownFactory.GetFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') for which to get the documentation file name.

Implements [GetFileName(IGeneralContext, DocItem)](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IFileNameFactory.GetFileName(IGeneralContext,DocItem).md 'DefaultDocumentation.Api.IFileNameFactory.GetFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem)')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The documentation file name of the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').