using DefaultDocumentation.Models;

namespace DefaultDocumentation.Api
{
    public interface IFileNameFactory
    {
        string Name { get; }

        void Clean(IGeneralContext context);

        string GetFileName(IGeneralContext context, DocItem item);
    }
}
