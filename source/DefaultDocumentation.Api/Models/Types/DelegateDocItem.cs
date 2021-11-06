using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    public sealed class DelegateDocItem : TypeDocItem, IParameterizedDocItem
    {
        public IMethod InvokeMethod { get; }

        public IEnumerable<ParameterDocItem> Parameters { get; }

        public DelegateDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        {
            InvokeMethod = type.GetDelegateInvokeMethod();
            Parameters = InvokeMethod.Parameters.Select(p => new ParameterDocItem(this, p)).ToArray();
        }
    }
}
