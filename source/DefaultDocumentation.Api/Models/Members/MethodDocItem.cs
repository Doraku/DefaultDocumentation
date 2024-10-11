using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members;

/// <summary>
/// Represents an <see cref="IMethod"/> documentation.
/// </summary>
public sealed class MethodDocItem : EntityDocItem, ITypeParameterizedDocItem, IParameterizedDocItem
{
    /// <summary>
    /// Gets the <see cref="IMethod"/> of the current instance.
    /// </summary>
    public IMethod Method { get; }

    /// <inheritdoc/>
    public IEnumerable<TypeParameterDocItem> TypeParameters { get; }

    /// <inheritdoc/>
    public IEnumerable<ParameterDocItem> Parameters { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="MethodDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="TypeDocItem"/> parent type of the method.</param>
    /// <param name="method">The <see cref="IMethod"/> of the method.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the method.</param>
    public MethodDocItem(TypeDocItem parent, IMethod method, XElement? documentation)
        : base(
              parent.ThrowIfNull(),
              method.ThrowIfNull(),
              documentation)
    {
        Method = method;
        TypeParameters = method.TypeParameters.Select(typeParameter => new TypeParameterDocItem(this, typeParameter)).ToArray();
        Parameters = method.Parameters.Select(parameter => new ParameterDocItem(this, parameter)).ToArray();
    }
}
