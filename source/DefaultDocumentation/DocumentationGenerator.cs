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
        private readonly Dictionary<string, DocItem> _docItems;

        public DocumentationGenerator(string assemblyFilePath, string documentationFilePath)
        {
            _decompiler = new CSharpDecompiler(assemblyFilePath, new DecompilerSettings())
            {
                DocumentationProvider = new XmlDocumentationProvider(documentationFilePath)
            };

            _docItems = new Dictionary<string, DocItem>();

            foreach (DocItem item in GetDocItems())
            {
                _docItems.Add(item.Id, item);
            }
        }

        private IEnumerable<DocItem> GetDocItems()
        {
            bool TryGetDocumentation(IEntity entity, out XElement documentation)
            {
                string documentationString = _decompiler.DocumentationProvider.GetDocumentation(entity);
                documentation = documentationString is null ? null : XElement.Parse($"<doc>{documentationString}</doc>");

                return documentation != null;
            }

            HomeDocItem homeDocItem = new HomeDocItem(_decompiler.TypeSystem.MainModule.AssemblyName);
            yield return homeDocItem;

            foreach (ITypeDefinition type in _decompiler.TypeSystem.MainModule.TypeDefinitions)
            {
                if (TryGetDocumentation(type, out XElement documentation))
                {
                    string namespaceId = $"N:{type.Namespace}";
                    if (!_docItems.TryGetValue(type.DeclaringType?.GetDefinition().GetIdString() ?? namespaceId, out DocItem parentDocItem))
                    {
                        parentDocItem = new NamespaceDocItem(homeDocItem, type.Namespace);
                        yield return parentDocItem;
                    }

                    TypeDocItem typeDocItem = type.Kind switch
                    {
                        TypeKind.Class => new ClassDocItem(parentDocItem, type, documentation),
                        TypeKind.Struct => new StructDocItem(parentDocItem, type, documentation),
                        TypeKind.Interface => new InterfaceDocItem(parentDocItem, type, documentation),
                        TypeKind.Enum => new EnumDocItem(parentDocItem, type, documentation),
                        TypeKind.Delegate => new DelegateDocItem(parentDocItem, type, documentation),
                        _ => throw new NotSupportedException()
                    };

                    yield return typeDocItem;

                    foreach (IEntity entity in Enumerable.Empty<IEntity>().Concat(type.Fields).Concat(type.Properties).Concat(type.Methods).Concat(type.Events))
                    {
                        if (TryGetDocumentation(entity, out documentation))
                        {
                            yield return entity switch
                            {
                                IField field when typeDocItem is EnumDocItem enumDocItem => new EnumFieldDocItem(enumDocItem, field, documentation),
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

        public void WriteDocumentation(string outputFolderPath)
        {
            _docItems.Values.Where(i => i.GeneratePage).AsParallel().ForAll(i =>
            {
                using DocumentationWriter writer = new DocumentationWriter(_docItems, outputFolderPath, i);

                i.WriteDocumentation(writer, _docItems);
            });
        }
    }
}
