#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.GetDisplayAsSingleLine(this IWriter) Method

Gets whether all futur data appended to the given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') should stay on the same line (usefull for table).  
This setting is used by the [MarkdownWriter](MarkdownWriter.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter') type.

```csharp
public static bool GetDisplayAsSingleLine(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.GetDisplayAsSingleLine(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') for which to get this setting.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether all futur data to happend should stay on the same line.