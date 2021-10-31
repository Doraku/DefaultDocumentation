using DefaultDocumentation.Model;

namespace DefaultDocumentation
{
    public interface IFileNameFactory
    {
        string Name { get; }

        void Clean(IGeneralContext context);

        string GetFileName(IGeneralContext context, DocItem item);
    }
}
