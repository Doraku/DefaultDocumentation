using System;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.PluginExample;

public sealed class NewSection : ISection
{
    public string Name => "New";

    public void Write(IWriter writer)
    {
        writer
            .ThrowIfNull()
            .Append("helloworld");
    }
}
