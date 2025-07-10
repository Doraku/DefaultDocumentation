#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation')

## IDocItemsContext Interface

Exposes properties and methods used to impact the [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') that will be generated, used by [IDocItemGenerator](../Api/IDocItemGenerator/index.md 'DefaultDocumentation\.Api\.IDocItemGenerator')

```csharp
public interface IDocItemsContext
```

| Properties | |
| :--- | :--- |
| [Items](Items.md 'DefaultDocumentation\.IDocItemsContext\.Items') | Gets all the [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') known by this documentation generation context\. |
| [ItemsWithOwnPage](ItemsWithOwnPage.md 'DefaultDocumentation\.IDocItemsContext\.ItemsWithOwnPage') | Gets all the [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') that should generate their own documentation page\. |
| [Settings](Settings.md 'DefaultDocumentation\.IDocItemsContext\.Settings') | Gets the [ISettings](../ISettings/index.md 'DefaultDocumentation\.ISettings') of this documentation generation context\. |

| Methods | |
| :--- | :--- |
| [GetSetting&lt;T&gt;\(string\)](GetSetting.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(string) 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(string\)') | Gets a [T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(string\)\.T') setting with the given name\. |
| [GetSetting&lt;T&gt;\(Type, string\)](GetSetting.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string) 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(System\.Type, string\)') | Gets a [T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(System\.Type, string\)\.T') setting with the given name for the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')[System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')\. |
