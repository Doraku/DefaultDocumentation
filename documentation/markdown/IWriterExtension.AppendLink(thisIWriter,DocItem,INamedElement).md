#### [DefaultDocumentation.Markdown](index.md 'index')
### [DefaultDocumentation.Markdown.Extensions](index.md#DefaultDocumentation.Markdown.Extensions 'DefaultDocumentation.Markdown.Extensions').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Markdown.Extensions.IWriterExtension')

## IWriterExtension.AppendLink(this IWriter, DocItem, INamedElement) Method

Append an link to an [ICSharpCode.Decompiler.TypeSystem.INamedElement](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.INamedElement 'ICSharpCode.Decompiler.TypeSystem.INamedElement') in the markdown format.

```csharp
public static DefaultDocumentation.Api.IWriter AppendLink(this DefaultDocumentation.Api.IWriter writer, DefaultDocumentation.Models.DocItem item, INamedElement element);
```
#### Parameters

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,INamedElement).writer'></a>

`writer` [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter') to use.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,INamedElement).item'></a>

`item` [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem')

The [DocItem](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/DocItem.md 'DefaultDocumentation.Models.DocItem') parent of the element, to get generic information if needed.

<a name='DefaultDocumentation.Markdown.Extensions.IWriterExtension.AppendLink(thisDefaultDocumentation.Api.IWriter,DefaultDocumentation.Models.DocItem,INamedElement).element'></a>

`element` [ICSharpCode.Decompiler.TypeSystem.INamedElement](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.INamedElement 'ICSharpCode.Decompiler.TypeSystem.INamedElement')

The [ICSharpCode.Decompiler.TypeSystem.INamedElement](https://docs.microsoft.com/en-us/dotnet/api/ICSharpCode.Decompiler.TypeSystem.INamedElement 'ICSharpCode.Decompiler.TypeSystem.INamedElement') to link to.

#### Returns
[IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](https://github.com/Doraku/DefaultDocumentation/blob/master/documentation/api/IWriter.md 'DefaultDocumentation.Api.IWriter').