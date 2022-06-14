#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.GetIgnoreLineBreak(this IWriter) Method

Gets whether line break in the xml documentation should be ignored in the generated markdown.  
This setting is used by the [MarkdownWriter](MarkdownWriter.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter') type.

```csharp
public static bool GetIgnoreLineBreak(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.GetIgnoreLineBreak(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') for which to get this setting.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether line break in the xml documentation should be ignored in the generated markdown.

### See Also
- [Markdown.IgnoreLineBreak](https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_IgnoreLineBreak 'https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_IgnoreLineBreak')