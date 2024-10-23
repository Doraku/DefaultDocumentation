#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.SetCurrentItem\(this IWriter, DocItem\) Method

Sets the current item that is being processed by this [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.
It can be different from the [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IPageContext/DocItem.md 'DefaultDocumentation\.IPageContext\.DocItem') when inlining child documentation in its parent page\.

```csharp
public static DefaultDocumentation.Api.IWriter SetCurrentItem(this DefaultDocumentation.Api.IWriter writer, DefaultDocumentation.Models.DocItem value);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.SetCurrentItem(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') for which to set the current item\.

<a name='DefaultDocumentation.Api.IWriterExtensions.SetCurrentItem(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem).value'></a>

`value` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which the documentation is being generated\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.