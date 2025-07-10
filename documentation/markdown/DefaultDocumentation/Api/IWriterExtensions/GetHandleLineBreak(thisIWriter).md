#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.GetHandleLineBreak\(this IWriter\) Method

Gets whether line break in the xml documentation should be handled in the generated markdown\.
This setting is used by the [MarkdownWriter](../../Markdown/Writers/MarkdownWriter/index.md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter') type\.

```csharp
public static bool GetHandleLineBreak(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.GetHandleLineBreak(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') for which to get this setting\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
Whether line break in the xml documentation should be handled in the generated markdown\.

### See Also
- [Markdown\.HandleLineBreak](https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_HandleLineBreak 'https://github\.com/Doraku/DefaultDocumentation\#MarkdownConfiguration\_HandleLineBreak')