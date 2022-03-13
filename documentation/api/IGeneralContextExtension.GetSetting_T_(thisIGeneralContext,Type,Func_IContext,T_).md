#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtension](IGeneralContextExtension.md 'DefaultDocumentation.IGeneralContextExtension')

## IGeneralContextExtension.GetSetting<T>(this IGeneralContext, Type, Func<IContext,T>) Method

Gets a data from the specific [IContext](IContext.md 'DefaultDocumentation.IContext') of the provided [System.Type](https_//docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') if it exists, else from the [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext').

```csharp
public static T? GetSetting<T>(this DefaultDocumentation.IGeneralContext context, System.Type type, System.Func<DefaultDocumentation.IContext,T?> getter);
```
#### Type parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T'></a>

`T`

The type of the data to get.
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).context'></a>

`context` [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext') of the current documentation file.

<a name='DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).type'></a>

`type` [System.Type](https_//docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

The [System.Type](https_//docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') for which to get a specific setting.

<a name='DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).getter'></a>

`getter` [System.Func&lt;](https_//docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[IContext](IContext.md 'DefaultDocumentation.IContext')[,](https_//docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,Type,Func_IContext,T_).md#DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, System.Type, System.Func<DefaultDocumentation.IContext,T>).T')[&gt;](https_//docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The [System.Func&lt;&gt;](https_//docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2') used to get the setting from a [IContext](IContext.md 'DefaultDocumentation.IContext').

#### Returns
[T](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,Type,Func_IContext,T_).md#DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, System.Type, System.Func<DefaultDocumentation.IContext,T>).T')  
The [T](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,Type,Func_IContext,T_).md#DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, System.Type, System.Func<DefaultDocumentation.IContext,T>).T') settings from the specific [IContext](IContext.md 'DefaultDocumentation.IContext') if it exists, otherwise from the [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext').

### Remarks
The [T](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,Type,Func_IContext,T_).md#DefaultDocumentation.IGeneralContextExtension.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, System.Type, System.Func<DefaultDocumentation.IContext,T>).T') should be [System.Nullable&lt;&gt;](https_//docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1') for struct settings.