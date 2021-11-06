using System.Collections.Generic;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Models
{
    public interface ITypeParameterizedDocItem
    {
        IEnumerable<TypeParameterDocItem> TypeParameters { get; }
    }
}
