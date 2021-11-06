using System.Collections.Generic;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Models
{
    public interface IParameterizedDocItem
    {
        IEnumerable<ParameterDocItem> Parameters { get; }
    }
}
