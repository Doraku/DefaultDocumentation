#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections').[ConstructorsSection](index.md 'DefaultDocumentation\.Markdown\.Sections\.ConstructorsSection')

## ConstructorsSection\.ShouldWriteTitle\(IGeneralContext, DocItem\) Method

Gets if the title should be writen or not\.

```csharp
protected override bool ShouldWriteTitle(DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Sections.ConstructorsSection.ShouldWriteTitle(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation generation process\.

<a name='DefaultDocumentation.Markdown.Sections.ConstructorsSection.ShouldWriteTitle(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which to write its children\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')