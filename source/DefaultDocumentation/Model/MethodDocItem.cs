using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class MethodDocItem : DocItem
    {
        public IMethod Method { get; }

        public MethodDocItem(IMethod method, XElement documentation)
            : base(method, documentation)
        {
            Method = method;
        }
    }
}
