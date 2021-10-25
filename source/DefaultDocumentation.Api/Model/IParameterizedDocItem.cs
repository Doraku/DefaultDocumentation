using System.Collections.Generic;
using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Model
{
    public interface IParameterizedDocItem
    {
        IEnumerable<ParameterDocItem> Parameters { get; }
    }
}
