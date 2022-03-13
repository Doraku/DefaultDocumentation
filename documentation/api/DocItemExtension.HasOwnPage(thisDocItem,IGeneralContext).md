#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models](index.md#DefaultDocumentation.Models 'DefaultDocumentation.Models').[DocItemExtension](DocItemExtension.md 'DefaultDocumentation.Models.DocItemExtension')

## DocItemExtension.HasOwnPage(this DocItem, IGeneralContext) Method

Gets wether the given [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') has its own page generated based on a [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext').

```csharp
public static bool HasOwnPage(this DefaultDocumentation.Models.DocItem item, DefaultDocumentation.IGeneralContext context);
```
#### Parameters

<a name='DefaultDocumentation.Models.DocItemExtension.HasOwnPage(thisDefaultDocumentation.Models.DocItem,DefaultDocumentation.IGeneralContext).item'></a>

`item` [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') for which to get if it has its own page.

<a name='DefaultDocumentation.Models.DocItemExtension.HasOwnPage(thisDefaultDocumentation.Models.DocItem,DefaultDocumentation.IGeneralContext).context'></a>

`context` [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

The [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext') used to generation the documentation.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') has its own page, otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').