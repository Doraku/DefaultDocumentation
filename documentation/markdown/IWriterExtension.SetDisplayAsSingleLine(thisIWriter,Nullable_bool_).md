#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.SetDisplayAsSingleLine(this IWriter, Nullable<bool>) Method

Sets whether all futur data appended to the given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') should stay on the same line (usefull for table).  
This setting is used by the [MarkdownWriter](MarkdownWriter.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter') type.

```csharp
public static DefaultDocumentation.Api.IWriter SetDisplayAsSingleLine(this DefaultDocumentation.Api.IWriter writer, System.Nullable<bool> value);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.SetDisplayAsSingleLine(thisDefaultDocumentation.Api.IWriter,System.Nullable_bool_).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') for which to set this setting.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.SetDisplayAsSingleLine(thisDefaultDocumentation.Api.IWriter,System.Nullable_bool_).value'></a>

`value` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether all futur data to happend should stay on the same line.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').