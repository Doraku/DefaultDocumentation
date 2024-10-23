#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IPageContextExtensions](index.md 'DefaultDocumentation\.IPageContextExtensions')

## IPageContextExtensions\.GetUrl Method

| Overloads | |
| :--- | :--- |
| [GetUrl\(this IPageContext, DocItem\)](DefaultDocumentation/IPageContextExtensions/GetUrl.md#DefaultDocumentation.IPageContextExtensions.GetUrl(thisDefaultDocumentation.IPageContext,DefaultDocumentation.Models.DocItem) 'DefaultDocumentation\.IPageContextExtensions\.GetUrl\(this DefaultDocumentation\.IPageContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the url of the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') in a specific page\. |
| [GetUrl\(this IPageContext, string\)](DefaultDocumentation/IPageContextExtensions/GetUrl.md#DefaultDocumentation.IPageContextExtensions.GetUrl(thisDefaultDocumentation.IPageContext,string) 'DefaultDocumentation\.IPageContextExtensions\.GetUrl\(this DefaultDocumentation\.IPageContext, string\)') | Gets the url of the given id in a specific page\. |

<a name='DefaultDocumentation.IPageContextExtensions.GetUrl(thisDefaultDocumentation.IPageContext,DefaultDocumentation.Models.DocItem)'></a>

## IPageContextExtensions\.GetUrl\(this IPageContext, DocItem\) Method

Gets the url of the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') in a specific page\.

```csharp
public static string? GetUrl(this DefaultDocumentation.IPageContext context, DefaultDocumentation.Models.DocItem item);
```
#### Parameters

<a name='DefaultDocumentation.IPageContextExtensions.GetUrl(thisDefaultDocumentation.IPageContext,DefaultDocumentation.Models.DocItem).context'></a>

`context` [IPageContext](../IPageContext/index.md 'DefaultDocumentation\.IPageContext')

The [IPageContext](../IPageContext/index.md 'DefaultDocumentation\.IPageContext') of the current documentation file\.

<a name='DefaultDocumentation.IPageContextExtensions.GetUrl(thisDefaultDocumentation.IPageContext,DefaultDocumentation.Models.DocItem).item'></a>

`item` [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which to get the url\.

#### Returns
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')  
The url of the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

<a name='DefaultDocumentation.IPageContextExtensions.GetUrl(thisDefaultDocumentation.IPageContext,string)'></a>

## IPageContextExtensions\.GetUrl\(this IPageContext, string\) Method

Gets the url of the given id in a specific page\.

```csharp
public static string? GetUrl(this DefaultDocumentation.IPageContext context, string id);
```
#### Parameters

<a name='DefaultDocumentation.IPageContextExtensions.GetUrl(thisDefaultDocumentation.IPageContext,string).context'></a>

`context` [IPageContext](../IPageContext/index.md 'DefaultDocumentation\.IPageContext')

The [IPageContext](../IPageContext/index.md 'DefaultDocumentation\.IPageContext') of the current documentation file\.

<a name='DefaultDocumentation.IPageContextExtensions.GetUrl(thisDefaultDocumentation.IPageContext,string).id'></a>

`id` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The id for which to get the url\.

#### Returns
[System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')  
The url of the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.