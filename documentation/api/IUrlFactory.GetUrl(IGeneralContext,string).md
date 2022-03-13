#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Api](index.md#DefaultDocumentation.Api 'DefaultDocumentation.Api').[IUrlFactory](IUrlFactory.md 'DefaultDocumentation.Api.IUrlFactory')

## IUrlFactory.GetUrl(IGeneralContext, string) Method

Gets thr url of the given id.

```csharp
string? GetUrl(DefaultDocumentation.IGeneralContext context, string id);
```
#### Parameters

<a name='DefaultDocumentation.Api.IUrlFactory.GetUrl(DefaultDocumentation.IGeneralContext,string).context'></a>

`context` [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation generation process.

<a name='DefaultDocumentation.Api.IUrlFactory.GetUrl(DefaultDocumentation.IGeneralContext,string).id'></a>

`id` [System.String](https_//docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The id to get the url for.

#### Returns
[System.String](https_//docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The url of the given id.