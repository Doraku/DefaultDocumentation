using System.Collections.Generic;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Models;

/// <summary>
/// Exposes <see cref="ParameterDocItem"/> instances.
/// </summary>
public interface IParameterizedDocItem
{
    /// <summary>
    /// Gets the <see cref="ParameterDocItem"/> of this instance.
    /// </summary>
    IEnumerable<ParameterDocItem> Parameters { get; }
}
