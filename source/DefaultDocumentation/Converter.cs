using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation
{
    internal class Converter
    {
        private readonly string _mainName;
        private readonly Dictionary<string, ADocItem> _items;
        private readonly string _outputPath;

        private Converter(XDocument document, string outputPath)
        {
            _mainName = document.GetAssemblyName();
            _items = Parse(document);
            _outputPath = outputPath;
        }

        private static Dictionary<string, ADocItem> Parse(XDocument document)
        {
            Dictionary<string, ADocItem> items = new Dictionary<string, ADocItem>();

            foreach (XElement element in document.GetMembers().Where(e => e.GetFullName().StartsWith(TypeItem.Id)))
            {
                string parentNamespace = element.GetNamespace();
                ADocItem parent;

                if (!items.TryGetValue($"{TypeItem.Id}{parentNamespace}", out parent)
                    && !items.TryGetValue($"{NamespaceItem.Id}{parentNamespace}", out parent))
                {
                    parent = new NamespaceItem(parentNamespace);
                    items.Add($"{NamespaceItem.Id}{parent.Name}", parent);
                }

                items.Add(element.GetFullName(), new TypeItem(parent, element));
            }

            foreach (XElement element in document.GetMembers().Where(e => !e.GetFullName().StartsWith(TypeItem.Id)))
            {
                ADocItem parent = items[$"{TypeItem.Id}{element.GetNamespace()}"];
                ADocItem newItem;

                string fullName = element.GetFullName();
                if (fullName.StartsWith(FieldItem.Id))
                {
                    newItem = new FieldItem(parent, element);
                }
                else if (fullName.StartsWith(PropertyItem.Id))
                {
                    newItem =
                        fullName.EndsWith(')')
                        ? new IndexItem(new MethodItem(parent, element))
                        : new PropertyItem(parent, element) as ADocItem;
                }
                else if (fullName.StartsWith(MethodItem.Id))
                {
                    newItem = new MethodItem(parent, element);
                    newItem =
                        newItem.Name.StartsWith('#')
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

        private void WriteGenerics(DocWriter writer, AGenericDocItem item)
        {
            if (item?.Generics.Length > 0)
            {
                writer.WriteLine("### Type parameters");

                foreach (GenericItem generic in item.Generics)
                {
                    writer.Break();
                    writer.WriteLine(generic.AsLinkTarget());
                    writer.WriteLine($"`{generic.Name}`");
                    WriteSummary(writer, generic);
                }
            }
        }

        private void WriteParameters(DocWriter writer, IParameterDocItem item)
        {
            if (item?.Parameters.Length > 0)
            {
                writer.WriteLine("### Parameters");

                foreach (ParameterItem parameter in item.Parameters)
                {
                    writer.Break();
                    writer.WriteLine(parameter.AsLinkTarget());
                    writer.WriteLine($"`{parameter.Name}`");
                    WriteSummary(writer, parameter);
                }
            }
        }

        private void WriteExceptions(DocWriter writer, ADocItem item)
        {
            bool hasTitle = false;
            foreach (ExceptionItem exception in item.Exceptions)
            {
                if (!hasTitle)
                {
                    writer.WriteLine("### Exceptions");

                    hasTitle = true;
                }
                writer.Break();
                writer.WriteLine(
                    _items.TryGetValue(exception.Reference, out ADocItem reference)
                    ? reference.AsLink()
                    : exception.Reference.Substring(2).AsDotNetApiLink());
                WriteSummary(writer, exception);
            }
        }

        private void WriteReturns(DocWriter writer, IReturnDocItem item)
        {
            if (item?.Return != null)
            {
                writer.WriteLine("### Returns");
                WriteSummary(writer, item.Return);
            }
        }

        private void WriteRemarks(DocWriter writer, ADocItem item)
        {
            if (item.Remarks != null)
            {
                writer.WriteLine("### Remarks");
                WriteSummary(writer, item.Remarks);
            }
        }

        private void WriteSummary(DocWriter writer, ADocItem item)
        {
            string summary = string.Empty;

            foreach (XNode node in item.Summary.Nodes())
            {
                switch (node)
                {
                    case XText text:
                        summary += text.Value;
                        break;

                    case XElement element:
                        switch (element.Name.LocalName)
                        {
                            case "see":
                            case "seealso":
                                string referenceName = element.GetReferenceName();
                                summary +=
                                    _items.TryGetValue(referenceName, out ADocItem reference)
                                    ? (reference is NamespaceItem ? reference.AsLinkWithTarget(_mainName) : reference.AsLink())
                                    : referenceName.Substring(2).AsDotNetApiLink();
                                break;

                            case "typeparamref":
                                ADocItem parent = item;
                                GenericItem generic = null;
                                while (parent != null && generic == null)
                                {
                                    if (parent is AGenericDocItem genericItem)
                                    {
                                        generic = genericItem.Generics.FirstOrDefault(i => i.Name == element.GetName());
                                    }

                                    parent = parent.Parent;
                                }

                                if (generic == null)
                                {
                                    throw new Exception($"unknown generic type {element.GetName()}");
                                }

                                summary +=
                                    writer.IsForThis(generic.Parent)
                                    ? generic.AsPageLink()
                                    : generic.AsLinkWithTarget();
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
                                summary += $"\n```{element.Value}```\n";
                                break;

                            default:
                                throw new Exception($"unhandled element in summary {element.Name.LocalName}");
                        }
                        break;

                    default:
                        throw new Exception($"unhandled node type in summary {node.NodeType}");
                }
            }

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

            summary = string.Join(Environment.NewLine, lines.Skip(firstLine).Select(l => l.StartsWith(' ') ? l.Substring(startIndex) : l));
            while (summary.EndsWith(Environment.NewLine))
            {
                summary = summary.Substring(0, summary.Length - Environment.NewLine.Length);
            }

            writer.WriteLine($"{summary}");
        }

        private void WriteDocFor<T>(DocWriter writer, T item)
            where T : ADocItem, ITitleDocItem
        {
            writer.WriteLine($"#### {_mainName.AsLink()}");
            ADocItem parent = item.Parent;
            Stack<ADocItem> parents = new Stack<ADocItem>();
            while (parent != null)
            {
                parents.Push(parent);
                parent = parent.Parent;
            }
            writer.WriteLine($"### {string.Join('.', parents.Select(i => i is NamespaceItem ? i.AsLinkWithTarget(_mainName) : i.AsLink()))}");
            writer.WriteLine($"## {item.Name} `{item.Title}`");

            WriteSummary(writer, item);
            WriteRemarks(writer, item);
            WriteGenerics(writer, item as AGenericDocItem);
            WriteParameters(writer, item as IParameterDocItem);
            WriteReturns(writer, item as IReturnDocItem);
            WriteExceptions(writer, item);
        }

        private void WriteLinkForType(DocWriter writer, TypeItem item)
        {
            writer.WriteLine($"- {item.AsLink()}");

            foreach (TypeItem nested in _items.Values.OfType<TypeItem>().Where(i => i.Parent == item).OrderBy(i => i.Name))
            {
                WriteLinkForType(writer, nested);
            }
        }

        private void WriteHome()
        {
            using (DocWriter writer = new DocWriter(_outputPath, _mainName))
            {
                writer.WriteLine($"### {_mainName.AsLink()}");

                foreach (NamespaceItem item in _items.Values.OfType<NamespaceItem>().OrderBy(i => i.Name))
                {
                    writer.WriteLine(item.AsLinkTarget());
                    writer.WriteLine($"## {item.Name}");

                    foreach (TypeItem type in _items.Values.OfType<TypeItem>().Where(i => i.Parent == item).OrderBy(i => i.Name))
                    {
                        WriteLinkForType(writer, type);
                    }
                }
            }
        }

        private void WriteLinkFor<T>(DocWriter writer, ADocItem parent)
            where T : ADocItem, ITitleDocItem
        {
            bool hasTitle = false;

            foreach (T item in _items.Values.OfType<T>().Where(i => i.Parent == parent).OrderBy(i => i.Name))
            {
                if (!hasTitle)
                {
                    hasTitle = true;
                    writer.WriteLine($"### {item.Title}");
                }

                writer.WriteLine($"- {item.AsLink()}");
            }
        }

        private void WriteTypePages()
        {
            _items.Values.OfType<TypeItem>().AsParallel().ForAll(item =>
            {
                using (DocWriter writer = new DocWriter(_outputPath, item))
                {
                    WriteDocFor(writer, item);
                    WriteLinkFor<ConstructorItem>(writer, item);
                    WriteLinkFor<EventItem>(writer, item);
                    WriteLinkFor<FieldItem>(writer, item);
                    WriteLinkFor<PropertyItem>(writer, item);
                    WriteLinkFor<IndexItem>(writer, item);
                    WriteLinkFor<MethodItem>(writer, item);
                    WriteLinkFor<OperatorItem>(writer, item);
                }
            });
        }

        private void WriteDocPages<T>()
            where T : ADocItem, ITitleDocItem
        {
            _items.Values.OfType<T>().AsParallel().ForAll(item =>
            {
                using (DocWriter writer = new DocWriter(_outputPath, item))
                {
                    WriteDocFor(writer, item);
                }
            });
        }

        public static void Convert(XDocument document, string outputPath)
        {
            Converter converter = new Converter(document, outputPath);

            Task.WaitAll(
                Task.Run(converter.WriteHome),
                Task.Run(converter.WriteTypePages),
                Task.Run(converter.WriteDocPages<ConstructorItem>),
                Task.Run(converter.WriteDocPages<EventItem>),
                Task.Run(converter.WriteDocPages<FieldItem>),
                Task.Run(converter.WriteDocPages<PropertyItem>),
                Task.Run(converter.WriteDocPages<IndexItem>),
                Task.Run(converter.WriteDocPages<MethodItem>),
                Task.Run(converter.WriteDocPages<OperatorItem>));
        }
    }
}
