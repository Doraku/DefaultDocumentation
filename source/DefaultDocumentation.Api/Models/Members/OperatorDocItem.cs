using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members;

/// <summary>
/// Represents an operator <see cref="IMethod"/> documentation.
/// </summary>
public sealed class OperatorDocItem : EntityDocItem, IParameterizedDocItem
{
    /// <summary>
    /// Gets the <see cref="IMethod"/> of the current instance.
    /// </summary>
    public IMethod Method { get; }

    /// <inheritdoc/>
    public IEnumerable<ParameterDocItem> Parameters { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="OperatorDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="TypeDocItem"/> parent type of the operator.</param>
    /// <param name="method">The <see cref="IMethod"/> of the operator.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the operator.</param>
    public OperatorDocItem(TypeDocItem parent, IMethod method, XElement? documentation)
        : base(
              parent.ThrowIfNull(),
              method.ThrowIfNull(),
              documentation)
    {
        Method = method;
        Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p)).ToArray();
    }
}
