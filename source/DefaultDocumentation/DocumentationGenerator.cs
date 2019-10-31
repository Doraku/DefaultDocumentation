using System;
using System.Collections.Generic;
using System.Linq;
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

        private IEnumerable<DocItem> GetDocItems()
        {
            bool TryGetDocumentation(IEntity entity, out XElement documentation)
            {
                string documentationString = _xmlDocumentationProvider.GetDocumentation(entity);
                documentation = documentationString is null ? null : XElement.Parse($"<doc>{documentationString}</doc>");

                return documentation != null;
            }

            yield return new HomeDocItem(_decompiler.TypeSystem.MainModule.AssemblyName);

            foreach (ITypeDefinition type in _decompiler.TypeSystem.MainModule.TypeDefinitions)
            {
                if (TryGetDocumentation(type, out XElement documentation))
                {
                    TypeDocItem typeDocItem = type.Kind switch
                    {
                        TypeKind.Class => new ClassDocItem(type, documentation),
                        TypeKind.Struct => new StructDocItem(type, documentation),
                        TypeKind.Interface => new InterfaceDocItem(type, documentation),
                        TypeKind.Enum => new EnumDocItem(type, documentation),
                        TypeKind.Delegate => new DelegateDocItem(type, documentation),
                        _ => throw new NotSupportedException()
                    };
                    yield return typeDocItem;

                    foreach (IEntity entity in Enumerable.Empty<IEntity>().Concat(type.Fields).Concat(type.Properties).Concat(type.Methods).Concat(type.Events))
                    {
                        if (TryGetDocumentation(entity, out documentation))
                        {
                            yield return entity switch
                            {
                                IField field => new FieldDocItem(typeDocItem, field, documentation),
                                IProperty property => new PropertyDocItem(typeDocItem, property, documentation),
                                IMethod method when method.IsConstructor => new ConstructorDocItem(typeDocItem, method, documentation),
                                IMethod method when method.IsOperator => new OperatorDocItem(typeDocItem, method, documentation),
                                IMethod method => new MethodDocItem(typeDocItem, method, documentation),
                                IEvent @event => new EventDocItem(typeDocItem, @event, documentation),
                                _ => throw new NotSupportedException()
                            };
                        }
                    }
                }
            }
        }

        public void WriteDocumentation(string outputFolder)
        {
            _docItems.Values.AsParallel().ForAll(i =>
            {
                using DocumentationWriter writer = new DocumentationWriter(outputFolder, i);

                i.WriteDocumentation(writer, _docItems);
            });
        }
    }
}
