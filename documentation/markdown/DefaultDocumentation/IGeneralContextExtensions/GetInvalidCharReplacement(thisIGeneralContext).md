#### [DefaultDocumentation\.Markdown](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtensions](index.md 'DefaultDocumentation\.IGeneralContextExtensions')

## IGeneralContextExtensions\.GetInvalidCharReplacement\(this IGeneralContext\) Method

Gets the [Markdown\.InvalidCharReplacement](https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_InvalidCharReplacement 'https://github\.com/Doraku/DefaultDocumentation\#MarkdownConfiguration\_InvalidCharReplacement') setting\.

```csharp
public static string? GetInvalidCharReplacement(this DefaultDocumentation.IGeneralContext context);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtensions.GetInvalidCharReplacement(thisDefaultDocumentation.IGeneralContext).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation file\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String') to use to replace invalid chars in generated file name\.