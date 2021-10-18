using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    public interface IDefinedDocItem
    {
        XElement Definition { get; }
    }
}
