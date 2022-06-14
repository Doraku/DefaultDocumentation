#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.UrlFactories](index.md#DefaultDocumentation.Markdown.UrlFactories 'DefaultDocumentation.Markdown.UrlFactories').[DocItemFactory](DocItemFactory.md 'DefaultDocumentation.Markdown.UrlFactories.DocItemFactory')

## DocItemFactory.GetUrl(IGeneralContext, string) Method

Gets the url of the given id. Returns null of the instance does not know how to handle the provided id.

```csharp
public string? GetUrl(DefaultDocumentation.IGeneralContext context, string id);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.UrlFactories.DocItemFactory.GetUrl(DefaultDocumentation.IGeneralContext,string).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process.

<a name='DefaultDocumentation.Markdown.UrlFactories.DocItemFactory.GetUrl(DefaultDocumentation.IGeneralContext,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The id to get the url for.

Implements [GetUrl(IGeneralContext, string)](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IUrlFactory.GetUrl(IGeneralContext,string).md 'DefaultDocumentation.Api.IUrlFactory.GetUrl(DefaultDocumentation.IGeneralContext,System.String)')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The url of the given id.