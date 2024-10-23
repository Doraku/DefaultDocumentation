#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api')

## IUrlFactory Interface

Exposes methods related to the documentation files url creation\.

```csharp
public interface IUrlFactory
```

| Properties | |
| :--- | :--- |
| [Name](Name.md 'DefaultDocumentation\.Api\.IUrlFactory\.Name') | Gets the name of the factory, used to identify it at the configuration level\. |

| Methods | |
| :--- | :--- |
| [GetUrl\(IPageContext, string\)](GetUrl(IPageContext,string).md 'DefaultDocumentation\.Api\.IUrlFactory\.GetUrl\(DefaultDocumentation\.IPageContext, string\)') | Gets the url of the given id\. Returns null of the instance does not know how to handle the provided id\. |
