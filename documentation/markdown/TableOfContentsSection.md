#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Sections](index.md#DefaultDocumentation.Markdown.Sections 'DefaultDocumentation.Markdown.Sections')

## TableOfContentsSection Class

[ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection') implementation to write a table of content of all children of the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
public sealed class TableOfContentsSection :
DefaultDocumentation.Api.ISection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TableOfContentsSection

Implements [ISection](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/ISection.md 'DefaultDocumentation.Api.ISection')

| Fields | |
| :--- | :--- |
| [ConfigName](TableOfContentsSection.ConfigName.md 'DefaultDocumentation.Markdown.Sections.TableOfContentsSection.ConfigName') | The name of this implementation used at the configuration level. |

| Properties | |
| :--- | :--- |
| [Name](TableOfContentsSection.Name.md 'DefaultDocumentation.Markdown.Sections.TableOfContentsSection.Name') | Gets the name of the section, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [Write(IWriter)](TableOfContentsSection.Write(IWriter).md 'DefaultDocumentation.Markdown.Sections.TableOfContentsSection.Write(DefaultDocumentation.Api.IWriter)') | Writes the section to a given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter'). |
