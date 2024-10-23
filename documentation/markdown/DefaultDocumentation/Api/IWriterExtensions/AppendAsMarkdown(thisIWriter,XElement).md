#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.AppendAsMarkdown\(this IWriter, XElement\) Method

Appends a [System\.Xml\.Linq\.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System\.Xml\.Linq\.XElement') decorating the [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') with a [MarkdownWriter](../../Markdown/Writers/MarkdownWriter/index.md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter')\.

```csharp
public static DefaultDocumentation.Api.IWriter AppendAsMarkdown(this DefaultDocumentation.Api.IWriter writer, System.Xml.Linq.XElement? element);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendAsMarkdown(thisDefaultDocumentation.Api.IWriter,System.Xml.Linq.XElement).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') to use\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendAsMarkdown(thisDefaultDocumentation.Api.IWriter,System.Xml.Linq.XElement).element'></a>

`element` [System\.Xml\.Linq\.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System\.Xml\.Linq\.XElement')

The [System\.Xml\.Linq\.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System\.Xml\.Linq\.XElement') to write\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.