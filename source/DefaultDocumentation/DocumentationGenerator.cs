using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DefaultDocumentation.Model;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation
{
    internal sealed class DocumentationGenerator
    {
        private readonly CSharpDecompiler _decompiler;
        private readonly XmlDocumentationProvider _xmlDocumentationProvider;
        private readonly Dictionary<string, DocItem> _docItems;

        public DocumentationGenerator(string assemblyFilePath, string xmlDocumentationFilePath)
        {
            _decompiler = new CSharpDecompiler(assemblyFilePath, new DecompilerSettings());
            _xmlDocumentationProvider = new XmlDocumentationProvider(xmlDocumentationFilePath);
            _docItems = GetDocItems().ToDictionary(i => i.Id);
        }

        private bool TryGetDocumentation(IEntity entity, out XElement documentation)
        {
            string documentationString = _xmlDocumentationProvider.GetDocumentation(entity);
            documentation = documentationString is null ? null : XElement.Parse($"<doc>{documentationString}</doc>");

            return documentation != null;
        }

        private IEnumerable<DocItem> GetDocItems()
        {
            foreach (ITypeDefinition type in _decompiler.TypeSystem.MainModule.TypeDefinitions)
            {
                if (TryGetDocumentation(type, out XElement documentation))
                {
                    yield return type.Kind switch
                    {
                        TypeKind.Class => new ClassDocItem(type, documentation),
                        TypeKind.Struct => new StructDocItem(type, documentation),
                        TypeKind.Interface => new InterfaceDocItem(type, documentation),
                        TypeKind.Enum => new EnumDocItem(type, documentation),
                        TypeKind.Delegate => new DelegateDocItem(type, documentation),
                        _ => throw new NotSupportedException()
                    };

                    foreach (IField field in type.Fields)
                    {
                        if (TryGetDocumentation(type, out documentation))
                        {
                            yield return new FieldDocItem(field, documentation);
                        }
                    }
                    foreach (IProperty property in type.Properties)
                    {
                        if (TryGetDocumentation(property, out documentation))
                        {
                            yield return new PropertyDocItem(property, documentation);
                        }
                    }
                    foreach (IMethod method in type.Methods)
                    {
                        if (TryGetDocumentation(method, out documentation))
                        {
                            if (method.IsConstructor)
                            {
                                yield return new ConstructorDocItem(method, documentation);
                            }
                            else if (method.IsOperator)
                            {
                                yield return new OperatorDocItem(method, documentation);
                            }
                            else
                            {
                                yield return new MethodDocItem(method, documentation);
                            }
                        }
                    }
                    foreach (IEvent @event in type.Events)
                    {
                        if (TryGetDocumentation(@event, out documentation))
                        {
                            yield return new EventDocItem(@event, documentation);
                        }
                    }
                }
            }
        }

        private void WriteHome(string outputFolder)
        {
            using DocumentationWriter writer = new DocumentationWriter(outputFolder, _decompiler.TypeSystem.MainModule.AssemblyName);
            foreach (IGrouping<string, TypeDocItem> group in _docItems.Values.OfType<TypeDocItem>().GroupBy(i => i.Type.Namespace))
            {
                foreach (TypeDocItem item in group.OrderBy(i => i.Type.FullTypeName))
                {

                }
            }
        }

        private void WritePages(string outputFolder)
        {
            _docItems.Values.AsParallel().ForAll(i =>
            {
                using DocumentationWriter writer = new DocumentationWriter(outputFolder, i);

                i.WriteDocumentation(writer, _docItems);
            });
        }

        public void WriteDocumentation(string outputFolder)
        {
            Task.WaitAll(
                Task.Run(() => WriteHome(outputFolder)),
                Task.Run(() => WritePages(outputFolder)));
        }
    }
}
