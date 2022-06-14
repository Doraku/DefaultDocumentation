#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.AppendLink(this IWriter, string, string) Method

Append an link to an id using [GetUrl(string)](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.GetUrl(string).md 'DefaultDocumentation.IGeneralContext.GetUrl(System.String)') to resolve the url in the markdown format.

```csharp
public static DefaultDocumentation.Api.IWriter AppendLink(this DefaultDocumentation.Api.IWriter writer, string id, string? displayedName=null);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,string,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') to use.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,string,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The id to link to.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,string,string).displayedName'></a>

`displayedName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The displayed name of the link.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').