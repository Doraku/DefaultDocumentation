using System;
using System.Xml.Linq;

namespace DefaultDocumentation.Models;

/// <summary>
/// Represents a namespace documentation.
/// </summary>
public sealed class NamespaceDocItem : DocItem
{
    /// <summary>
    /// Initialize a new instance of the <see cref="NamespaceDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="AssemblyDocItem"/> parent assembly of the namespace.</param>
    /// <param name="name">The name of the namespace.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the namespace.</param>
    public NamespaceDocItem(AssemblyDocItem parent, string name, XElement? documentation)
        : base(parent.ThrowIfNull(), $"N:{name}", name, name, documentation)
    { }
}
