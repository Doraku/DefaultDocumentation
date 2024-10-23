#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation')

## IContext Interface

Exposes settings used to generate documentation for a given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') type\.

```csharp
public interface IContext
```

Derived  
&#8627; [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext')  
&#8627; [IPageContext](../IPageContext/index.md 'DefaultDocumentation\.IPageContext')

| Properties | |
| :--- | :--- |
| [FileNameFactory](FileNameFactory.md 'DefaultDocumentation\.IContext\.FileNameFactory') | Gets the [IFileNameFactory](../Api/IFileNameFactory/index.md 'DefaultDocumentation\.Api\.IFileNameFactory') to use to generate a file for a documentation page\. |
| [Sections](Sections.md 'DefaultDocumentation\.IContext\.Sections') | Gets the [ISection](../Api/ISection/index.md 'DefaultDocumentation\.Api\.ISection') to use to generate a documentation page\. |

| Methods | |
| :--- | :--- |
| [GetSetting&lt;T&gt;\(string\)](GetSetting_T_(string).md 'DefaultDocumentation\.IContext\.GetSetting\<T\>\(string\)') | Gets a [T](GetSetting_T_(string).md#DefaultDocumentation.IContext.GetSetting_T_(string).T 'DefaultDocumentation\.IContext\.GetSetting\<T\>\(string\)\.T') setting with the given name\. |
