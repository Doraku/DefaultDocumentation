#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Models](index.md#DefaultDocumentation.Models 'DefaultDocumentation.Models')

## DocItem Class

Represent a documentation item.

```csharp
public abstract class DocItem
```

Inheritance [System.Object](https_//docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DocItem

Derived  
&#8627; [AssemblyDocItem](AssemblyDocItem.md 'DefaultDocumentation.Models.AssemblyDocItem')  
&#8627; [EntityDocItem](EntityDocItem.md 'DefaultDocumentation.Models.EntityDocItem')  
&#8627; [ExternDocItem](ExternDocItem.md 'DefaultDocumentation.Models.ExternDocItem')  
&#8627; [NamespaceDocItem](NamespaceDocItem.md 'DefaultDocumentation.Models.NamespaceDocItem')  
&#8627; [ParameterDocItem](ParameterDocItem.md 'DefaultDocumentation.Models.Parameters.ParameterDocItem')  
&#8627; [TypeParameterDocItem](TypeParameterDocItem.md 'DefaultDocumentation.Models.Parameters.TypeParameterDocItem')

| Properties | |
| :--- | :--- |
| [Documentation](DocItem.Documentation.md 'DefaultDocumentation.Models.DocItem.Documentation') | Gets the xml documentation node of the current instance. |
| [FullName](DocItem.FullName.md 'DefaultDocumentation.Models.DocItem.FullName') | Gets the full name of the current instance. |
| [Id](DocItem.Id.md 'DefaultDocumentation.Models.DocItem.Id') | Gets the id of the current instance. |
| [Name](DocItem.Name.md 'DefaultDocumentation.Models.DocItem.Name') | Gets the name of the current instance. |
| [Parent](DocItem.Parent.md 'DefaultDocumentation.Models.DocItem.Parent') | Gets the [DocItem](DocItem.md 'DefaultDocumentation.Models.DocItem') parent of the current instance (for members it is their declaring type, for types it is their namespace, ...). |
