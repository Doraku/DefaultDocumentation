using System.Linq;
using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Parameters
{
    public sealed class ParameterDocItem : DocItem
    {
        public IParameter Parameter { get; }

        internal ParameterDocItem(DocItem parent, IParameter parameter)
            : base(
                  parent,
                  $"{parent.Id}.{parameter.Name}",
                  $"{parent.FullName}.{parameter.Name}",
                  parameter.Name,
                  parent.Documentation.GetParameters()?.FirstOrDefault(d => d.GetNameAttribute() == parameter.Name))
        {
            Parameter = parameter;
        }
    }
}
