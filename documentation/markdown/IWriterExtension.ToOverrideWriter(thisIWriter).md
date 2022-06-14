#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.ToOverrideWriter(this IWriter) Method

Decorates the given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') with a [OverrideWriter](OverrideWriter.md 'DefaultDocumentation.Markdown.Writers.OverrideWriter') to override its setting in a given scope.

```csharp
public static DefaultDocumentation.Api.IWriter ToOverrideWriter(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.ToOverrideWriter(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') to decorate.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The decorated [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').