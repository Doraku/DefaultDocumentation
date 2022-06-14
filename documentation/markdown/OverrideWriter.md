#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Writers](index.md#DefaultDocumentation.Markdown.Writers 'DefaultDocumentation.Markdown.Writers')

## OverrideWriter Class

Decorator of the [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') type to override its data without changing its actual values.

```csharp
public sealed class OverrideWriter :
DefaultDocumentation.Api.IWriter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OverrideWriter

Implements [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

| Constructors | |
| :--- | :--- |
| [OverrideWriter(IWriter)](OverrideWriter.OverrideWriter(IWriter).md 'DefaultDocumentation.Markdown.Writers.OverrideWriter.OverrideWriter(DefaultDocumentation.Api.IWriter)') | Initializes a new instance of the [OverrideWriter](OverrideWriter.md 'DefaultDocumentation.Markdown.Writers.OverrideWriter') type. |

| Properties | |
| :--- | :--- |
| [Context](OverrideWriter.Context.md 'DefaultDocumentation.Markdown.Writers.OverrideWriter.Context') | Gets the [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process. |
| [DocItem](OverrideWriter.DocItem.md 'DefaultDocumentation.Markdown.Writers.OverrideWriter.DocItem') | Gets the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') for which the documentation is being generated. |
| [Length](OverrideWriter.Length.md 'DefaultDocumentation.Markdown.Writers.OverrideWriter.Length') | Gets or sets the length of the documentation text currently produced. |
| [this[string]](OverrideWriter.this[string].md 'DefaultDocumentation.Markdown.Writers.OverrideWriter.this[string]') | Gets or sets extra data for the current [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') documentation generation. |

| Methods | |
| :--- | :--- |
| [Append(string)](OverrideWriter.Append(string).md 'DefaultDocumentation.Markdown.Writers.OverrideWriter.Append(string)') | Appends a string at the end of the documentation text. |
| [AppendLine()](OverrideWriter.AppendLine().md 'DefaultDocumentation.Markdown.Writers.OverrideWriter.AppendLine()') | Appends a [System.Environment.NewLine](https://docs.microsoft.com/en-us/dotnet/api/System.Environment.NewLine 'System.Environment.NewLine') at the end of the documentation text. |
| [EndsWith(string)](OverrideWriter.EndsWith(string).md 'DefaultDocumentation.Markdown.Writers.OverrideWriter.EndsWith(string)') | Returns whether the documentation text ends with the given string. |
