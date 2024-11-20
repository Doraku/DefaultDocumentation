#### [DefaultDocumentation\.Api](../../index.md 'index')
### [DefaultDocumentation](../../index.md#DefaultDocumentation 'DefaultDocumentation').[IDocItemsContext](index.md 'DefaultDocumentation\.IDocItemsContext')

## IDocItemsContext\.GetSetting Method

| Overloads | |
| :--- | :--- |
| [GetSetting&lt;T&gt;\(string\)](GetSetting.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(string) 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(string\)') | Gets a [T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(string\)\.T') setting with the given name\. |
| [GetSetting&lt;T&gt;\(Type, string\)](GetSetting.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string) 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(System\.Type, string\)') | Gets a [T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(System\.Type, string\)\.T') setting with the given name for the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')[System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type')\. |

<a name='DefaultDocumentation.IDocItemsContext.GetSetting_T_(string)'></a>

## IDocItemsContext\.GetSetting\<T\>\(string\) Method

Gets a [T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(string\)\.T') setting with the given name\.

```csharp
T? GetSetting<T>(string name);
```
#### Type parameters

<a name='DefaultDocumentation.IDocItemsContext.GetSetting_T_(string).T'></a>

`T`

The type of the setting to get\.
#### Parameters

<a name='DefaultDocumentation.IDocItemsContext.GetSetting_T_(string).name'></a>

`name` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The name of the setting to get\.

#### Returns
[T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(string\)\.T')  
The setting if present, otherwise the default value of the type [T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(string\)\.T')\.

<a name='DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string)'></a>

## IDocItemsContext\.GetSetting\<T\>\(Type, string\) Method

Gets a [T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(System\.Type, string\)\.T') setting with the given name for the given [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')[System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type')\.

```csharp
T? GetSetting<T>(System.Type? type, string name);
```
#### Type parameters

<a name='DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string).T'></a>

`T`

The type of the setting to get\.
#### Parameters

<a name='DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string).type'></a>

`type` [System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type')

The [DocItem](../Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')[System\.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System\.Type') for which to get the specific setting\.

<a name='DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string).name'></a>

`name` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The name of the setting to get\.

#### Returns
[T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(System\.Type, string\)\.T')  
The setting if present, otherwise the default value of the type [T](index.md#DefaultDocumentation.IDocItemsContext.GetSetting_T_(System.Type,string).T 'DefaultDocumentation\.IDocItemsContext\.GetSetting\<T\>\(System\.Type, string\)\.T')\.