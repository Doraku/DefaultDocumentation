#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.SetDisplayAsSingleLine\(this IWriter, Nullable\<bool\>\) Method

Sets whether all futur data appended to the given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') should stay on the same line \(usefull for table\)\.
This setting is used by the [MarkdownWriter](../../Markdown/Writers/MarkdownWriter/index.md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter') type\.

```csharp
public static DefaultDocumentation.Api.IWriter SetDisplayAsSingleLine(this DefaultDocumentation.Api.IWriter writer, System.Nullable<bool> value);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.SetDisplayAsSingleLine(thisDefaultDocumentation.Api.IWriter,System.Nullable_bool_).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') for which to set this setting\.

<a name='DefaultDocumentation.Api.IWriterExtensions.SetDisplayAsSingleLine(thisDefaultDocumentation.Api.IWriter,System.Nullable_bool_).value'></a>

`value` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Whether all futur data to happend should stay on the same line\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.