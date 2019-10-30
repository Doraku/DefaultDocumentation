using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class OperatorDocItem : DocItem
    {
        public IMethod Method { get; }

        public OperatorDocItem(IMethod method, XElement documentation)
            : base(method, documentation)
        {
            Method = method;
        }
    }
}
