#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtension](IGeneralContextExtension.md 'DefaultDocumentation.IGeneralContextExtension')

## IGeneralContextExtension.GetInvalidCharReplacement(this IGeneralContext) Method

Gets the [Markdown.InvalidCharReplacement](https://github.com/Doraku/DefaultDocumentation#invalidcharreplacement 'https://github.com/Doraku/DefaultDocumentation#invalidcharreplacement') setting.

```csharp
public static string? GetInvalidCharReplacement(this DefaultDocumentation.IGeneralContext context);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetInvalidCharReplacement(thisDefaultDocumentation.IGeneralContext).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation file.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') to use to replace invalid chars in generated file name.