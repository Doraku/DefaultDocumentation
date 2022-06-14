#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.GetCurrentItem(this IWriter) Method

Gets the current item that is being processed by this [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').  
It can be different from the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.DocItem.md 'DefaultDocumentation.Api.IWriter.DocItem') when inlining child documentation in its parent page.

```csharp
public static DefaultDocumentation.Models.DocItem GetCurrentItem(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.GetCurrentItem(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') for which to get the current item.

#### Returns
[DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem')  
The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') for which the documentation is being generated.