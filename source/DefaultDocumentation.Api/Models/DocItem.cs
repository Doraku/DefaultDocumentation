using System;
using System.Xml.Linq;

namespace DefaultDocumentation.Models;

/// <summary>
/// Represent a documentation item.
/// </summary>
public abstract class DocItem
{
    /// <summary>
    /// Gets the <see cref="DocItem"/> parent of the current instance (for members it is their declaring type, for types it is their namespace, ...).
    /// </summary>
    public DocItem? Parent { get; }

    /// <summary>
    /// Gets the id of the current instance.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the full name of the current instance.
    /// </summary>
    public string FullName { get; }

    /// <summary>
    /// Gets the name of the current instance.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the xml documentation node of the current instance.
    /// </summary>
    public XElement? Documentation { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="DocItem"/> type.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <param name="id">The id.</param>
    /// <param name="fullName">The full name.</param>
    /// <param name="name">The name.</param>
    /// <param name="documentation">The documentation.</param>
    protected DocItem(DocItem? parent, string id, string fullName, string name, XElement? documentation)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(fullName);
        ArgumentNullException.ThrowIfNull(name);

        Parent = parent;
        Id = id;
        FullName = fullName;
        Name = name;
        Documentation = documentation;
    }
}
