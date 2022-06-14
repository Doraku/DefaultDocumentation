#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.EnsureLineStart(this IWriter) Method

Ensures that the given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') ends with a line break and call [AppendLine()](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.AppendLine().md 'DefaultDocumentation.Api.IWriter.AppendLine') if it's not the case.

```csharp
public static DefaultDocumentation.Api.IWriter EnsureLineStart(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.EnsureLineStart(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') to check.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').