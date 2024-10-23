#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IUrlFactory](index.md 'DefaultDocumentation\.Api\.IUrlFactory')

## IUrlFactory\.GetUrl\(IPageContext, string\) Method

Gets the url of the given id\. Returns null of the instance does not know how to handle the provided id\.

```csharp
string? GetUrl(DefaultDocumentation.IPageContext context, string id);
```
#### Parameters

<a name='DefaultDocumentation.Api.IUrlFactory.GetUrl(DefaultDocumentation.IPageContext,string).context'></a>

`context` [IPageContext](../../IPageContext/index.md 'DefaultDocumentation\.IPageContext')

The [IPageContext](../../IPageContext/index.md 'DefaultDocumentation\.IPageContext') of the current documentation generation process\.

<a name='DefaultDocumentation.Api.IUrlFactory.GetUrl(DefaultDocumentation.IPageContext,string).id'></a>

`id` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The id to get the url for\.

#### Returns
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')  
The url of the given id\.