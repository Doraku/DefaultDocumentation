using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    public sealed class ConstructorDocItem : DocItem, IParameterizedDocItem
    {
        public override GeneratedPages Page => GeneratedPages.Constructors;

        public IMethod Method { get; }

        public IEnumerable<ParameterDocItem> Parameters { get; }

        public ConstructorDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Method = method;
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }
    }
}
