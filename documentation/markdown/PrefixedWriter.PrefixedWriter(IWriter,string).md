#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Writers](index.md#DefaultDocumentation.Markdown.Writers 'DefaultDocumentation.Markdown.Writers').[PrefixedWriter](PrefixedWriter.md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter')

## PrefixedWriter(IWriter, string) Constructor

Initializes a new instance of the [PrefixedWriter](PrefixedWriter.md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter') type.

```csharp
public PrefixedWriter(DefaultDocumentation.Api.IWriter writer, string prefix);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Writers.PrefixedWriter.PrefixedWriter(DefaultDocumentation.Api.IWriter,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') instance to decorate.

<a name='DefaultDocumentation.Markdown.Writers.PrefixedWriter.PrefixedWriter(DefaultDocumentation.Api.IWriter,string).prefix'></a>

`prefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The prefix to use at every new line start.