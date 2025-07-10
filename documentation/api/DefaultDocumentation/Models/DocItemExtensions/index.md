#### [DefaultDocumentation\.Api](../../../index.md 'index')
### [DefaultDocumentation\.Models](../../../index.md#DefaultDocumentation.Models 'DefaultDocumentation\.Models')

## DocItemExtensions Class

Provides extension methods on the [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') type\.

```csharp
public static class DocItemExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; DocItemExtensions

| Methods | |
| :--- | :--- |
| [GetParents\(this DocItem\)](GetParents(thisDocItem).md 'DefaultDocumentation\.Models\.DocItemExtensions\.GetParents\(this DefaultDocumentation\.Models\.DocItem\)') | Returns all the parents of the given [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\. |
| [TryGetParameterDocItem\(this DocItem, string, ParameterDocItem\)](TryGetParameterDocItem(thisDocItem,string,ParameterDocItem).md 'DefaultDocumentation\.Models\.DocItemExtensions\.TryGetParameterDocItem\(this DefaultDocumentation\.Models\.DocItem, string, DefaultDocumentation\.Models\.Parameters\.ParameterDocItem\)') | Searchs recursively on the given [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') parent a [ParameterDocItem](../Parameters/ParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.ParameterDocItem') with the provided name\. |
| [TryGetTypeParameterDocItem\(this DocItem, string, TypeParameterDocItem\)](TryGetTypeParameterDocItem(thisDocItem,string,TypeParameterDocItem).md 'DefaultDocumentation\.Models\.DocItemExtensions\.TryGetTypeParameterDocItem\(this DefaultDocumentation\.Models\.DocItem, string, DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem\)') | Searchs recursively on the given [DocItem](../DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') parent a [TypeParameterDocItem](../Parameters/TypeParameterDocItem/index.md 'DefaultDocumentation\.Models\.Parameters\.TypeParameterDocItem') with the provided name\. |
