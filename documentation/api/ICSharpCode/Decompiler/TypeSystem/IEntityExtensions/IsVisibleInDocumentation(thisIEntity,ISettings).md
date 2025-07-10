#### [DefaultDocumentation\.Api](../../../../index.md 'index')
### [ICSharpCode\.Decompiler\.TypeSystem](../../../../index.md#ICSharpCode.Decompiler.TypeSystem 'ICSharpCode\.Decompiler\.TypeSystem').[IEntityExtensions](index.md 'ICSharpCode\.Decompiler\.TypeSystem\.IEntityExtensions')

## IEntityExtensions\.IsVisibleInDocumentation\(this IEntity, ISettings\) Method

Returns wether an [IEntity](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IEntity') should be part of the documentation or not based on its accessibility\.

```csharp
public static bool IsVisibleInDocumentation(this IEntity? entity, DefaultDocumentation.ISettings settings);
```
#### Parameters

<a name='ICSharpCode.Decompiler.TypeSystem.IEntityExtensions.IsVisibleInDocumentation(thisIEntity,DefaultDocumentation.ISettings).entity'></a>

`entity` [IEntity](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IEntity')

The [IEntity](https://github.com/icsharpcode/ILSpy 'ICSharpCode\.Decompiler\.TypeSystem\.IEntity') to check\.

<a name='ICSharpCode.Decompiler.TypeSystem.IEntityExtensions.IsVisibleInDocumentation(thisIEntity,DefaultDocumentation.ISettings).settings'></a>

`settings` [ISettings](../../../../DefaultDocumentation/ISettings/index.md 'DefaultDocumentation\.ISettings')

The [ISettings](../../../../DefaultDocumentation/ISettings/index.md 'DefaultDocumentation\.ISettings') used to generate the documentation\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the entity should be part of the documentation; otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.