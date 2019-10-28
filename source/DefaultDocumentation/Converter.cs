using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;
using Mono.Cecil;

namespace DefaultDocumentation
{
    internal sealed class Converter
    {
        private readonly string _outputPath;

        public readonly AssemblyDefinition Assembly;
        public readonly string MainName;
        public readonly Dictionary<string, AMemberItem> Items;

        private Converter(AssemblyDefinition assembly, XDocument document, string outputPath)
        {
            Assembly = assembly;
            MainName = document.GetAssemblyName();
            Items = Parse(document);
            _outputPath = outputPath;
        }

        private Dictionary<string, AMemberItem> Parse(XDocument document)
        {
            Dictionary<string, AMemberItem> items = new Dictionary<string, AMemberItem>();

            AMemberItem HandleTypeItem(XElement typeElement)
            {
                string parentNamespace = typeElement.GetNamespace();

                if (!items.TryGetValue($"{TypeItem.Id}{parentNamespace}", out AMemberItem parent)
                    && !items.TryGetValue($"{NamespaceItem.Id}{parentNamespace}", out parent))
                {
                    parent = new NamespaceItem(parentNamespace);
                    items.Add($"{NamespaceItem.Id}{parent.Name}", parent);
                }

                TypeItem typeItem = new TypeItem(parent, typeElement, Assembly);
                items.Add(typeElement.GetFullName(), typeItem);

                return typeItem;
            }

            foreach (XElement element in document.GetMembers().Where(e => e.GetFullName().StartsWith(TypeItem.Id)))
            {
                HandleTypeItem(element);
            }

            foreach (XElement element in document.GetMembers().Where(e => !e.GetFullName().StartsWith(TypeItem.Id)))
            {
                string parentFullName = element.GetNamespace();
                if (!items.TryGetValue($"{TypeItem.Id}{parentFullName}", out AMemberItem parent))
                {
                    parent = HandleTypeItem(TypeItem.CreateEmptyXElement(parentFullName));
                }
                AMemberItem newItem;

                string fullName = element.GetFullName();
                if (fullName.StartsWith(FieldItem.Id))
                {
                    newItem = new FieldItem(parent, element);
                }
                else if (fullName.StartsWith(PropertyItem.Id))
                {
                    newItem = new PropertyItem(parent, element) as AMemberItem;
                }
                else if (fullName.StartsWith(MethodItem.Id))
                {
                    newItem = new MethodItem(parent, element);
                    newItem =
                        newItem.Name.StartsWith("#")
                        ? new ConstructorItem(newItem as MethodItem)
                        : OperatorItem.HandleOperator(newItem as MethodItem);
                }
                else if (fullName.StartsWith(EventItem.Id))
                {
                    newItem = new EventItem(parent, element);
                }
                else
                {
                    throw new Exception($"unhandled doc item {fullName}");
                }

                items.Add(fullName, newItem);
            }

            return items;
        }

        public void WriteSummary(DocWriter writer, AItem item)
        {
            string summary = string.Empty;

            void WriteNodes(IEnumerable<XNode> nodes)
            {
                foreach (XNode node in nodes)
                {
                    switch (node)
                    {
                        case XText text:
                            summary += string.Join("  \n", text.Value.Split('\n'));
                            break;

                        case XElement element:
                            switch (element.Name.LocalName)
                            {
                                case "see":
                                case "seealso":
                                    string referenceName = element.GetReferenceName();
                                    summary +=
                                        Items.TryGetValue(referenceName, out AMemberItem reference)
                                        ? (reference is NamespaceItem ? reference.AsLinkWithTarget(MainName) : reference.AsLink())
                                        : referenceName.Substring(2).AsDotNetApiLink();
                                    break;

                                case "typeparamref":
                                    AMemberItem parent = item as AMemberItem ?? item.Parent;
                                    GenericItem generic = null;
                                    while (parent != null && generic == null)
                                    {
                                        if (parent is AGenericDocItem genericItem)
                                        {
                                            generic = Array.Find(genericItem.Generics, i => i.Name == element.GetName());
                                        }

                                        parent = parent.Parent;
                                    }

                                    if (generic == null)
                                    {
                                        summary += element.GetName();
                                    }
                                    else
                                    {
                                        summary +=
                                            writer.IsForThis(generic.Parent)
                                            ? generic.AsPageLink()
                                            : generic.AsLinkWithTarget();
                                    }
                                    break;

                                case "paramref":
                                    IParameterDocItem parameterItem = (item as IParameterDocItem) ?? (item.Parent as IParameterDocItem);
                                    ParameterItem parameter = parameterItem.Parameters.First(i => i.Name == element.GetName());

                                    summary += parameter.AsPageLink();
                                    break;

                                case "c":
                                    summary += $"`{element.Value}`";
                                    break;

                                case "code":
                                    summary += $"```{element.Value}```\n";
                                    break;

                                case "para":
                                    summary += "\n\n";
                                    WriteNodes(element.Nodes());
                                    summary += "\n\n";
                                    break;

                                default:
                                    summary += element.ToString();
                                    break;
                            }
                            break;

                        default:
                            throw new Exception($"unhandled node type in summary {node.NodeType}");
                    }
                }
            }

            WriteNodes(item.Summary.Nodes());

            string[] lines = summary.Split('\n');
            int startIndex = 0;
            int firstLine = 0;

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    startIndex = line.Length - line.TrimStart().Length;
                    break;
                }

                ++firstLine;
            }

            summary = string.Join(Environment.NewLine, lines.Skip(firstLine).Select(l => l.StartsWith(" ") ? l.Substring(startIndex) : l));
            while (summary.EndsWith(Environment.NewLine))
            {
                summary = summary.Substring(0, summary.Length - Environment.NewLine.Length);
            }

            writer.WriteLine($"{summary.TrimEnd()}");
        }

        private void WriteDocFor<T>(DocWriter writer, T item)
            where T : AMemberItem
        {
            writer.WriteLine($"#### {MainName.AsLink()}");
            AMemberItem parent = item.Parent;
            Stack<AMemberItem> parents = new Stack<AMemberItem>();
            while (parent != null)
            {
                parents.Push(parent);
                parent = parent.Parent;
            }
            writer.WriteLine($"### {string.Join(".", parents.Select(i => i is NamespaceItem ? i.AsLinkWithTarget(MainName) : i.AsLink()))}");

            item.Write(this, writer);
        }

        private void WriteLinkForType(DocWriter writer, TypeItem item)
        {
            writer.WriteLine($"- {item.AsLink()}");

            foreach (TypeItem nested in Items.Values.OfType<TypeItem>().Where(i => i.Parent == item).OrderBy(i => i.Name))
            {
                WriteLinkForType(writer, nested);
            }
        }

        private void WriteHome()
        {
            using DocWriter writer = new DocWriter(_outputPath, MainName);

            writer.WriteLine($"### {MainName.AsLink()}");

            foreach (NamespaceItem item in Items.Values.OfType<NamespaceItem>().OrderBy(i => i.Name))
            {
                writer.WriteLine(item.AsLinkTarget());
                writer.WriteLine($"## {item.Name}");

                foreach (TypeItem type in Items.Values.OfType<TypeItem>().Where(i => i.Parent == item).OrderBy(i => i.Name))
                {
                    WriteLinkForType(writer, type);
                }
            }
        }

        private void WriteLinkFor<T>(DocWriter writer, AMemberItem parent)
            where T : AMemberItem
        {
            bool hasHeader = false;

            foreach (T item in Items.Values.OfType<T>().Where(i => i.Parent == parent).OrderBy(i => i.Name))
            {
                if (!hasHeader)
                {
                    hasHeader = true;
                    writer.WriteLine($"### {item.Header}");
                }

                writer.WriteLine($"- {item.AsLink()}");
            }
        }

        private void WriteTypePages()
        {
            Items.Values.OfType<TypeItem>().AsParallel().ForAll(item =>
            {
                using DocWriter writer = new DocWriter(_outputPath, item);

                WriteDocFor(writer, item);
                WriteLinkFor<ConstructorItem>(writer, item);
                WriteLinkFor<FieldItem>(writer, item);
                WriteLinkFor<PropertyItem>(writer, item);
                WriteLinkFor<MethodItem>(writer, item);
                WriteLinkFor<EventItem>(writer, item);
                WriteLinkFor<OperatorItem>(writer, item);
            });
        }

        private void WriteDocPages<T>()
            where T : AMemberItem
        {
            Items.Values.OfType<T>().AsParallel().ForAll(item =>
            {
                using DocWriter writer = new DocWriter(_outputPath, item);

                WriteDocFor(writer, item);
            });
        }

        public static void Convert(AssemblyDefinition assembly, XDocument document, string outputPath)
        {
            Converter converter = new Converter(assembly, document, outputPath);

            Task.WaitAll(
                Task.Run(converter.WriteHome),
                Task.Run(converter.WriteTypePages),
                Task.Run(converter.WriteDocPages<ConstructorItem>),
                Task.Run(converter.WriteDocPages<EventItem>),
                Task.Run(converter.WriteDocPages<FieldItem>),
                Task.Run(converter.WriteDocPages<PropertyItem>),
                Task.Run(converter.WriteDocPages<MethodItem>),
                Task.Run(converter.WriteDocPages<OperatorItem>));
        }
    }
}
