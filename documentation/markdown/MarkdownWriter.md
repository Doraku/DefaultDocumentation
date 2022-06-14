#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Writers](index.md#DefaultDocumentation.Markdown.Writers 'DefaultDocumentation.Markdown.Writers')

## MarkdownWriter Class

Decorator of the [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') type to handle the [Markdown.IgnoreLineBreak](https://github.com/Doraku/DefaultDocumentation#ignorelinebreak 'https://github.com/Doraku/DefaultDocumentation#ignorelinebreak') setting.  
It also uses a [OverrideWriter](OverrideWriter.md 'DefaultDocumentation.Markdown.Writers.OverrideWriter') internally to further decorate the instance.

```csharp
public sealed class MarkdownWriter :
DefaultDocumentation.Api.IWriter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MarkdownWriter

Implements [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

| Constructors | |
| :--- | :--- |
| [MarkdownWriter(IWriter)](MarkdownWriter.MarkdownWriter(IWriter).md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter.MarkdownWriter(DefaultDocumentation.Api.IWriter)') | Initializes a new instance of the [MarkdownWriter](MarkdownWriter.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter') type. |

| Properties | |
| :--- | :--- |
| [Context](MarkdownWriter.Context.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter.Context') | Gets the [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process. |
| [DocItem](MarkdownWriter.DocItem.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter.DocItem') | Gets the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') for which the documentation is being generated. |
| [Length](MarkdownWriter.Length.md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter.Length') | Gets or sets the length of the documentation text currently produced. |
| [this[string]](MarkdownWriter.this[string].md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter.this[string]') | Gets or sets extra data for the current [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') documentation generation. |

| Methods | |
| :--- | :--- |
| [Append(string)](MarkdownWriter.Append(string).md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter.Append(string)') | Appends a string at the end of the documentation text. |
| [AppendLine()](MarkdownWriter.AppendLine().md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter.AppendLine()') | Appends a [System.Environment.NewLine](https://docs.microsoft.com/en-us/dotnet/api/System.Environment.NewLine 'System.Environment.NewLine') or a `` at the end of the documentation text depending of the current setting. |
| [EndsWith(string)](MarkdownWriter.EndsWith(string).md 'DefaultDocumentation.Markdown.Writers.MarkdownWriter.EndsWith(string)') | Returns whether the documentation text ends with the given string. |
