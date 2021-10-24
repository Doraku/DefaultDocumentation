using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    public sealed class DelegateDocItem : TypeDocItem, IParameterizedDocItem
    {
        public override GeneratedPages Page => GeneratedPages.Delegates;

        public IMethod InvokeMethod { get; }

        public ParameterDocItem[] Parameters { get; }

        public DelegateDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        {
            InvokeMethod = type.GetDelegateInvokeMethod();
            Parameters = InvokeMethod.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }
    }
}
