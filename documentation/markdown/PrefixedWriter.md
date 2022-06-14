#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Writers](index.md#DefaultDocumentation.Markdown.Writers 'DefaultDocumentation.Markdown.Writers')

## PrefixedWriter Class

Decorator of the [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') type to prefix every new line with a specific [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String').

```csharp
public sealed class PrefixedWriter :
DefaultDocumentation.Api.IWriter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PrefixedWriter

Implements [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

| Constructors | |
| :--- | :--- |
| [PrefixedWriter(IWriter, string)](PrefixedWriter.PrefixedWriter(IWriter,string).md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter.PrefixedWriter(DefaultDocumentation.Api.IWriter, string)') | Initializes a new instance of the [PrefixedWriter](PrefixedWriter.md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter') type. |

| Properties | |
| :--- | :--- |
| [Context](PrefixedWriter.Context.md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter.Context') | Gets the [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process. |
| [DocItem](PrefixedWriter.DocItem.md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter.DocItem') | Gets the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') for which the documentation is being generated. |
| [Length](PrefixedWriter.Length.md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter.Length') | Gets or sets the length of the documentation text currently produced. |
| [this[string]](PrefixedWriter.this[string].md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter.this[string]') | Gets or sets extra data for the current [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') documentation generation. |

| Methods | |
| :--- | :--- |
| [Append(string)](PrefixedWriter.Append(string).md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter.Append(string)') | Appends a string at the end of the documentation text. |
| [AppendLine()](PrefixedWriter.AppendLine().md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter.AppendLine()') | Appends a [System.Environment.NewLine](https://docs.microsoft.com/en-us/dotnet/api/System.Environment.NewLine 'System.Environment.NewLine') at the end of the documentation text. |
| [EndsWith(string)](PrefixedWriter.EndsWith(string).md 'DefaultDocumentation.Markdown.Writers.PrefixedWriter.EndsWith(string)') | Returns whether the documentation text ends with the given string. |
