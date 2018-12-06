using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;

namespace DefaultDocumentation
{
    internal class Converter
    {
        private readonly Dictionary<string, ADocItem> _items;
        private readonly string _outputPath;

        private Converter(XDocument document, string outputPath)
        {
            _items = Parse(document);
            _outputPath = outputPath;
        }

        private static Dictionary<string, ADocItem> Parse(XDocument document)
        {
            Dictionary<string, ADocItem> items = new Dictionary<string, ADocItem>();

            foreach (XElement element in document.GetMembers().Where(e => e.GetFullName().StartsWith(TypeItem.Id)))
            {
                items.Add(element.GetFullName(), new TypeItem(element));
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
                    newItem = new PropertyItem(parent, element);
                }
                else if (fullName.StartsWith(MethodItem.Id))
                {
                    newItem = new MethodItem(parent, element);
                    if (newItem.Name.StartsWith('#'))
                    {
                        newItem = new ConstructorItem(newItem as MethodItem, element);
                    }
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
                writer.Write("### Type parameters");

                foreach (GenericItem generic in item.Generics)
                {
                    writer.Break();
                    writer.Write(generic.FullName().AsLinkTarget());
                    writer.Write($"`{generic.Name}`");
                    WriteSummary(writer, generic);
                }
            }
        }

        private void WriteParameters(DocWriter writer, IParameterDocItem item)
        {
            if (item?.Parameters.Length > 0)
            {
                writer.Write("### Parameters");

                foreach (ParameterItem parameter in item.Parameters)
                {
                    writer.Break();
                    writer.Write(parameter.FullName().AsLinkTarget());
                    writer.Write($"`{parameter.Name}`");
                    WriteSummary(writer, parameter);
                }
            }
        }

        private void WriteExceptions(DocWriter writer, ADocItem item)
        {
            if (item.Exceptions.Length > 0)
            {
                writer.Write("### Exceptions");

                foreach (ExceptionItem exception in item.Exceptions)
                {
                    writer.Break();
                    writer.Write(
                        _items.TryGetValue(exception.Reference, out ADocItem reference)
                        ? reference.FullName().AsLink()
                        : exception.Reference.Substring(2).AsDotNetApiLink());
                    WriteSummary(writer, exception);
                }
            }
        }

        private void WriteReturns(DocWriter writer, MethodItem item)
        {
            if (item?.Return != null)
            {
                writer.Write("### Returns");
                WriteSummary(writer, item.Return);
            }
        }

        private void WriteSummary(DocWriter writer, ADocItem item, bool useBlock = true)
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
                                string referenceName = element.GetReferenceName();
                                if (_items.TryGetValue(referenceName, out ADocItem reference))
                                {
                                    summary += reference.FullName().AsLink();
                                }
                                else
                                {
                                    summary += referenceName.Substring(2).AsDotNetApiLink();
                                }
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

                                if (writer.IsForThis(generic.Parent))
                                {
                                    summary += generic.FullName().AsPageLink(generic.Name);
                                }
                                else
                                {
                                    summary += generic.Parent.FullName().AsLinkWithTarget(generic.FullName(), generic.Name);
                                }
                                break;

                            case "paramref":
                                IParameterDocItem parameterItem = (item as IParameterDocItem) ?? (item.Parent as IParameterDocItem);
                                ParameterItem parameter = parameterItem.Parameters.First(i => i.Name == element.GetName());

                                summary += parameter.FullName().AsPageLink(parameter.Name);
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

            summary = string.Join("<br/>", lines.Skip(firstLine).Select(l => l.Substring(startIndex)));
            while (summary.EndsWith("<br/>"))
            {
                summary = summary.Substring(0, summary.Length - 5);
            }

            string block = useBlock ? ">" : string.Empty;
            writer.Write($"{block}{summary}");
        }

        private void WriteDocFor<T>(DocWriter writer, T item)
            where T : ADocItem, ITitleDocItem
        {
            writer.Write($"### {"README".AsLink()}");
            if (item.Parent != null)
            {
                writer.Write($"### {item.Parent.FullName().AsLink()}");
                writer.Write($"## {item.Name} `{item.Title}`");
            }
            else
            {
                writer.Write($"## {item.FullName()} `{item.Title}`");
            }

            WriteSummary(writer, item, false);

            WriteGenerics(writer, item as AGenericDocItem);
            WriteParameters(writer, item as IParameterDocItem);
            WriteReturns(writer, item as MethodItem);
            WriteExceptions(writer, item);
        }

        private void WriteHome()
        {
            using (DocWriter writer = new DocWriter(_outputPath, "README"))
            {
                writer.Write($"### {"README".AsLink()}");

                foreach (IGrouping<string, TypeItem> typesByNamespace in _items.Values.OfType<TypeItem>().GroupBy(i => i.Namespace).OrderBy(i => i.Key))
                {
                    writer.Write($"## {typesByNamespace.Key}");

                    foreach (TypeItem item in typesByNamespace)
                    {
                        writer.Write($"- {item.FullName().AsLink(item.Name)}");
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
                    writer.Write($"### {item.Title}");
                }

                writer.Write($"- {item.FullName().AsLink(item.Name)}");
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
                    WriteLinkFor<FieldItem>(writer, item);
                    WriteLinkFor<PropertyItem>(writer, item);
                    WriteLinkFor<MethodItem>(writer, item);
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
                Task.Run(converter.WriteDocPages<FieldItem>),
                Task.Run(converter.WriteDocPages<PropertyItem>),
                Task.Run(converter.WriteDocPages<MethodItem>));
        }
    }
}
