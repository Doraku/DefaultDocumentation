#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Models](../../../index.md#DefaultDocumentation.Models 'DefaultDocumentation\.Models')

## DocItem Class

Represent a documentation item\.

```csharp
public abstract class DocItem
```

Inheritance [System\.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System\.Object') &#129106; DocItem

Derived  
&#8627; [AssemblyDocItem](../AssemblyDocItem/index.md 'DefaultDocumentation\.Models\.AssemblyDocItem')  
&#8627; [EntityDocItem](../EntityDocItem/index.md 'DefaultDocumentation\.Models\.EntityDocItem')  
&#8627; [ExternDocItem](../ExternDocItem/index.md 'DefaultDocumentation\.Models\.ExternDocItem')  
&#8627; [NamespaceDocItem](../NamespaceDocItem/index.md 'DefaultDocumentation\.Models\.NamespaceDocItem')  
&#8627; [ParameterDocItem](../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem')  
&#8627; [TypeParameterDocItem](../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem')

| Constructors | |
| :--- | :--- |
| [DocItem\(DocItem, string, string, string, XElement\)](DocItem(DocItem,string,string,string,XElement).md 'DefaultDocumentation\.Models\.DocItem\.DocItem\(DefaultDocumentation\.Models\.DocItem, string, string, string, System\.Xml\.Linq\.XElement\)') | Initialize a new instance of the [DocItem](index.md 'DefaultDocumentation\.Models\.DocItem') type\. |

| Properties | |
| :--- | :--- |
| [Documentation](Documentation.md 'DefaultDocumentation\.Models\.DocItem\.Documentation') | Gets the xml documentation node of the current instance\. |
| [FullName](FullName.md 'DefaultDocumentation\.Models\.DocItem\.FullName') | Gets the full name of the current instance\. |
| [Id](Id.md 'DefaultDocumentation\.Models\.DocItem\.Id') | Gets the id of the current instance\. |
| [Name](Name.md 'DefaultDocumentation\.Models\.DocItem\.Name') | Gets the name of the current instance\. |
| [Parent](Parent.md 'DefaultDocumentation\.Models\.DocItem\.Parent') | Gets the [DocItem](index.md 'DefaultDocumentation\.Models\.DocItem') parent of the current instance \(for members it is their declaring type, for types it is their namespace, \.\.\.\)\. |
