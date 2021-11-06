using System.Xml.Linq;

namespace DefaultDocumentation.Api
{
    public interface IElement
    {
        string Name { get; }

        void Write(IWriter writer, XElement element);
    }
}
