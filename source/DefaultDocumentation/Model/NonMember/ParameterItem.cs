using System;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using Mono.Cecil;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ParameterItem : ANamedItem
    {
        public override string Header => "Parameters";

        public ParameterDefinition Parameter { get; }

        public string Signature
        {
            get
            {
                string signature = Parent switch
                {
                    MethodItem methodItem => methodItem.Name.Substring(methodItem.Name.IndexOf('(')).TrimEnd(')'),
                    OperatorItem operatorItem => operatorItem.Name.Substring(operatorItem.Name.IndexOf('(')).TrimEnd(')'),
                    PropertyItem propertyItem => propertyItem.Name.Substring(propertyItem.Name.IndexOf('[')).TrimEnd(']'),
                    _ => throw new NotSupportedException()
                };

                signature = signature.Split(',')[Parameter.Index].Trim();

                return $"{signature} {Name}";
            }
        }

        public ParameterItem(AMemberItem parent, XElement element)
            : base(parent, element)
        {
            Parameter = parent switch
            {
                MethodItem methodItem => methodItem.Method.Parameters.First(p => p.Name == Name),
                OperatorItem operatorItem => operatorItem.Method.Parameters.First(p => p.Name == Name),
                ConstructorItem constructorItem => constructorItem.Constructor.Parameters.First(p => p.Name == Name),
                PropertyItem property => property.Property.Parameters.First(p => p.Name == Name),
                _ => throw new NotSupportedException()
            };
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            string parameterTypeName = Parameter.ParameterType.FullName.Replace('/', '.');
            converter.Items.TryGetValue($"{TypeItem.Id}{parameterTypeName}", out AMemberItem parameterTypeItem);

            writer.WriteLine(this.AsLinkTarget());
            writer.WriteLine($"`{Name}` {parameterTypeItem?.AsLink() ?? parameterTypeName.AsDotNetApiLink()}  ");
            converter.WriteSummary(writer, this);
        }
    }
}