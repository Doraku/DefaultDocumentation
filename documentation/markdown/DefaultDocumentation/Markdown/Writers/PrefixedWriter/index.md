#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Writers](../../../../index.md#DefaultDocumentation.Markdown.Writers 'DefaultDocumentation\.Markdown\.Writers')

## PrefixedWriter Class

Decorator of the [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') type to prefix every new line with a specific [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')\.

```csharp
public sealed class PrefixedWriter : DefaultDocumentation.Api.IWriter
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; PrefixedWriter

Implements [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

| Constructors | |
| :--- | :--- |
| [PrefixedWriter\(IWriter, string\)](PrefixedWriter(IWriter,string).md 'DefaultDocumentation\.Markdown\.Writers\.PrefixedWriter\.PrefixedWriter\(DefaultDocumentation\.Api\.IWriter, string\)') | Initializes a new instance of the [PrefixedWriter](DefaultDocumentation/Markdown/Writers/PrefixedWriter/index.md 'DefaultDocumentation\.Markdown\.Writers\.PrefixedWriter') type\. |

| Properties | |
| :--- | :--- |
| [Context](Context.md 'DefaultDocumentation\.Markdown\.Writers\.PrefixedWriter\.Context') | Gets the [IPageContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IPageContext/index.md 'DefaultDocumentation\.IPageContext') of the current documentation generation process\. |
| [Length](Length.md 'DefaultDocumentation\.Markdown\.Writers\.PrefixedWriter\.Length') | Gets or sets the length of the documentation text currently produced\. |

| Methods | |
| :--- | :--- |
| [Append\(string\)](Append(string).md 'DefaultDocumentation\.Markdown\.Writers\.PrefixedWriter\.Append\(string\)') | Appends a string at the end of the documentation text\. |
| [AppendLine\(\)](AppendLine().md 'DefaultDocumentation\.Markdown\.Writers\.PrefixedWriter\.AppendLine\(\)') | Appends a [System\.Environment\.NewLine](https://docs.microsoft.com/en-us/dotnet/api/System.Environment.NewLine 'System\.Environment\.NewLine') at the end of the documentation text\. |
| [EndsWith\(string\)](EndsWith(string).md 'DefaultDocumentation\.Markdown\.Writers\.PrefixedWriter\.EndsWith\(string\)') | Returns whether the documentation text ends with the given string\. |
