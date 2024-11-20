#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Writers](../../../../index.md#DefaultDocumentation.Markdown.Writers 'DefaultDocumentation\.Markdown\.Writers')

## OverrideWriter Class

Decorator of the [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') type to override its data without changing its actual values\.

```csharp
public sealed class OverrideWriter : DefaultDocumentation.Api.IWriter
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; OverrideWriter

Implements [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

| Constructors | |
| :--- | :--- |
| [OverrideWriter\(IWriter\)](OverrideWriter(IWriter).md 'DefaultDocumentation\.Markdown\.Writers\.OverrideWriter\.OverrideWriter\(DefaultDocumentation\.Api\.IWriter\)') | Initializes a new instance of the [OverrideWriter](index.md 'DefaultDocumentation\.Markdown\.Writers\.OverrideWriter') type\. |

| Properties | |
| :--- | :--- |
| [Context](Context.md 'DefaultDocumentation\.Markdown\.Writers\.OverrideWriter\.Context') | Gets the [IPageContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IPageContext/index.md 'DefaultDocumentation\.IPageContext') of the current documentation generation process\. |
| [Length](Length.md 'DefaultDocumentation\.Markdown\.Writers\.OverrideWriter\.Length') | Gets or sets the length of the documentation text currently produced\. |

| Methods | |
| :--- | :--- |
| [Append\(string\)](Append(string).md 'DefaultDocumentation\.Markdown\.Writers\.OverrideWriter\.Append\(string\)') | Appends a string at the end of the documentation text\. |
| [AppendLine\(\)](AppendLine().md 'DefaultDocumentation\.Markdown\.Writers\.OverrideWriter\.AppendLine\(\)') | Appends a [System\.Environment\.NewLine](https://docs.microsoft.com/en-us/dotnet/api/System.Environment.NewLine 'System\.Environment\.NewLine') at the end of the documentation text\. |
| [EndsWith\(string\)](EndsWith(string).md 'DefaultDocumentation\.Markdown\.Writers\.OverrideWriter\.EndsWith\(string\)') | Returns whether the documentation text ends with the given string\. |
