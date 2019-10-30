using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class ConstructorDocItem : DocItem
    {
        public IMethod Method { get; }

        public ConstructorDocItem(IMethod method, XElement documentation)
            : base(method, documentation)
        {
            Method = method;
        }
    }
}
