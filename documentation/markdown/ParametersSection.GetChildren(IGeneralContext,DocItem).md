#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Sections](index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation.Markdown.Sections').[ParametersSection](ParametersSection.md 'DefaultDocumentation.Markdown.Sections.ParametersSection')

## ParametersSection.GetChildren(IGeneralContext, DocItem) Method

Gets the children of a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') to write.

```csharp
protected override System.Collections.Generic.IEnumerable<DefaultDocumentation.Models.Parameters.ParameterDocItem>? GetChildren(DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Sections.ParametersSection.GetChildren(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process.

<a name='DefaultDocumentation.Markdown.Sections.ParametersSection.GetChildren(DefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') for which to write its children.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ParameterDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The children to write.