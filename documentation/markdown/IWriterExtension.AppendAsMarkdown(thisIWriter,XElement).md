#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.AppendAsMarkdown(this IWriter, XElement) Method

Appends a [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') decorating the [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') with a [MarkdownWriter](MarkdownWriter.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter').

```csharp
public static DefaultDocumentation.Api.IWriter AppendAsMarkdown(this DefaultDocumentation.Api.IWriter writer, System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendAsMarkdown(thisDefaultDocumentation.Api.IWriter,System.Xml.Linq.XElement).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') to use.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendAsMarkdown(thisDefaultDocumentation.Api.IWriter,System.Xml.Linq.XElement).element'></a>

`element` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') to write.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').