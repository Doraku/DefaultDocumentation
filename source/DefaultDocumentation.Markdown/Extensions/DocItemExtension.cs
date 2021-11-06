using System.Linq;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Models
{
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

        public static string GetLongName(this DocItem item) => string.Join(".", item.GetParents().Skip(2).Select(p => p.Name).Concat(Enumerable.Repeat(item.Name, 1)));

        public static bool HasOwnPage(this DocItem item, IGeneralContext context) => item switch
        {
            AssemblyDocItem when !string.IsNullOrEmpty(context.Settings.AssemblyPageName) || item.Documentation != null || context.GetChildren<NamespaceDocItem>(item).Skip(1).Any() => true,
            _ => (context.Settings.GeneratedPages & GetPage(item)) != 0
        };
    }
}
