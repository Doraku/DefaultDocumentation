using System;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using Mono.Cecil;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ReturnItem : AItem
    {
        public override string Header => "Returns";

        public TypeReference Type { get; }

        public bool IsVoid => Type.FullName == "System.Void";

        public ReturnItem(AMemberItem parent, XElement element)
            : base(parent, element)
        {
            Type = parent switch
            {
                MethodItem methodItem => methodItem.Method.ReturnType,
                OperatorItem operatorItem => operatorItem.Method.ReturnType,
                _ => throw new NotSupportedException()
            };
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"### {Header}");
            if (!IsVoid)
            {
                string returnTypeName = Type.FullName.Replace('/', '.');
                converter.Items.TryGetValue($"{TypeItem.Id}{returnTypeName}", out AMemberItem returnTypeItem);
                writer.WriteLine(returnTypeItem?.AsLink() ?? returnTypeName.AsDotNetApiLink());
            }
            converter.WriteSummary(writer, this);
        }
    }
}
