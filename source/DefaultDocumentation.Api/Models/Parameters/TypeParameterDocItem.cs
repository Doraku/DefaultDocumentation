using System.Linq;
using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Parameters;

/// <summary>
/// Represents an <see cref="ITypeParameter"/> documentation.
/// </summary>
public sealed class TypeParameterDocItem : DocItem
{
    /// <summary>
    /// Gets the <see cref="ITypeParameter"/> of the current instance.
    /// </summary>
    public ITypeParameter TypeParameter { get; }

    internal TypeParameterDocItem(DocItem parent, ITypeParameter typeParameter)
        : base(
              parent,
              $"{parent.Id}.{typeParameter.Name}",
              $"{parent.FullName}.{typeParameter.Name}",
              typeParameter.Name,
              parent.Documentation.GetTypeParameters()?.FirstOrDefault(d => d.GetNameAttribute() == typeParameter.Name))
    {
        TypeParameter = typeParameter;
    }
}
