#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtension](IGeneralContextExtension.md 'DefaultDocumentation.IGeneralContextExtension')

## IGeneralContextExtension.GetNestedTypeVisibilities(this IGeneralContext, Type) Method

Gets the [Markdown.NestedTypeVisibilities](https://github.com/Doraku/DefaultDocumentation#nestedtypevisibilities 'https://github.com/Doraku/DefaultDocumentation#nestedtypevisibilities') setting.

```csharp
public static DefaultDocumentation.NestedTypeVisibilities GetNestedTypeVisibilities(this DefaultDocumentation.IGeneralContext context, System.Type type);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetNestedTypeVisibilities(thisDefaultDocumentation.IGeneralContext,System.Type).context'></a>

`context` [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation file.

<a name='DefaultDocumentation.IGeneralContextExtension.GetNestedTypeVisibilities(thisDefaultDocumentation.IGeneralContext,System.Type).type'></a>

`type` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

The [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') for which to get the setting.

#### Returns
[NestedTypeVisibilities](NestedTypeVisibilities.md 'DefaultDocumentation.NestedTypeVisibilities')  
The [NestedTypeVisibilities](NestedTypeVisibilities.md 'DefaultDocumentation.NestedTypeVisibilities') to use.