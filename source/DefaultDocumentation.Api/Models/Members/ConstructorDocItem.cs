using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    /// <summary>
    /// Represents a constructor <see cref="IMethod"/> documentation.
    /// </summary>
    public sealed class ConstructorDocItem : EntityDocItem, IParameterizedDocItem
    {
        /// <summary>
        /// Gets the <see cref="IMethod"/> of the current instance.
        /// </summary>
        public IMethod Method { get; }

        /// <inheritdoc/>
        public IEnumerable<ParameterDocItem> Parameters { get; }

        /// <summary>
        /// Initialize a new instance of the <see cref="ConstructorDocItem"/> type.
        /// </summary>
        /// <param name="parent">The <see cref="TypeDocItem"/> parent type of the constructor.</param>
        /// <param name="method">The <see cref="IMethod"/> of the constructor.</param>
        /// <param name="documentation">The <see cref="XElement"/> documentation element of the constructor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parent"/> or <paramref name="method"/> is null.</exception>
        public ConstructorDocItem(TypeDocItem parent, IMethod method, XElement? documentation)
            : base(
                  parent ?? throw new System.ArgumentNullException(nameof(parent)),
                  method ?? throw new System.ArgumentNullException(nameof(method)),
                  documentation)
        {
            Method = method;
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p)).ToArray();
        }
    }
}
