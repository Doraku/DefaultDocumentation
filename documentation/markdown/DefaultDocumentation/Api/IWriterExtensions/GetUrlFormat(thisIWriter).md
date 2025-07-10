#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.GetUrlFormat\(this IWriter\) Method

Gets the format that will be used to display urls\.

```csharp
public static string GetUrlFormat(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.GetUrlFormat(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') for which to get this setting\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
Whether line break in the xml documentation should be handled in the generated markdown\.

### Remarks
Three arguments will be passed to the format:
1. the displayed text
2. the url
3. the tooltip to display when overing the link. If null the url will be used

The default value is `[{0}]({1} '{2}')`\.

### See Also
- [Markdown\.UrlFormat](https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_UrlFormat 'https://github\.com/Doraku/DefaultDocumentation\#MarkdownConfiguration\_UrlFormat')