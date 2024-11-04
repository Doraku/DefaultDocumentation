#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.Sections](../../../../index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation\.Markdown\.Sections')

## SummarySection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') implementation to write the `summary` top level element\.

```csharp
public sealed class SummarySection : DefaultDocumentation.Api.ISection
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; SummarySection

Implements [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection')

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.Sections\.SummarySection\.ConfigName') | The name of this implementation used at the configuration level\. |

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.Sections\.SummarySection\.Name') | Gets the name of the section, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [Write\(IWriter\)](Write(IWriter).md 'DefaultDocumentation\.Markdown\.Sections\.SummarySection\.Write\(DefaultDocumentation\.Api\.IWriter\)') | Writes the section to a given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\. |