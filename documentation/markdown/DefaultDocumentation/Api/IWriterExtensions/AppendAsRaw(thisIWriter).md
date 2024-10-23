#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.AppendAsRaw\(this IWriter\) Method

Append a string without sanitizing it for markdown regardless of the current [GetRenderAsRaw\(this IWriter\)](GetRenderAsRaw(thisIWriter).md 'DefaultDocumentation\.Api\.IWriterExtensions\.GetRenderAsRaw\(this DefaultDocumentation\.Api\.IWriter\)') value\.

```csharp
public static System.IDisposable AppendAsRaw(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendAsRaw(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') to use\.

#### Returns
[System\.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System\.IDisposable')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.