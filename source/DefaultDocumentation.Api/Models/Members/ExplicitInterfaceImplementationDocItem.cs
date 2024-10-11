using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members;

/// <summary>
/// Represents an explicit interface implementation documentation.
/// </summary>
public sealed class ExplicitInterfaceImplementationDocItem : EntityDocItem, ITypeParameterizedDocItem, IParameterizedDocItem
{
    /// <summary>
    /// Gets the <see cref="IMember"/> of the current instance.
    /// It can either be an <see cref="IEvent"/>, <see cref="IProperty"/> or <see cref="IMethod"/>.
    /// </summary>
    public IMember Member { get; }

    /// <inheritdoc/>
    public IEnumerable<TypeParameterDocItem> TypeParameters { get; }

    /// <inheritdoc/>
    public IEnumerable<ParameterDocItem> Parameters { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="ExplicitInterfaceImplementationDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="TypeDocItem"/> parent type of the interface event explicitly implemented.</param>
    /// <param name="event">The <see cref="IEvent"/> of the interface event explicitly implemented.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the interface event explicitly implemented.</param>
    public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IEvent @event, XElement? documentation)
        : base(
              parent.ThrowIfNull(),
              @event.ThrowIfNull(),
              documentation)
    {
        Member = @event;
        TypeParameters = [];
        Parameters = [];
    }

    /// <summary>
    /// Initialize a new instance of the <see cref="ExplicitInterfaceImplementationDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="TypeDocItem"/> parent type of the interface property explicitly implemented.</param>
    /// <param name="property">The <see cref="IProperty"/> of the interface property explicitly implemented.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the interface property explicitly implemented.</param>
    public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IProperty property, XElement? documentation)
        : base(
              parent.ThrowIfNull(),
              property.ThrowIfNull(),
              documentation)
    {
        Member = property;
        TypeParameters = [];
        Parameters = property.Parameters.Select(parameter => new ParameterDocItem(this, parameter)).ToArray();
    }

    /// <summary>
    /// Initialize a new instance of the <see cref="ExplicitInterfaceImplementationDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="TypeDocItem"/> parent type of the interface method explicitly implemented.</param>
    /// <param name="method">The <see cref="IMethod"/> of the interface method explicitly implemented.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the interface method explicitly implemented.</param>
    public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IMethod method, XElement? documentation)
        : base(
              parent.ThrowIfNull(),
              method.ThrowIfNull(),
              documentation)
    {
        Member = method;
        TypeParameters = method.TypeParameters.Select(typeParameter => new TypeParameterDocItem(this, typeParameter)).ToArray();
        Parameters = method.Parameters.Select(parameter => new ParameterDocItem(this, parameter)).ToArray();
    }
}
