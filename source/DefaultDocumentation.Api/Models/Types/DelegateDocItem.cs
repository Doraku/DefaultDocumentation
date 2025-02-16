using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types;

/// <summary>
/// Represents a <see cref="ITypeDefinition"/> of the <see cref="TypeKind.Delegate"/> kind documentation.
/// </summary>
public sealed class DelegateDocItem : TypeDocItem, IParameterizedDocItem
{
    /// <summary>
    /// Gets the <see cref="IMethod"/> of the current instance.
    /// </summary>
    public IMethod InvokeMethod { get; }

    /// <inheritdoc/>
    public IEnumerable<ParameterDocItem> Parameters { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="StructDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="DocItem"/> parent type or namespace of the delegate.</param>
    /// <param name="type">The <see cref="ITypeDefinition"/> of the delegate.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the delegate.</param>
    public DelegateDocItem(DocItem parent, ITypeDefinition type, XElement? documentation)
        : base(parent, type, documentation)
    {
        InvokeMethod = type.GetDelegateInvokeMethod();
        Parameters = [.. InvokeMethod.Parameters.Select(parameter => new ParameterDocItem(this, parameter))];
    }
}
