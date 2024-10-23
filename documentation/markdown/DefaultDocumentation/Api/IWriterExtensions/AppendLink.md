#### [DefaultDocumentation\.Markdown](../../../index.md 'index')
### [DefaultDocumentation\.Api](../../../index.md#DefaultDocumentation.Api 'DefaultDocumentation\.Api').[IWriterExtensions](index.md 'DefaultDocumentation\.Api\.IWriterExtensions')

## IWriterExtensions\.AppendLink Method

| Overloads | |
| :--- | :--- |
| [AppendLink\(this IWriter, DocItem, INamedElement\)](DefaultDocumentation/Api/IWriterExtensions/AppendLink.md#DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,INamedElement) 'DefaultDocumentation\.Api\.IWriterExtensions\.AppendLink\(this DefaultDocumentation\.Api\.IWriter, DefaultDocumentation\.Models\.DocItem, INamedElement\)') | Append an link to an [ICSharpCode\.Decompiler\.TypeSystem\.INamedElement](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.INamedElement 'ICSharpCode\.Decompiler\.TypeSystem\.INamedElement') in the markdown format\. |
| [AppendLink\(this IWriter, DocItem, string\)](DefaultDocumentation/Api/IWriterExtensions/AppendLink.md#DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,string) 'DefaultDocumentation\.Api\.IWriterExtensions\.AppendLink\(this DefaultDocumentation\.Api\.IWriter, DefaultDocumentation\.Models\.DocItem, string\)') | Append an link to a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') in the markdown format\. |
| [AppendLink\(this IWriter, string, string\)](DefaultDocumentation/Api/IWriterExtensions/AppendLink.md#DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,string,string) 'DefaultDocumentation\.Api\.IWriterExtensions\.AppendLink\(this DefaultDocumentation\.Api\.IWriter, string, string\)') | Append an link to an id using [UrlFactories](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/UrlFactories.md 'DefaultDocumentation\.IGeneralContext\.UrlFactories') to resolve the url in the markdown format\. |

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,INamedElement)'></a>

## IWriterExtensions\.AppendLink\(this IWriter, DocItem, INamedElement\) Method

Append an link to an [ICSharpCode\.Decompiler\.TypeSystem\.INamedElement](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.INamedElement 'ICSharpCode\.Decompiler\.TypeSystem\.INamedElement') in the markdown format\.

```csharp
public static DefaultDocumentation.Api.IWriter AppendLink(this DefaultDocumentation.Api.IWriter writer, DefaultDocumentation.Models.DocItem item, INamedElement element);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,INamedElement).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') to use\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,INamedElement).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') parent of the element, to get generic information if needed\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,INamedElement).element'></a>

`element` [ICSharpCode\.Decompiler\.TypeSystem\.INamedElement](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.INamedElement 'ICSharpCode\.Decompiler\.TypeSystem\.INamedElement')

The [ICSharpCode\.Decompiler\.TypeSystem\.INamedElement](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.INamedElement 'ICSharpCode\.Decompiler\.TypeSystem\.INamedElement') to link to\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,string)'></a>

## IWriterExtensions\.AppendLink\(this IWriter, DocItem, string\) Method

Append an link to a [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') in the markdown format\.

```csharp
public static DefaultDocumentation.Api.IWriter AppendLink(this DefaultDocumentation.Api.IWriter writer, DefaultDocumentation.Models.DocItem item, string? displayedName=null);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') to use\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,string).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Models/DocItem/index.md 'DefaultDocumentation\.Models\.DocItem') to link to\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,string).displayedName'></a>

`displayedName` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The displayed name of the link\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,string,string)'></a>

## IWriterExtensions\.AppendLink\(this IWriter, string, string\) Method

Append an link to an id using [UrlFactories](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/IGeneralContext/UrlFactories.md 'DefaultDocumentation\.IGeneralContext\.UrlFactories') to resolve the url in the markdown format\.

```csharp
public static DefaultDocumentation.Api.IWriter AppendLink(this DefaultDocumentation.Api.IWriter writer, string id, string? displayedName=null);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,string,string).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter') to use\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,string,string).id'></a>

`id` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The id to link to\.

<a name='DefaultDocumentation.Api.IWriterExtensions.AppendLink(thisDefaultDocumentation.Api.IWriter,string,string).displayedName'></a>

`displayedName` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The displayed name of the link\.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DefaultDocumentation/Api/IWriter/index.md 'DefaultDocumentation\.Api\.IWriter')\.