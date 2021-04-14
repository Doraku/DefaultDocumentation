using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Model
{
    internal interface IParameterizedDocItem
    {
        ParameterDocItem[] Parameters { get; }
    }
}
