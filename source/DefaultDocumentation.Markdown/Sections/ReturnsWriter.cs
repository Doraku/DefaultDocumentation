using System.Xml.Linq;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ReturnsWriter : ISectionWriter
    {
        public string Name => "returns";

        public void Write(IWriter writer)
        {
            IType returnType = writer.CurrentItem switch
            {
                DelegateDocItem delegateItem => delegateItem.InvokeMethod.ReturnType,
                MethodDocItem methodItem => methodItem.Method.ReturnType,
                OperatorDocItem operatorItem => operatorItem.Method.ReturnType,
                _ => null
            };

            if (returnType != null && returnType.Kind != TypeKind.Void)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("#### Returns")
                    .AppendLink(writer.CurrentItem, returnType)
                    .AppendLine();

                XElement returns = writer.CurrentItem.Documentation.GetReturns();

                if (returns != null)
                {
                    writer.AppendAsMarkdown(returns);
                }
            }
        }
    }
}
