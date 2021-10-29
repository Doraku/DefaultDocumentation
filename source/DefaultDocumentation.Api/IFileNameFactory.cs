using DefaultDocumentation.Model;

namespace DefaultDocumentation
{
    public interface IFileNameFactory
    {
        string Name { get; }

        void Clean(DocumentationContext context);

        string GetFileName(DocumentationContext context, DocItem item);
    }
}
