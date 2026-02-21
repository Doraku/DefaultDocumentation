using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.PluginExample;

public sealed class NewElement : IElement
{
    public string Name => "new";

    public void Write(IWriter writer, XElement element)
    {
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentNullException.ThrowIfNull(element);

        writer.Append("hello ").Append(element.Value);
    }
}
