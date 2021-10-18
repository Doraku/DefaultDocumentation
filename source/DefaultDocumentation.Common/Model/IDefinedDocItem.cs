using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    internal interface IDefinedDocItem
    {
        XElement Definition { get; }
    }
}
