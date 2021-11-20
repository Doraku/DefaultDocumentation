using DefaultDocumentation.Models;

namespace DefaultDocumentation.Api
{
    public interface IWriter
    {
        IGeneralContext Context { get; }

        DocItem DocItem { get; }

        int Length { get; set; }

        object this[string key] { get; set; }

        IWriter Append(string value);

        IWriter AppendLine();

        bool EndsWith(string value);
    }
}
