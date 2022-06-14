#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.ToPrefixedWriter(this IWriter, string) Method

Decorates the given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') with a [PrefixedWriter](PrefixedWriter.md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter') to prefix every new line with the given prefix.

```csharp
public static DefaultDocumentation.Api.IWriter ToPrefixedWriter(this DefaultDocumentation.Api.IWriter writer, string prefix);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.ToPrefixedWriter(thisDefaultDocumentation.Api.IWriter,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') to decorate.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.ToPrefixedWriter(thisDefaultDocumentation.Api.IWriter,string).prefix'></a>

`prefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string to prefix every new line with.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The decorated [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').