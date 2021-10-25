using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    public sealed class MethodDocItem : DocItem, ITypeParameterizedDocItem, IParameterizedDocItem
    {
        public override GeneratedPages Page => GeneratedPages.Methods;

        public IMethod Method { get; }

        public IEnumerable<TypeParameterDocItem> TypeParameters { get; }

        public IEnumerable<ParameterDocItem> Parameters { get; }

        public MethodDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Method = method;
            TypeParameters = method.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }
    }
}
