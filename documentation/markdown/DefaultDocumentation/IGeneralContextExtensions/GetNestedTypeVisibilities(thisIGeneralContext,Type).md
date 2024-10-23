#### [DefaultDocumentation\.Markdown](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtensions](index.md 'DefaultDocumentation\.IGeneralContextExtensions')

## IGeneralContextExtensions\.GetNestedTypeVisibilities\(this IGeneralContext, Type\) Method

Gets the [Markdown\.NestedTypeVisibilities](https://github.com/Doraku/DefaultDocumentation#MarkdownConfiguration_NestedTypeVisibilities 'https://github\.com/Doraku/DefaultDocumentation\#MarkdownConfiguration\_NestedTypeVisibilities') setting\.

```csharp
public static DefaultDocumentation.Markdown.NestedTypeVisibilities GetNestedTypeVisibilities(this DefaultDocumentation.IGeneralContext context, System.Type type);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtensions.GetNestedTypeVisibilities(thisDefaultDocumentation.IGeneralContext,System.Type).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation file\.

<a name='DefaultDocumentation.IGeneralContextExtensions.GetNestedTypeVisibilities(thisDefaultDocumentation.IGeneralContext,System.Type).type'></a>

`type` [System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type')

The [System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type') for which to get the setting\.

#### Returns
[NestedTypeVisibilities](../Markdown/NestedTypeVisibilities/index.md 'DefaultDocumentation\.Markdown\.NestedTypeVisibilities')  
The [NestedTypeVisibilities](../Markdown/NestedTypeVisibilities/index.md 'DefaultDocumentation\.Markdown\.NestedTypeVisibilities') to use\.