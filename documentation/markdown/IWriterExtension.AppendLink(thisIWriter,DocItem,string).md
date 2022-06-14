#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.AppendLink(this IWriter, DocItem, string) Method

Append an link to a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') in the markdown format.

```csharp
public static DefaultDocumentation.Api.IWriter AppendLink(this DefaultDocumentation.Api.IWriter writer, DefaultDocumentation.Models.DocItem item, string? displayedName=null);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') to use.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,string).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') to link to.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,string).displayedName'></a>

`displayedName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The displayed name of the link.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').