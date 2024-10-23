#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.GetCurrentItem\(this IWriter\) Method

Gets the current item that is being processed by this [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.
It can be different from the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IPageContext/DocItem.md 'DefaultDocumentation\.IPageContext\.DocItem') when inlining child documentation in its parent page\.

```csharp
public static DefaultDocumentation.Models.DocItem GetCurrentItem(this DefaultDocumentation.Api.IWriter writer);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.GetCurrentItem(thisDefaultDocumentation.Api.IWriter).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') for which to get the current item\.

#### Returns
[DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')  
The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which the documentation is being generated\.