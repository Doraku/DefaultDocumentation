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
        private readonly XmlDocumentationProvider _documentationProvider;
        private readonly Dictionary<string, DocItem> _docItems;

        public DocumentationGenerator(string assemblyFilePath, string documentationFilePath)
        {
            _decompiler = new CSharpDecompiler(assemblyFilePath, new DecompilerSettings());
            _documentationProvider = new XmlDocumentationProvider(documentationFilePath);

            _docItems = new Dictionary<string, DocItem>();

            foreach (DocItem item in GetDocItems())
            {
                _docItems.Add(item.Id, item);
            }
        }

        private IEnumerable<DocItem> GetDocItems()
        {
            static XElement ConvertToDocumentation(string documentationString) => documentationString is null ? null : XElement.Parse($"<doc>{documentationString}</doc>");

            bool TryGetDocumentation(IEntity entity, out XElement documentation)
            {
                documentation = ConvertToDocumentation(_documentationProvider.GetDocumentation(entity));

                return documentation != null;
            }

            HomeDocItem homeDocItem = new HomeDocItem(_decompiler.TypeSystem.MainModule.AssemblyName, null);
            yield return homeDocItem;

            foreach (ITypeDefinition type in _decompiler.TypeSystem.MainModule.TypeDefinitions.Where(t => t.Name != "NamespaceDoc"))
            {
                bool showType = TryGetDocumentation(type, out XElement documentation);
                bool newNamespace = false;

                string namespaceId = $"N:{type.Namespace}";
                if (!_docItems.TryGetValue(type.DeclaringType?.GetDefinition().GetIdString() ?? namespaceId, out DocItem parentDocItem))
                {
                    newNamespace = true;

                    parentDocItem = new NamespaceDocItem(
                        homeDocItem,
                        type.Namespace,
                        ConvertToDocumentation(_documentationProvider.GetDocumentation(namespaceId) ?? _documentationProvider.GetDocumentation($"T:{type.Namespace}.NamespaceDoc")));
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

                foreach (IEntity entity in Enumerable.Empty<IEntity>().Concat(type.Fields).Concat(type.Properties).Concat(type.Methods).Concat(type.Events))
                {
                    if (TryGetDocumentation(entity, out documentation))
                    {
                        showType = true;

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

                if (showType)
                {
                    if (newNamespace)
                    {
                        yield return parentDocItem;
                    }

                    yield return typeDocItem;
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
