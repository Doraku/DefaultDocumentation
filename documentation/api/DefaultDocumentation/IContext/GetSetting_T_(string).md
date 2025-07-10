#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IContext](index.md 'DefaultDocumentation\.IContext')

## IContext\.GetSetting\<T\>\(string\) Method

Gets a [T](GetSetting_T_(string).md#DefaultDocumentation.IContext.GetSetting_T_(string).T 'DefaultDocumentation\.IContext\.GetSetting\<T\>\(string\)\.T') setting with the given name\.

```csharp
T? GetSetting<T>(string name);
```
#### Type parameters

<a name='DefaultDocumentation.IContext.GetSetting_T_(string).T'></a>

`T`

The type of the setting to get\.
#### Parameters

<a name='DefaultDocumentation.IContext.GetSetting_T_(string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the setting to get\.

#### Returns
[T](GetSetting_T_(string).md#DefaultDocumentation.IContext.GetSetting_T_(string).T 'DefaultDocumentation\.IContext\.GetSetting\<T\>\(string\)\.T')  
The setting if present, otherwise the default value of the type [T](GetSetting_T_(string).md#DefaultDocumentation.IContext.GetSetting_T_(string).T 'DefaultDocumentation\.IContext\.GetSetting\<T\>\(string\)\.T')\.