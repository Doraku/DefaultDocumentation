#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Writers](../../../../index.md#DefaultDocumentation.Markdown.Writers 'DefaultDocumentation\.Markdown\.Writers')

## MarkdownWriter Class

Decorator of the [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') type to handle the [Markdown\.HandleLineBreak](https://github.com/Doraku/DefaultDocumentation#HandleLineBreak 'https://github\.com/Doraku/DefaultDocumentation\#HandleLineBreak') setting\.
It also uses a [OverrideWriter](../OverrideWriter/index.md 'DefaultDocumentation\.Markdown\.Writers\.OverrideWriter') internally to further decorate the instance\.

```csharp
public sealed class MarkdownWriter : DefaultDocumentation.Api.IWriter
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; MarkdownWriter

Implements [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

| Constructors | |
| :--- | :--- |
| [MarkdownWriter\(IWriter\)](MarkdownWriter(IWriter).md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter\.MarkdownWriter\(DefaultDocumentation\.Api\.IWriter\)') | Initializes a new instance of the [MarkdownWriter](DefaultDocumentation/Markdown/Writers/MarkdownWriter/index.md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter') type\. |

| Properties | |
| :--- | :--- |
| [Context](Context.md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter\.Context') | Gets the [IPageContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IPageContext/index.md 'DefaultDocumentation\.IPageContext') of the current documentation generation process\. |
| [Length](Length.md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter\.Length') | Gets or sets the length of the documentation text currently produced\. |

| Methods | |
| :--- | :--- |
| [Append\(string\)](Append(string).md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter\.Append\(string\)') | Appends a string at the end of the documentation text\. |
| [AppendLine\(\)](AppendLine().md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter\.AppendLine\(\)') | Appends a [System\.Environment\.NewLine](https://docs.microsoft.com/en-us/dotnet/api/System.Environment.NewLine 'System\.Environment\.NewLine') or a `` at the end of the documentation text depending of the current setting\. |
| [EndsWith\(string\)](EndsWith(string).md 'DefaultDocumentation\.Markdown\.Writers\.MarkdownWriter\.EndsWith\(string\)') | Returns whether the documentation text ends with the given string\. |
