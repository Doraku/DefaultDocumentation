using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Model
{
    public interface ITypeParameterizedDocItem
    {
        TypeParameterDocItem[] TypeParameters { get; }
    }
}
