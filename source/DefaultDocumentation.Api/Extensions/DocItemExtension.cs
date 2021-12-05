using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Models
{
    /// <summary>
    /// Provides extension methods on the <see cref="DocItem"/> type.
    /// </summary>
    public static class DocItemExtension
    {
        private static GeneratedPages GetPage(DocItem item) => item switch
        {
            AssemblyDocItem => GeneratedPages.Assembly,
            NamespaceDocItem => GeneratedPages.Namespaces,
            ClassDocItem => GeneratedPages.Classes,
            DelegateDocItem => GeneratedPages.Delegates,
            EnumDocItem => GeneratedPages.Enums,
            StructDocItem => GeneratedPages.Structs,
            InterfaceDocItem => GeneratedPages.Interfaces,
            ConstructorDocItem => GeneratedPages.Constructors,
            EventDocItem => GeneratedPages.Events,
            FieldDocItem => GeneratedPages.Fields,
            MethodDocItem => GeneratedPages.Methods,
            OperatorDocItem => GeneratedPages.Operators,
            PropertyDocItem => GeneratedPages.Properties,
            ExplicitInterfaceImplementationDocItem => GeneratedPages.ExplicitInterfaceImplementations,
            _ => GeneratedPages.Default
        };

        /// <summary>
        /// Gets wether the given <see cref="DocItem"/> has its own page generated based on a <see cref="IGeneralContext"/>.
        /// </summary>
        /// <param name="item">The <see cref="DocItem"/> for which to get if it has its own page.</param>
        /// <param name="context">The <see cref="IGeneralContext"/> used to generation the documentation.</param>
        /// <returns><see langword="true"/> if the <see cref="DocItem"/> has its own page, otherwise <see langword="false"/>.</returns>
        public static bool HasOwnPage(this DocItem item, IGeneralContext context) => item switch
        {
            AssemblyDocItem when !string.IsNullOrEmpty(context.Settings.AssemblyPageName) || item.Documentation != null || context.Items.Values.OfType<NamespaceDocItem>().Skip(1).Any() => true,
            _ => (context.Settings.GeneratedPages & GetPage(item)) != 0
        };

        /// <summary>
        /// Searchs recursively on the given <see cref="DocItem"/> parent a <see cref="TypeParameterDocItem"/> with the provided name.
        /// </summary>
        /// <param name="item">The <see cref="DocItem"/> starting point from which to look for a specific <see cref="TypeParameterDocItem"/>.</param>
        /// <param name="name">The name of the <see cref="TypeParameterDocItem"/>.</param>
        /// <param name="typeParameterDocItem">The <see cref="TypeParameterDocItem"/> if found, else <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the <see cref="TypeParameterDocItem"/> was found, else <see langword="false"/>.</returns>
        public static bool TryGetTypeParameterDocItem(this DocItem? item, string name, [NotNullWhen(true)] out TypeParameterDocItem? typeParameterDocItem)
        {
            typeParameterDocItem = null;
            while (item != null && typeParameterDocItem == null)
            {
                if (item is ITypeParameterizedDocItem typeParameters)
                {
                    typeParameterDocItem = typeParameters.TypeParameters.FirstOrDefault(i => i.TypeParameter.Name == name);
                }

                item = item.Parent;
            }

            return typeParameterDocItem != null;
        }

        /// <summary>
        /// Searchs recursively on the given <see cref="DocItem"/> parent a <see cref="ParameterDocItem"/> with the provided name.
        /// </summary>
        /// <param name="item">The <see cref="DocItem"/> starting point from which to look for a specific <see cref="ParameterDocItem"/>.</param>
        /// <param name="name">The name of the <see cref="ParameterDocItem"/>.</param>
        /// <param name="parameterDocItem">The <see cref="ParameterDocItem"/> if found, else <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the <see cref="ParameterDocItem"/> was found, else <see langword="false"/>.</returns>
        public static bool TryGetParameterDocItem(this DocItem? item, string name, [NotNullWhen(true)] out ParameterDocItem? parameterDocItem)
        {
            parameterDocItem = null;
            while (item != null && parameterDocItem == null)
            {
                if (item is IParameterizedDocItem typeParameters)
                {
                    parameterDocItem = typeParameters.Parameters.FirstOrDefault(i => i.Parameter.Name == name);
                }

                item = item.Parent;
            }

            return parameterDocItem != null;
        }

        /// <summary>
        /// Returns all the parents of the given <see cref="DocItem"/>.
        /// </summary>
        /// <param name="item">The <see cref="DocItem"/> for which parents should be returned.</param>
        /// <returns>The parents of the given <see cref="DocItem"/> from the top parent.</returns>
        public static IEnumerable<DocItem> GetParents(this DocItem item)
        {
            Stack<DocItem> parents = new();
            for (DocItem? parent = item.Parent; parent != null; parent = parent.Parent)
            {
                parents.Push(parent);
            }

            return parents;
        }
    }
}
