#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.AppendUrl\(this IWriter, string, string, string\) Method

Append an url in the markdown format\.

```csharp
public static DefaultDocumentation.Api.IWriter AppendUrl(this DefaultDocumentation.Api.IWriter writer, string? url, string? displayedName=null, string? tooltip=null);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendUrl(thisDefaultDocumentation.Api.IWriter,string,string,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') to use\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendUrl(thisDefaultDocumentation.Api.IWriter,string,string,string).url'></a>

`url` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The url of the link\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendUrl(thisDefaultDocumentation.Api.IWriter,string,string,string).displayedName'></a>

`displayedName` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The displayed name of the link\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendUrl(thisDefaultDocumentation.Api.IWriter,string,string,string).tooltip'></a>

`tooltip` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The tooltip of the link\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.