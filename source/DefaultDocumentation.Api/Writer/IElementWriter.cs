using System.Xml.Linq;

namespace DefaultDocumentation.Writer
{
    public interface IElementWriter
    {
        string Name { get; }

        void Write(PageWriter writer, XElement element);
    }
}
