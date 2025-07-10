#### [DefaultDocumentation\.Markdown](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtensions](index.md 'DefaultDocumentation\.IGeneralContextExtensions')

## IGeneralContextExtensions\.GetRemoveFileExtensionFromUrl\(this IGeneralContext\) Method

Gets the [Markdown\.RemoveFileExtensionFromUrl](https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_RemoveFileExtensionFromUrl 'https://github\.com/Doraku/DefaultDocumentation\#MarkdownConfiguration\_RemoveFileExtensionFromUrl') setting\.

```csharp
public static bool GetRemoveFileExtensionFromUrl(this DefaultDocumentation.IGeneralContext context);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtensions.GetRemoveFileExtensionFromUrl(thisDefaultDocumentation.IGeneralContext).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation file\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
Whether to include the file extension in urls\.