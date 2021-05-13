using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Parameter
{
    internal sealed class ParameterDocItem : DocItem
    {
        public override GeneratedPages Page => GeneratedPages.Default;

        public IParameter Parameter { get; }

        public ParameterDocItem(DocItem parent, IParameter entity, XElement documentation)
            : base(parent, $"{parent.Id}>{entity.Name}", $"{parent.FullName}.{entity.Name}", entity.Name, documentation.GetParameters()?.FirstOrDefault(d => d.GetNameAttribute() == entity.Name))
        {
            Parameter = entity;
        }
    }
}
