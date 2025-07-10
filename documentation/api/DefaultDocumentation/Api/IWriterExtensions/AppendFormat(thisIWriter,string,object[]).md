#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.AppendFormat\(this IWriter, string, object\[\]\) Method

Appends a formatted string to a [IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.

```csharp
public static DefaultDocumentation.Api.IWriter AppendFormat(this DefaultDocumentation.Api.IWriter writer, string format, params object?[] args);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendFormat(thisDefaultDocumentation.Api.IWriter,string,object[]).writer'></a>

`writer` [IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') to append to\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendFormat(thisDefaultDocumentation.Api.IWriter,string,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The format to use\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendFormat(thisDefaultDocumentation.Api.IWriter,string,object[]).args'></a>

`args` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The arguments to use in the format\.

#### Returns
[IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](../IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.