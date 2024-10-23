#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation')

## IGeneralContextExtensions Class

Provides extension methods on the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext') type\.

```csharp
public static class IGeneralContextExtensions
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; IGeneralContextExtensions

| Methods | |
| :--- | :--- |
| [GetContext\(this IGeneralContext, DocItem\)](GetContext(thisIGeneralContext,DocItem).md 'DefaultDocumentation\.IGeneralContextExtensions\.GetContext\(this DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem\)') | Gets the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') for the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') kind\. |
| [GetSetting&lt;T&gt;\(this IGeneralContext, DocItem, Func&lt;IContext,T&gt;\)](GetSetting.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,DefaultDocumentation.Models.DocItem,System.Func_DefaultDocumentation.IContext,T_) 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, DefaultDocumentation\.Models\.DocItem, System\.Func\<DefaultDocumentation\.IContext,T\>\)') | Gets a data from the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') of the provided [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') if it exists, else from the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')\. |
| [GetSetting&lt;T&gt;\(this IGeneralContext, Type, Func&lt;IContext,T&gt;\)](GetSetting.md#DefaultDocumentation.IGeneralContextExtensions.GetSetting_T_(thisDefaultDocumentation.IGeneralContext,System.Type,System.Func_DefaultDocumentation.IContext,T_) 'DefaultDocumentation\.IGeneralContextExtensions\.GetSetting\<T\>\(this DefaultDocumentation\.IGeneralContext, System\.Type, System\.Func\<DefaultDocumentation\.IContext,T\>\)') | Gets a data from the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') of the provided [System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type') if it exists, else from the [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')\. |
