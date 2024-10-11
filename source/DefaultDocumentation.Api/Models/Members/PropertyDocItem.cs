using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members;

/// <summary>
/// Represents an <see cref="IProperty"/> documentation.
/// </summary>
public sealed class PropertyDocItem : EntityDocItem, IParameterizedDocItem
{
    /// <summary>
    /// Gets the <see cref="IProperty"/> of the current instance.
    /// </summary>
    public IProperty Property { get; }

    /// <inheritdoc/>
    public IEnumerable<ParameterDocItem> Parameters { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="PropertyDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="TypeDocItem"/> parent type of the property.</param>
    /// <param name="property">The <see cref="IProperty"/> of the property.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the property.</param>
    public PropertyDocItem(TypeDocItem parent, IProperty property, XElement? documentation)
        : base(
              parent.ThrowIfNull(),
              property.ThrowIfNull(),
              documentation)
    {
        Property = property;
        Parameters = Property.Parameters.Select(parameter => new ParameterDocItem(this, parameter)).ToArray();
    }
}
