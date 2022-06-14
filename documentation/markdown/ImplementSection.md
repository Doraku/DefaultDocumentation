#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Sections](index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation.Markdown.Sections')

## ImplementSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection') implementation to write the types/members implemented by the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
public sealed class ImplementSection :
DefaultDocumentation.Api.ISection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImplementSection

Implements [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection')

| Fields | |
| :--- | :--- |
| [ConfigName](ImplementSection.ConfigName.md 'DefaultDocumentation.Markdown.Sections.ImplementSection.ConfigName') | The name of this implementation used at the configuration level. |

| Properties | |
| :--- | :--- |
| [Name](ImplementSection.Name.md 'DefaultDocumentation.Markdown.Sections.ImplementSection.Name') | Gets the name of the section, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [Write(IWriter)](ImplementSection.Write(IWriter).md 'DefaultDocumentation.Markdown.Sections.ImplementSection.Write(DefaultDocumentation.Api.IWriter)') | Writes the section to a given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter'). |
