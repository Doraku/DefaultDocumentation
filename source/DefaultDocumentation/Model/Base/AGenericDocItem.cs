﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model.Base
{
    internal abstract class AGenericDocItem : AMemberItem
    {
        public GenericItem[] Generics { get; }

        protected AGenericDocItem(AMemberItem parent, string name, XElement element)
            : base(parent, CleanName(name, GetGenericNames(element)), element)
        {
            Generics = GenericItem.GetFrom(this);
        }

        protected AGenericDocItem(AMemberItem parent, XElement element)
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