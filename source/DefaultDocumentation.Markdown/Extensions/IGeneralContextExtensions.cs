using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation
{
    /// <summary>
    /// Provides extension methods on the <see cref="IGeneralContext"/> type.
    /// </summary>
    public static class IGeneralContextExtensions
    {
        private const string NestedTypeVisibilitiesKey = "Markdown.NestedTypeVisibilities";
        private const string RemoveFileExtensionFromUrlKey = "Markdown.RemoveFileExtensionFromUrl";
        private const string InvalidCharReplacementKey = "Markdown.InvalidCharReplacement";
        private const string UseFullUrlKey = "Markdown.UseFullUrl";

        /// <summary>
        /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#nestedtypevisibilities">Markdown.NestedTypeVisibilities</see> setting.
        /// </summary>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
        /// <param name="type">The <see cref="Type"/> for which to get the setting.</param>
        /// <returns>The <see cref="NestedTypeVisibilities"/> to use.</returns>
        public static NestedTypeVisibilities GetNestedTypeVisibilities(this IGeneralContext context, Type type)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(type);

            NestedTypeVisibilities value = context.GetSetting(type, c => c.GetSetting<NestedTypeVisibilities?>(NestedTypeVisibilitiesKey)) ?? NestedTypeVisibilities.Default;

            if (value is NestedTypeVisibilities.Default)
            {
                value = NestedTypeVisibilities.Namespace;
            }

            return value;
        }

        /// <summary>
        /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#removefileextensionfromurl">Markdown.RemoveFileExtensionFromUrl</see> setting.
        /// </summary>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
        /// <returns>Whether to include the file extension in urls.</returns>
        public static bool GetRemoveFileExtensionFromUrl(this IGeneralContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            return context.GetSetting<bool>(RemoveFileExtensionFromUrlKey);
        }

        /// <summary>
        /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#invalidcharreplacement">Markdown.InvalidCharReplacement</see> setting.
        /// </summary>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
        /// <returns>The <see cref="string"/> to use to replace invalid chars in generated file name.</returns>
        public static string? GetInvalidCharReplacement(this IGeneralContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            return context.GetSetting<string>(InvalidCharReplacementKey);
        }

        /// <summary>
        /// Gets the <see href="https://github.com/Doraku/DefaultDocumentation#usefullurl">Markdown.UseFullUrl</see> setting.
        /// </summary>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
        /// <returns>The <see cref="string"/> to use to replace invalid chars in generated file name.</returns>
        public static bool GetUseFullUrl(this IGeneralContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            return context.GetSetting<bool>(UseFullUrlKey);
        }

        /// <summary>
        /// Gets the children of a specific <see cref="DocItem"/> type of a <see cref="DocItem"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of the children to look for.</typeparam>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
        /// <param name="item">The <see cref="DocItem"/> instance for which to get its children.</param>
        /// <returns>The children of the provided <see cref="DocItem"/>.</returns>
        public static IEnumerable<T> GetChildren<T>(this IGeneralContext context, DocItem item)
            where T : DocItem
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(item);

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
