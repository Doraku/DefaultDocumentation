#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.SetIgnoreLineBreakLine(this IWriter, Nullable<bool>) Method

Sets whether line break in the xml documentation should be ignored in the generated markdown.  
This setting is used by the [MarkdownWriter](MarkdownWriter.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter') type.

```csharp
public static DefaultDocumentation.Api.IWriter SetIgnoreLineBreakLine(this DefaultDocumentation.Api.IWriter writer, System.Nullable<bool> value);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.SetIgnoreLineBreakLine(thisDefaultDocumentation.Api.IWriter,System.Nullable_bool_).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') for which to set this setting.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.SetIgnoreLineBreakLine(thisDefaultDocumentation.Api.IWriter,System.Nullable_bool_).value'></a>

`value` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether line break in the xml documentation should be ignored in the generated markdown.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').

### See Also
- [Markdown.IgnoreLineBreak](https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_IgnoreLineBreak 'https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_IgnoreLineBreak')