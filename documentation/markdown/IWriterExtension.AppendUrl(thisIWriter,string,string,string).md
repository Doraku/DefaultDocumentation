#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.AppendUrl(this IWriter, string, string, string) Method

Append an url in the markdown format.

```csharp
public static DefaultDocumentation.Api.IWriter AppendUrl(this DefaultDocumentation.Api.IWriter writer, string url, string? displayedName=null, string? tooltip=null);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendUrl(thisDefaultDocumentation.Api.IWriter,string,string,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') to use.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendUrl(thisDefaultDocumentation.Api.IWriter,string,string,string).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The url of the link.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendUrl(thisDefaultDocumentation.Api.IWriter,string,string,string).displayedName'></a>

`displayedName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The displayed name of the link.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendUrl(thisDefaultDocumentation.Api.IWriter,string,string,string).tooltip'></a>

`tooltip` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The tooltip of the link.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').