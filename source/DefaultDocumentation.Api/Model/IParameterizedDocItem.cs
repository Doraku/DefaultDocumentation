using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Model
{
    public interface IParameterizedDocItem
    {
        ParameterDocItem[] Parameters { get; }
    }
}
