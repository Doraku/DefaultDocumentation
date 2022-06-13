using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation
{
    public static class IGeneralContextExtension
    {
        private const string NestedTypeVisibilitiesKey = "Markdown.NestedTypeVisibilities";
        private const string RemoveFileExtensionFromUrlKey = "Markdown.RemoveFileExtensionFromUrl";
        private const string InvalidCharReplacementKey = "Markdown.InvalidCharReplacement";

        public static NestedTypeVisibilities GetNestedTypeVisibilities(this IGeneralContext context, Type type)
        {
            NestedTypeVisibilities value = context.GetSetting(type, c => c.GetSetting<NestedTypeVisibilities?>(NestedTypeVisibilitiesKey)) ?? NestedTypeVisibilities.Default;

            if (value is NestedTypeVisibilities.Default)
            {
                value = NestedTypeVisibilities.Namespace;
            }

            return value;
        }

        public static bool GetRemoveFileExtensionFromUrl(this IGeneralContext context) => context.GetSetting<bool>(RemoveFileExtensionFromUrlKey);

        public static string? GetInvalidCharReplacement(this IGeneralContext context) => context.GetSetting<string>(InvalidCharReplacementKey);

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
                NamespaceDocItem when typeof(T).IsSubclassOf(typeof(TypeDocItem)) && (context.GetNestedTypeVisibilities(typeof(T)) & NestedTypeVisibilities.Namespace) != 0 => GetAllChildren(item),
                TypeDocItem when typeof(T).IsSubclassOf(typeof(TypeDocItem)) && (context.GetNestedTypeVisibilities(typeof(T)) & NestedTypeVisibilities.DeclaringType) == 0 => Enumerable.Empty<T>(),
                _ => context.Items.Values.Where(i => i.Parent == item)
            }).OfType<T>().OrderBy(c => c.FullName);
        }
    }
}
