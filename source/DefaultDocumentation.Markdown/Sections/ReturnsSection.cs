using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ReturnsSection : ISectionWriter
    {
        public string Name => "returns";

        public void Write(IWriter writer)
        {
            IType returnType = writer.GetCurrentItem() switch
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
                    .AppendLine()
                    .AppendLine("#### Returns")
                    .AppendLink(writer.GetCurrentItem(), returnType)
                    .AppendLine("  ")
                    .AppendAsMarkdown(writer.GetCurrentItem().Documentation?.Element(Name));
            }
        }
    }
}
