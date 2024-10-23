#### [DefaultDocumentation\.Markdown](../../../../index.md 'index')
### [DefaultDocumentation\.Markdown\.UrlFactories](../../../../index.md#DefaultDocumentation.Markdown.UrlFactories 'DefaultDocumentation\.Markdown\.UrlFactories').[DotnetApiFactory](index.md 'DefaultDocumentation\.Markdown\.UrlFactories\.DotnetApiFactory')

## DotnetApiFactory\.GetUrl\(IPageContext, string\) Method

Gets the url of the given id\. Returns null of the instance does not know how to handle the provided id\.

```csharp
public string GetUrl(DefaultDocumentation.IPageContext context, string id);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.UrlFactories.DotnetApiFactory.GetUrl(DefaultDocumentation.IPageContext,string).context'></a>

`context` [IPageContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IPageContext/index.md 'DefaultDocumentation\.IPageContext')

The [IPageContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IPageContext/index.md 'DefaultDocumentation\.IPageContext') of the current documentation generation process\.

<a name='DefaultDocumentation.Markdown.UrlFactories.DotnetApiFactory.GetUrl(DefaultDocumentation.IPageContext,string).id'></a>

`id` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The id to get the url for\.

Implements [GetUrl\(IPageContext, string\)](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IUrlFactory/GetUrl(IPageContext,string).md 'DefaultDocumentation\.Api\.IUrlFactory\.GetUrl\(DefaultDocumentation\.IPageContext,System\.String\)')

#### Returns
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')  
The url of the given id\.