#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation')

## IGeneralContextExtension Class

Provides extension methods on the [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext') type.

```csharp
public static class IGeneralContextExtension
```

Inheritance [System.Object](https_//docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; IGeneralContextExtension

| Methods | |
| :--- | :--- |
| [GetContext(this IGeneralContext, DocItem)](IGeneralContextExtension.GetContext(thisIGeneralContext,DocItem).md 'DefaultDocumentation.IGeneralContextExtension.GetContext(this DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the specific [IContext](IContext.md 'DefaultDocumentation.IContext') for the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') kind. |
| [GetSetting&lt;T&gt;(this IGeneralContext, DocItem, Func&lt;IContext,T&gt;)](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,DocItem,Func_IContext,T_).md 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem, System.Func<DefaultDocumentation.IContext,T>)') | Gets a data from the specific [IContext](IContext.md 'DefaultDocumentation.IContext') of the provided [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') if it exists, else from the [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext'). |
| [GetSetting&lt;T&gt;(this IGeneralContext, Type, Func&lt;IContext,T&gt;)](IGeneralContextExtension.GetSetting_T_(thisIGeneralContext,Type,Func_IContext,T_).md 'DefaultDocumentation.IGeneralContextExtension.GetSetting<T>(this DefaultDocumentation.IGeneralContext, System.Type, System.Func<DefaultDocumentation.IContext,T>)') | Gets a data from the specific [IContext](IContext.md 'DefaultDocumentation.IContext') of the provided [System.Type](https_//docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type') if it exists, else from the [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext'). |
| [GetUrl(this IGeneralContext, DocItem)](IGeneralContextExtension.GetUrl(thisIGeneralContext,DocItem).md 'DefaultDocumentation.IGeneralContextExtension.GetUrl(this DefaultDocumentation.IGeneralContext, DefaultDocumentation.Models.DocItem)') | Gets the url of the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem'). |
