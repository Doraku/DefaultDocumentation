using DefaultDocumentation;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;

using static DefaultDocumentation.Internal.LoggerHelper;

namespace ICSharpCode.Decompiler.TypeSystem;

internal static class IDocItemsContextExtensions
{
    public static void Add(this IDocItemsContext context, DocItem item)
    {
        if (!context.Items.ContainsKey(item.Id))
        {
            LogAddingDocItem(context.Settings.Logger, item);
            context.Items.Add(item.Id, item);

            if (item is ITypeParameterizedDocItem typeParameterized)
            {
                foreach (TypeParameterDocItem typeParameter in typeParameterized.TypeParameters)
                {
                    context.Add(typeParameter);
                }
            }

            if (item is IParameterizedDocItem parameterized)
            {
                foreach (ParameterDocItem parameter in parameterized.Parameters)
                {
                    context.Add(parameter);
                }
            }
        }
        else
        {
            LogDuplicateDocItem(context.Settings.Logger, item);
        }
    }
}
