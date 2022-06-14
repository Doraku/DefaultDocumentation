#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtension](IGeneralContextExtension.md 'DefaultDocumentation.IGeneralContextExtension')

## IGeneralContextExtension.GetRemoveFileExtensionFromUrl(this IGeneralContext) Method

Gets the [Markdown.RemoveFileExtensionFromUrl](https://github.com/Doraku/DefaultDocumentation#removefileextensionfromurl 'https://github.com/Doraku/DefaultDocumentation#removefileextensionfromurl') setting.

```csharp
public static bool GetRemoveFileExtensionFromUrl(this DefaultDocumentation.IGeneralContext context);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetRemoveFileExtensionFromUrl(thisDefaultDocumentation.IGeneralContext).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation file.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether to include the file extension in urls.