#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.ToPrefixedWriter\(this IWriter, string\) Method

Decorates the given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') with a [PrefixedWriter](../../Markdown/Writers/PrefixedWriter/index.md 'DefaultDocumentation\.Markdown\.Writers\.PrefixedWriter') to prefix every new line with the given prefix\.

```csharp
public static DefaultDocumentation.Api.IWriter ToPrefixedWriter(this DefaultDocumentation.Api.IWriter writer, string prefix);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.ToPrefixedWriter(thisDefaultDocumentation.Api.IWriter,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') to decorate\.

<a name='DefaultDocumentation.Api.IWriterExtensions.ToPrefixedWriter(thisDefaultDocumentation.Api.IWriter,string).prefix'></a>

`prefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string to prefix every new line with\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The decorated [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.