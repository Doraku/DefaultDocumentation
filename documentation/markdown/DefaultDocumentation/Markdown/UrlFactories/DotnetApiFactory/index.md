#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.UrlFactories](../../../../index.md#DefaultDocumentation.Markdown.UrlFactories 'DefaultDocumentation\.Markdown\.UrlFactories')

## DotnetApiFactory Class

Transforms any id as a dotnet api url\.

```csharp
public sealed class DotnetApiFactory : DefaultDocumentation.Api.IUrlFactory
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; DotnetApiFactory

Implements [IUrlFactory](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IUrlFactory/index.md 'DefaultDocumentation\.Api\.IUrlFactory')

| Fields | |
| :--- | :--- |
| [ConfigName](ConfigName.md 'DefaultDocumentation\.Markdown\.UrlFactories\.DotnetApiFactory\.ConfigName') | The name of this implementation used at the configuration level\. |

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Markdown\.UrlFactories\.DotnetApiFactory\.Name') | Gets the name of the factory, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [GetUrl\(IPageContext, string\)](GetUrl(IPageContext,string).md 'DefaultDocumentation\.Markdown\.UrlFactories\.DotnetApiFactory\.GetUrl\(DefaultDocumentation\.IPageContext, string\)') | Gets the url of the given id\. Returns null of the instance does not know how to handle the provided id\. |
