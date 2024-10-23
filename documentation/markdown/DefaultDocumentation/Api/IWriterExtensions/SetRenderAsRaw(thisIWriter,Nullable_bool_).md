#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.SetRenderAsRaw\(this IWriter, Nullable\<bool\>\) Method

Sets whether the writer should append the next strings as is without sanitizing it\.
This setting is used by the [MarkdownWriter](../../Markdown/Writers/MarkdownWriter/index.md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter') type\.

```csharp
public static DefaultDocumentation.Api.IWriter SetRenderAsRaw(this DefaultDocumentation.Api.IWriter writer, System.Nullable<bool> value);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.SetRenderAsRaw(thisDefaultDocumentation.Api.IWriter,System.Nullable_bool_).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') for which to set this setting\.

<a name='DefaultDocumentation.Api.IWriterExtensions.SetRenderAsRaw(thisDefaultDocumentation.Api.IWriter,System.Nullable_bool_).value'></a>

`value` [System\.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System\.Nullable\`1')[System\.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System\.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System\.Nullable\`1')

Whether strings should be sanitized\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.