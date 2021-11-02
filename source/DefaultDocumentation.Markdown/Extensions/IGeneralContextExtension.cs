using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Type;

namespace DefaultDocumentation
{
    public static class IGeneralContextExtension
    {
        private const string NestedTypeVisibilitiesKey = "Markdown.NestedTypeVisibilities";

        public static NestedTypeVisibilities GetNestedTypeVisibilities(this IGeneralContext context, DocItem item)
        {
            NestedTypeVisibilities value = (context.GetContext(item) ?? context).GetSetting<NestedTypeVisibilities>(NestedTypeVisibilitiesKey);

            if (value is NestedTypeVisibilities.Default)
            {
                value = NestedTypeVisibilities.Namespace;
            }

            return value;
        }

        public static IEnumerable<T> GetChildren<T>(this IGeneralContext context, DocItem item)
            where T : DocItem
        {
            IEnumerable<DocItem> GetAllChildren(DocItem item)
            {
                foreach (DocItem child in context.Items.Values.Where(i => i.Parent == item))
                {
                    yield return child;
                    foreach (DocItem indirectChild in GetAllChildren(child))
                    {
                        yield return indirectChild;
                    }
                }
            }

            return (item switch
            {
                NamespaceDocItem when typeof(T).IsSubclassOf(typeof(TypeDocItem)) && (context.GetNestedTypeVisibilities(item) & NestedTypeVisibilities.Namespace) != 0 => GetAllChildren(item),
                TypeDocItem when typeof(T).IsSubclassOf(typeof(TypeDocItem)) && (context.GetNestedTypeVisibilities(item) & NestedTypeVisibilities.DeclaringType) == 0 => Enumerable.Empty<T>(),
                _ => context.Items.Values.Where(i => i.Parent == item)
            }).OfType<T>().OrderBy(c => c.FullName);
        }
    }
}
