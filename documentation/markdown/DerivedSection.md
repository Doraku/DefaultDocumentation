#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Sections](index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation.Markdown.Sections')

## DerivedSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection') implementation to write the derived type of [TypeDocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/TypeDocItem.md 'DefaultDocumentation.Models.Types.TypeDocItem').

```csharp
public sealed class DerivedSection :
DefaultDocumentation.Api.ISection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DerivedSection

Implements [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection')

| Fields | |
| :--- | :--- |
| [ConfigName](DerivedSection.ConfigName.md 'DefaultDocumentation.Markdown.Sections.DerivedSection.ConfigName') | The name of this implementation used at the configuration level. |

| Properties | |
| :--- | :--- |
| [Name](DerivedSection.Name.md 'DefaultDocumentation.Markdown.Sections.DerivedSection.Name') | Gets the name of the section, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [Write(IWriter)](DerivedSection.Write(IWriter).md 'DefaultDocumentation.Markdown.Sections.DerivedSection.Write(DefaultDocumentation.Api.IWriter)') | Writes the section to a given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter'). |
