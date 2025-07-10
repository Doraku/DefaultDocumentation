#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation')

## IGeneralContext Interface

Exposes settings used to generate documentation\.

```csharp
public interface IGeneralContext : DefaultDocumentation.IContext
```

Derived  
&#8627; [IPageContext](../IPageContext/index.md 'DefaultDocumentation\.IPageContext')

Implements [IContext](../IContext/index.md 'DefaultDocumentation\.IContext')

| Properties | |
| :--- | :--- |
| [Elements](Elements.md 'DefaultDocumentation\.IGeneralContext\.Elements') | Gets the [IElement](../Api/IElement/index.md 'DefaultDocumentation\.Api\.IElement') used to render specific [System\.Xml\.Linq\.XElement](https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement 'System\.Xml\.Linq\.XElement') from the documentation\. |
| [Items](Items.md 'DefaultDocumentation\.IGeneralContext\.Items') | Gets all the [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') known by this documentation generation context\. |
| [ItemsWithOwnPage](ItemsWithOwnPage.md 'DefaultDocumentation\.IGeneralContext\.ItemsWithOwnPage') | Gets all the [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') that should generate their own documentation page\. |
| [Settings](Settings.md 'DefaultDocumentation\.IGeneralContext\.Settings') | Gets the [ISettings](../ISettings/index.md 'DefaultDocumentation\.ISettings') of this documentation generation context\. |
| [UrlFactories](UrlFactories.md 'DefaultDocumentation\.IGeneralContext\.UrlFactories') | Gets the [IUrlFactory](../Api/IUrlFactory/index.md 'DefaultDocumentation\.Api\.IUrlFactory') used to create the documentation urls\. |

| Methods | |
| :--- | :--- |
| [GetContext\(Type\)](GetContext(Type).md 'DefaultDocumentation\.IGeneralContext\.GetContext\(System\.Type\)') | Gets the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') for the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')[System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')\. |
| [GetFileName\(DocItem\)](GetFileName(DocItem).md 'DefaultDocumentation\.IGeneralContext\.GetFileName\(DefaultDocumentation\.Models\.DocItem\)') | Gets the file name for the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\. |
