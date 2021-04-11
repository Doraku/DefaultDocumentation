using System.Text;

namespace DefaultDocumentation.Model
{
    internal interface IDefinedDocItem
    {
        void WriteDefinition(StringBuilder builder);
    }
}
