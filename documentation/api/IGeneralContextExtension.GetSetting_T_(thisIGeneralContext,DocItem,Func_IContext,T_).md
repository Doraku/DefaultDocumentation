#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtension](IGeneralContextExtension.md 'DefaultDocumentation.IGeneralContextExtension')

## IGeneralContextExtension.GetSetting<T>(this IGeneralContext, DocItem, Func<IContext,T>) Method

Gets a data from the specific [IContext](IContext.md 'DefaultDocumentation.IContext') of the provided [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') if it exists, else from the [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext').

```csharp
public static T? GetSetting<T>(this DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item, System.Func<DefaultDocumentation.IContext,T?> getter);
```
#### Type parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T'></a>

`T`

The type of the data to get.
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).context'></a>

`context` [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation file.

<a name='DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).item'></a>

`item` [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') for which to get a specific setting.

<a name='DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).getter'></a>

`getter` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[IContext](IContext.md 'DefaultDocumentation.IContext')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,DocItem,Func_IContext,T_).md#DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem, System.Func<DefaultDocumentation.IContext,T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The [System.Func&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2') used to get the setting from a [IContext](IContext.md 'DefaultDocumentation.IContext').

#### Returns
[T](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,DocItem,Func_IContext,T_).md#DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem, System.Func<DefaultDocumentation.IContext,T>).T')  
The [T](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,DocItem,Func_IContext,T_).md#DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem, System.Func<DefaultDocumentation.IContext,T>).T') settings from the specific [IContext](IContext.md 'DefaultDocumentation.IContext') if it exists, otherwise from the [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext').

### Remarks
The [T](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,DocItem,Func_IContext,T_).md#DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem, System.Func<DefaultDocumentation.IContext,T>).T') should be [System.Nullable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1') for struct settings.