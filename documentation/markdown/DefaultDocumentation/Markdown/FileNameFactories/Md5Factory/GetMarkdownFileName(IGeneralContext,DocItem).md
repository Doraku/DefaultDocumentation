#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.FileNameFactories](../../../../index.md#DefaultDocumentation.Markdown.FileNameFactories 'DefaultDocumentation\.Markdown\.FileNameFactories').[Md5Factory](index.md 'DefaultDocumentation\.Markdown\.FileNameFactories\.Md5Factory')

## Md5Factory\.GetMarkdownFileName\(IGeneralContext, DocItem\) Method

Gets the file name to use for the given [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
protected override string GetMarkdownFileName(DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.FileNameFactories.Md5Factory.GetMarkdownFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation generation process\.

<a name='DefaultDocumentation.Markdown.FileNameFactories.Md5Factory.GetMarkdownFileName(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which to get the documentation file name\.

#### Returns
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')  
The file name to use\.