using System.Xml.Linq;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;
using Mono.Cecil;

namespace DefaultDocumentation.Model
{
    internal sealed class TypeItem : AGenericDocItem
    {
        public const string Id = "T:";

        public TypeDefinition Type { get; }

        public override string Header { get; }
        public override string Title { get; }

        public TypeItem(AMemberItem parent, XElement item, AssemblyDefinition assembly)
            : base(parent, item)
        {
            string typeName = GetNameWithoutGeneric(this);

            while (parent != null)
            {
                typeName = $"{GetNameWithoutGeneric(parent)}{(parent is TypeItem ? '/' : '.')}{typeName}";

                parent = parent.Parent;
            }

            Type = assembly.MainModule.GetType(typeName);
            if (Type.BaseType?.FullName == "System.MulticastDelegate")
            {
                Header = "Delegates";
                Title = "delegate";
            }
            else if (Type.IsEnum)
            {
                Header = "Enums";
                Title = "enum";
            }
            else if (Type.IsInterface)
            {
                Header = "Interfaces";
                Title = "interface";
            }
            else if (Type.IsValueType)
            {
                Header = "Structs";
                Title = "struct";
            }
            else
            {
                Header = "Classes";
                Title = "class";
            }
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

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"## {Name} `{Title}`");

            converter.WriteSummary(writer, this);

            writer.WriteLine("```C#");
            writer.Write("public ");
            switch (Title)
            {
                case "delegate":
                    break;

                case "enum":
                    break;

                case "interface":
                    break;

                case "struct":
                    break;

                case "class":
                    if (Type.IsAbstract && Type.IsSealed)
                    {
                        writer.Write("static ");
                    }
                    else if (Type.IsAbstract)
                    {
                        writer.Write("abstract ");
                    }
                    else if (Type.IsSealed)
                    {
                        writer.Write("sealed ");
                    }
                    break;
            }
            writer.WriteLine($"{Title} {Name};");
            writer.WriteLine("```");

            bool hasHeader = false;
            foreach (GenericItem parameter in Generics)
            {
                if (!hasHeader)
                {
                    writer.WriteLine($"### {parameter.Header}");
                    hasHeader = true;
                }
                else
                {
                    writer.Break();
                }

                parameter.Write(converter, writer);
            }

            base.Write(converter, writer);
        }
    }
}
