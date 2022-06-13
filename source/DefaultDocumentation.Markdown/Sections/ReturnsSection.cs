using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ReturnsSection : ISection
    {
        public string Name => "returns";

        public void Write(IWriter writer)
        {
            IType? returnType = writer.GetCurrentItem() switch
            {
                DelegateDocItem delegateItem => delegateItem.InvokeMethod.ReturnType,
                MethodDocItem methodItem => methodItem.Method.ReturnType,
                OperatorDocItem operatorItem => operatorItem.Method.ReturnType,
                _ => null
            };

            if (returnType != null && returnType.Kind != TypeKind.Void)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .AppendLine("#### Returns")
                    .AppendLink(writer.GetCurrentItem(), returnType)
                    .AppendLine("  ")
                    .AppendAsMarkdown(writer.GetCurrentItem().Documentation?.Element(Name));
            }
        }
    }
}
