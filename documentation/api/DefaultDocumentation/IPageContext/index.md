#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation')

## IPageContext Interface

Exposes settings used to generate documentation for a specific [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')\.

```csharp
public interface IPageContext : DefaultDocumentation.IGeneralContext, DefaultDocumentation.IContext
```

Implements [IGeneralContext](../IGeneralContext/index.md 'DefaultDocumentation\.IGeneralContext'), [IContext](../IContext/index.md 'DefaultDocumentation\.IContext')

| Properties | |
| :--- | :--- |
| [DocItem](DocItem.md 'DefaultDocumentation\.IPageContext\.DocItem') | Gets the [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') for which the documentation is being generated\. |
| [this\[string\]](this[string].md 'DefaultDocumentation\.IPageContext\.this\[string\]') | Gets or sets extra data for the current [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') documentation generation\. |
