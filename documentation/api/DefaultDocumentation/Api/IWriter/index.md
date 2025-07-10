#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api')

## IWriter Interface

Exposes properties and methods use to generate a documentation file for a specific [DocItem](../../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public interface IWriter
```

| Properties | |
| :--- | :--- |
| [Context](Context.md 'DefaultDocumentation\.Api\.IWriter\.Context') | Gets the [IPageContext](../../IPageContext/index.md 'DefaultDocumentation\.IPageContext') of the current documentation generation process\. |
| [Length](Length.md 'DefaultDocumentation\.Api\.IWriter\.Length') | Gets or sets the length of the documentation text currently produced\. |

| Methods | |
| :--- | :--- |
| [Append\(string\)](Append(string).md 'DefaultDocumentation\.Api\.IWriter\.Append\(string\)') | Appends a string at the end of the documentation text\. |
| [AppendLine\(\)](AppendLine().md 'DefaultDocumentation\.Api\.IWriter\.AppendLine\(\)') | Appends a [System\.Environment\.NewLine](https://learn.microsoft.com/en-us/dotnet/api/system.environment.newline 'System\.Environment\.NewLine') at the end of the documentation text\. |
| [EndsWith\(string\)](EndsWith(string).md 'DefaultDocumentation\.Api\.IWriter\.EndsWith\(string\)') | Returns whether the documentation text ends with the given string\. |
