using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultApiDocumentation.Helper;

namespace DefaultApiDocumentation.Model
{
    internal abstract class AGenericDocItem : ADocItem
    {
        public GenericItem[] Generics { get; }

        protected AGenericDocItem(string @namespace, string name, XElement item)
            : base(@namespace, CleanName(name, GetGenericNames(item)), item.GetSummary())
        {
            Generics = item.GetGenerics().Select(e => new GenericItem(this, e)).ToArray();
        }

        protected AGenericDocItem(string @namespace, XElement item)
            : this(@namespace, item.GetName(), item)
        { }

        protected AGenericDocItem(ADocItem parent, string name, XElement item)
            : base(parent, CleanName(name, GetGenericNames(item)), item)
        {
            Generics = item.GetGenerics().Select(e => new GenericItem(this, e)).ToArray();
        }

        protected AGenericDocItem(ADocItem parent, XElement item)
            : this(parent, item.GetName(), item)
        { }

        private static string CleanName(string name, IEnumerable<string> genericNames)
        {
            if (genericNames.Any())
            {
                int parametersIndex = name.IndexOf('(');
                name = $"{name.Substring(0, name.IndexOf('`'))}&lt;{string.Join(", ", genericNames)}&gt;"
                    + (parametersIndex < 0 ? string.Empty : name.Substring(parametersIndex));
            }

            return name;
        }

        protected static IEnumerable<string> GetGenericNames(XElement item) => item.GetGenerics().Select(e => e.GetName());
    }
}
