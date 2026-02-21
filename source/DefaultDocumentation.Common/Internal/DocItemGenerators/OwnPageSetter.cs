using System;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Internal.DocItemGenerators;

internal sealed class OwnPageSetter : IDocItemGenerator
{
    public string Name => nameof(OwnPageSetter);

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
    public static bool HasOwnPage(DocItem item, IDocItemsContext context)
    {
        ArgumentNullException.ThrowIfNull(item);
        ArgumentNullException.ThrowIfNull(context);

        return item switch
        {
            AssemblyDocItem when
                !string.IsNullOrEmpty(context.Settings.AssemblyPageName)
                || item.Documentation != null
                || context.Items.Values.OfType<NamespaceDocItem>().Skip(1).Any()
                || !context.Settings.GeneratedPages.HasFlag(GeneratedPages.Namespaces) => true,
            _ => (context.Settings.GeneratedPages & GetPage(item)) != 0
        };
    }

    public void Generate(IDocItemsContext context)
    {
        foreach (DocItem item in context.Items.Values.Where(item => HasOwnPage(item, context)))
        {
            context.ItemsWithOwnPage.Add(item);
        }
    }
}
