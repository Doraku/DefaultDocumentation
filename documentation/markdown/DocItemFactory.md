#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.UrlFactories](index.md#DefaultDocumentation.Markdown.UrlFactories 'DefaultDocumentation.Markdown.UrlFactories')

## DocItemFactory Class

Handles id for known [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem').

```csharp
public sealed class DocItemFactory :
DefaultDocumentation.Api.IUrlFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DocItemFactory

Implements [IUrlFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IUrlFactory.md 'DefaultDocumentation.Api.IUrlFactory')

| Fields | |
| :--- | :--- |
| [ConfigName](DocItemFactory.ConfigName.md 'DefaultDocumentation.Markdown.UrlFactories.DocItemFactory.ConfigName') | The name of this implementation used at the configuration level. |

| Properties | |
| :--- | :--- |
| [Name](DocItemFactory.Name.md 'DefaultDocumentation.Markdown.UrlFactories.DocItemFactory.Name') | Gets the name of the factory, used to identify it at the configuration level. |

| Methods | |
| :--- | :--- |
| [GetUrl(IGeneralContext, string)](DocItemFactory.GetUrl(IGeneralContext,string).md 'DefaultDocumentation.Markdown.UrlFactories.DocItemFactory.GetUrl(DefaultDocumentation.IGeneralContext, string)') | Gets the url of the given id. Returns null of the instance does not know how to handle the provided id. |
