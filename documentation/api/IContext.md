#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation](index.md#DefaultDocumentation 'DefaultDocumentation')

## IContext Interface

Exposes settings used to generate documentation.

```csharp
public interface IContext
```

Derived  
&#8627; [IGeneralContext](IGeneralContext.md 'DefaultDocumentation.IGeneralContext')

| Properties | |
| :--- | :--- |
| [FileNameFactory](IContext.FileNameFactory.md 'DefaultDocumentation.IContext.FileNameFactory') | Gets the [IFileNameFactory](IFileNameFactory.md 'DefaultDocumentation.Api.IFileNameFactory') to use to generate a file for a documentation page. |
| [Sections](IContext.Sections.md 'DefaultDocumentation.IContext.Sections') | Gets the [ISection](ISection.md 'DefaultDocumentation.Api.ISection') to use to generate a documentation page. |

| Methods | |
| :--- | :--- |
| [GetSetting&lt;T&gt;(string)](IContext.GetSetting_T_(string).md 'DefaultDocumentation.IContext.GetSetting<T>(string)') | Gets a [T](IContext.GetSetting_T_(string).md#DefaultDocumentation.IContext.GetSetting_T_(string).T 'DefaultDocumentation.IContext.GetSetting<T>(string).T') setting with the given name. |
