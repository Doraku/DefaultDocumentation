#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Api](index.md#DefaultDocumentation.Api 'DefaultDocumentation.Api')

## IWriter Interface

Exposes properties and methods use to generate a documentation file for a specific [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
public interface IWriter
```

| Properties | |
| :--- | :--- |
| [Context](IWriter.Context.md 'DefaultDocumentation.Api.IWriter.Context') | Gets the [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process. |
| [DocItem](IWriter.DocItem.md 'DefaultDocumentation.Api.IWriter.DocItem') | Gets the [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') for which the documentation is being generated. |
| [Length](IWriter.Length.md 'DefaultDocumentation.Api.IWriter.Length') | Gets or sets the length of the documentation text currently produced. |
| [this[string]](IWriter.this[string].md 'DefaultDocumentation.Api.IWriter.this[string]') | Gets or sets extra data for the current [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') documentation generation. |

| Methods | |
| :--- | :--- |
| [Append(string)](IWriter.Append(string).md 'DefaultDocumentation.Api.IWriter.Append(string)') | Appends a string at the end of the documentation text. |
| [AppendLine()](IWriter.AppendLine().md 'DefaultDocumentation.Api.IWriter.AppendLine()') | Appends a [System.Environment.NewLine](https://docs.microsoft.com/en-us/dotnet/api/System.Environment.NewLine 'System.Environment.NewLine') at the end of the documentation text. |
| [EndsWith(string)](IWriter.EndsWith(string).md 'DefaultDocumentation.Api.IWriter.EndsWith(string)') | Returns whether the documentation text ends with the given string. |
