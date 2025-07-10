#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContextExtensions](index.md 'DefaultDocumentation\.IGeneralContextExtensions')

## IGeneralContextExtensions\.GetSetting Method

| Overloads | |
| :--- | :--- |
| [GetSetting&lt;T&gt;\(this IGeneralContext, DocItem, Func&lt;IContext,T&gt;\)](GetSetting.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_) 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem, System\.Func\<DefaultDocumentation\.IContext,T\>\)') | Gets a data from the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') of the provided [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') if it exists, else from the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')\. |
| [GetSetting&lt;T&gt;\(this IGeneralContext, Type, Func&lt;IContext,T&gt;\)](GetSetting.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_) 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, System\.Type, System\.Func\<DefaultDocumentation\.IContext,T\>\)') | Gets a data from the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') of the provided [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type') if it exists, else from the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')\. |

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_)'></a>

## IGeneralContextExtensions\.GetSetting\<T\>\(this IGeneralContext, DocItem, Func\<IContext,T\>\) Method

Gets a data from the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') of the provided [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') if it exists, else from the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')\.

```csharp
public static T? GetSetting<T>(this DefaultDocumentation.IGeneralContext context, DefaultDocumentation.Models.DocItem item, System.Func<DefaultDocumentation.IContext,T?> getter);
```
#### Type parameters

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T'></a>

`T`

The type of the data to get\.
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).context'></a>

`context` [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation file\.

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).item'></a>

`item` [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which to get a specific setting\.

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).getter'></a>

`getter` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[IContext](../IContext/index.md 'DefaultDocumentation\.IContext')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](index.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem, System\.Func\<DefaultDocumentation\.IContext,T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The [System\.Func&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2') used to get the setting from a [IContext](../IContext/index.md 'DefaultDocumentation\.IContext')\.

#### Returns
[T](index.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem, System\.Func\<DefaultDocumentation\.IContext,T\>\)\.T')  
The [T](index.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem, System\.Func\<DefaultDocumentation\.IContext,T\>\)\.T') settings from the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') if it exists, otherwise from the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')\.

### Remarks
The [T](index.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem, System\.Func\<DefaultDocumentation\.IContext,T\>\)\.T') should be [System\.Nullable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1') for struct settings\.

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_)'></a>

## IGeneralContextExtensions\.GetSetting\<T\>\(this IGeneralContext, Type, Func\<IContext,T\>\) Method

Gets a data from the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') of the provided [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type') if it exists, else from the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')\.

```csharp
public static T? GetSetting<T>(this DefaultDocumentation.IGeneralContext context, System.Type? type, System.Func<DefaultDocumentation.IContext,T?> getter);
```
#### Type parameters

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T'></a>

`T`

The type of the data to get\.
#### Parameters

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).context'></a>

`context` [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')

The [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') of the current documentation file\.

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).type'></a>

`type` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type') for which to get a specific setting\.

<a name='DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).getter'></a>

`getter` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[IContext](../IContext/index.md 'DefaultDocumentation\.IContext')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](index.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, System\.Type, System\.Func\<DefaultDocumentation\.IContext,T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The [System\.Func&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2') used to get the setting from a [IContext](../IContext/index.md 'DefaultDocumentation\.IContext')\.

#### Returns
[T](index.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, System\.Type, System\.Func\<DefaultDocumentation\.IContext,T\>\)\.T')  
The [T](index.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, System\.Type, System\.Func\<DefaultDocumentation\.IContext,T\>\)\.T') settings from the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') if it exists, otherwise from the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')\.

### Remarks
The [T](index.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_).T 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, System\.Type, System\.Func\<DefaultDocumentation\.IContext,T\>\)\.T') should be [System\.Nullable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1') for struct settings\.