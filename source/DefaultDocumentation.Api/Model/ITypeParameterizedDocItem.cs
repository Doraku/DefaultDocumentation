using System.Collections.Generic;
using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Model
{
    public interface ITypeParameterizedDocItem
    {
        IEnumerable<TypeParameterDocItem> TypeParameters { get; }
    }
}
