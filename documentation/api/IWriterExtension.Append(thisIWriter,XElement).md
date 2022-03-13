#### [DefaultDocumentation.Api](index.md 'index')
### [DefaultDocumentation.Api](index.md#DefaultDocumentation.Api 'DefaultDocumentation.Api').[IWriterExtension](IWriterExtension.md 'DefaultDocumentation.Api.IWriterExtension')

## IWriterExtension.Append(this IWriter, XElement) Method

Appends an [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') to a [IWriter](IWriter.md 'DefaultDocumentation.Api.IWriter') by using the [Elements](IGeneralContext.Elements.md 'DefaultDocumentation.IGeneralContext.Elements') of [Context](IWriter.Context.md 'DefaultDocumentation.Api.IWriter.Context').  
If no [IElement](IElement.md 'DefaultDocumentation.Api.IElement') is found, the [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') is appended as text directly.

```csharp
public static DefaultDocumentation.Api.IWriter Append(this DefaultDocumentation.Api.IWriter writer, System.Xml.Linq.XElement? value);
```
#### Parameters

<a name='DefaultDocumentation.Api.IWriterExtension.Append(thisDefaultDocumentation.Api.IWriter,System.Xml.Linq.XElement).writer'></a>

`writer` [IWriter](IWriter.md 'DefaultDocumentation.Api.IWriter')

The [IWriter](IWriter.md 'DefaultDocumentation.Api.IWriter') to append to.

<a name='DefaultDocumentation.Api.IWriterExtension.Append(thisDefaultDocumentation.Api.IWriter,System.Xml.Linq.XElement).value'></a>

`value` [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

The [System.Xml.Linq.XElement](https_//docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement') to append.

#### Returns
[IWriter](IWriter.md 'DefaultDocumentation.Api.IWriter')  
The given [IWriter](IWriter.md 'DefaultDocumentation.Api.IWriter').