using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model.Base
{
    internal abstract class AGenericDocItem : ADocItem
    {
        public GenericItem[] Generics { get; }

        protected AGenericDocItem(XElement element, string name)
            : base(element, CleanName(name, GetGenericNames(element)))
        {
            Generics = element.GetGenerics().Select(e => new GenericItem(this, e)).ToArray();
        }

        protected AGenericDocItem(string @namespace, XElement element)
            : this(element, element.GetName())
        { }

        protected AGenericDocItem(ADocItem parent, string name, XElement element)
            : base(parent, CleanName(name, GetGenericNames(element)), element)
        {
            Generics = element.GetGenerics().Select(e => new GenericItem(this, e)).ToArray();
        }

        protected AGenericDocItem(ADocItem parent, XElement element)
            : this(parent, element.GetName(), element)
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
