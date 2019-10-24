using System;
using System.Reflection;
using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class TypeItem : AGenericDocItem
    {
        public const string Id = "T:";

        private readonly string _title;

        public Type Type { get; }

        public override string Header => "Types";
        public override string Title => _title;

        public TypeItem(AMemberItem parent, XElement item, Assembly assembly)
            : base(parent, item)
        {
            string typeName = GetNameWithoutGeneric(this);

            while (parent != null)
            {
                typeName = $"{GetNameWithoutGeneric(parent)}{(parent is TypeItem ? '+' : '.')}{typeName}";

                parent = parent.Parent;
            }

            Type = assembly.GetType(typeName);
            _title = typeof(Delegate).IsAssignableFrom(Type?.BaseType) ? "delegate" : "type";
        }

        private static string GetNameWithoutGeneric(AMemberItem item)
        {
            if (item is TypeItem typeItem
                && typeItem.Generics.Length > 0)
            {
                return $"{item.Name.Substring(0, item.Name.IndexOf("&lt"))}`{typeItem.Generics.Length}";
            }

            return item.Name;
        }

        public static XElement CreateEmptyXElement(string name) => XElement.Parse($"<member name = \"{Id}{name}\" ><summary></summary></member>");
    }
}
