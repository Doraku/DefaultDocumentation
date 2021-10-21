using System.Xml.Linq;

namespace DefaultDocumentation.Writers
{
    public interface IElementWriter
    {
        string Name { get; }

        void Write(IWriter writer, XElement element);
    }
}
