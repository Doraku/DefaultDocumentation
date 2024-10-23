#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IGeneralContext](index.md 'DefaultDocumentation\.IGeneralContext')

## IGeneralContext\.GetContext\(Type\) Method

Gets the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') for the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')[System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type')\.

```csharp
DefaultDocumentation.IContext GetContext(System.Type? type);
```
#### Parameters

<a name='DefaultDocumentation.IGeneralContext.GetContext(System.Type).type'></a>

`type` [System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type')

The [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')[System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type') for which to get the specific [IContext](../IContext/index.md 'DefaultDocumentation\.IContext')\.

#### Returns
[IContext](../IContext/index.md 'DefaultDocumentation\.IContext')  
The [IContext](../IContext/index.md 'DefaultDocumentation\.IContext') specific to the provided [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')[System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type')\.