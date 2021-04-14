using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Resolver;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation
{
    internal sealed class DocItemReader
    {
        private readonly CSharpDecompiler _decompiler;
        private readonly CSharpResolver _resolver;
        private readonly Dictionary<IModule, IDocumentationProvider> _documentationProviders;
        private readonly Dictionary<string, DocItem> _items;

        private DocItemReader(FileInfo assemblyFile, FileInfo documentationFile, string assemblyPageName, IEnumerable<FileInfo> externLinksFiles)
        {
            _decompiler = new CSharpDecompiler(assemblyFile.FullName, new DecompilerSettings { ThrowOnAssemblyResolveErrors = false });
            _resolver = new CSharpResolver(_decompiler.TypeSystem);
            _documentationProviders = new Dictionary<IModule, IDocumentationProvider>
            {
                [_resolver.Compilation.MainModule] = new XmlDocumentationProvider(documentationFile.FullName)
            };

            _items = new Dictionary<string, DocItem>();

            AssemblyDocItem assemblyDocItem = new(
                assemblyPageName,
                _decompiler.TypeSystem.MainModule.AssemblyName,
                GetDocumentation($"T:{_decompiler.TypeSystem.MainModule.AssemblyName}.AssemblyDoc"));
            Add(assemblyDocItem);

            foreach (ITypeDefinition type in _decompiler.TypeSystem.MainModule.TypeDefinitions.Where(t => t.Name != "NamespaceDoc" && t.Name != "AssemblyDoc"))
            {
                bool showType = TryGetDocumentation(type, out XElement documentation);

                if (documentation?.HasExclude() is true)
                {
                    continue;
                }

                bool newNamespace = false;

                string namespaceId = $"N:{type.Namespace}";
                if (!_items.TryGetValue(type.DeclaringType?.GetDefinition().GetIdString() ?? namespaceId, out DocItem parentDocItem))
                {
                    newNamespace = true;

                    parentDocItem = new NamespaceDocItem(
                        assemblyDocItem,
                        type.Namespace,
                        GetDocumentation($"T:{type.Namespace}.NamespaceDoc"));

                    if (parentDocItem.Documentation?.HasExclude() is true)
                    {
                        continue;
                    }
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
                    if (TryGetDocumentation(entity, out documentation) && !documentation.HasExclude())
                    {
                        showType = true;

                        Add(entity switch
                        {
                            IField field when typeDocItem is EnumDocItem enumDocItem => new EnumFieldDocItem(enumDocItem, field, documentation),
                            IField field => new FieldDocItem(typeDocItem, field, documentation),
                            IProperty property => new PropertyDocItem(typeDocItem, property, documentation),
                            IMethod method when method.IsConstructor => new ConstructorDocItem(typeDocItem, method, documentation),
                            IMethod method when method.IsOperator => new OperatorDocItem(typeDocItem, method, documentation),
                            IMethod method => new MethodDocItem(typeDocItem, method, documentation),
                            IEvent @event => new EventDocItem(typeDocItem, @event, documentation),
                            _ => throw new NotSupportedException()
                        });
                    }
                }

                if (showType)
                {
                    if (newNamespace)
                    {
                        Add(parentDocItem);
                    }

                    Add(typeDocItem);
                }
            }

            foreach (FileInfo linksFile in externLinksFiles)
            {
                using StreamReader reader = linksFile.OpenText();

                string baseLink = string.Empty;
                while (!reader.EndOfStream)
                {
                    string[] items = reader.ReadLine().Split(new[] { '|' }, 3);

                    switch (items.Length)
                    {
                        case 1:
                            baseLink = items[0].Trim();
                            break;

                        case 2:
                            Add(new ExternDocItem(items[0].Trim(), baseLink + items[1].Trim(), null));
                            break;

                        case 3:
                            Add(new ExternDocItem(items[0].Trim(), baseLink + items[1].Trim(), items[2].Trim()));
                            break;
                    }
                }
            }
        }

        private bool TryGetDocumentation(IEntity entity, out XElement documentation)
        {
            static XElement ConvertToDocumentation(string documentationString) => documentationString is null ? null : XElement.Parse($"<doc>{documentationString}</doc>");

            if (entity is null)
            {
                documentation = null;
                return false;
            }

            if (!_documentationProviders.TryGetValue(entity.ParentModule, out IDocumentationProvider documentationProvider))
            {
                documentationProvider = XmlDocLoader.LoadDocumentation(entity.ParentModule.PEFile);
                _documentationProviders.Add(entity.ParentModule, documentationProvider);
            }

            documentation = ConvertToDocumentation(documentationProvider?.GetDocumentation(entity));

            if (documentation.HasInheritDoc(out XElement inheritDoc))
            {
                string referenceName = inheritDoc.GetCRefAttribute();

                if (referenceName is null)
                {
                    XElement baseDocumentation = null;
                    if (entity is ITypeDefinition type)
                    {
                        type.GetBaseTypeDefinitions().FirstOrDefault(t => TryGetDocumentation(t, out baseDocumentation));
                    }
                    else
                    {
                        string id = entity.GetIdString().Substring(entity.DeclaringTypeDefinition.GetIdString().Length);
                        entity
                            .DeclaringTypeDefinition
                            .GetBaseTypeDefinitions()
                            .SelectMany(t => t.Members)
                            .FirstOrDefault(e => e.GetIdString().Substring(e.DeclaringTypeDefinition.GetIdString().Length) == id && TryGetDocumentation(e, out baseDocumentation));
                    }

                    documentation = baseDocumentation;
                }
                else
                {
                    return TryGetDocumentation(IdStringProvider.FindEntity(referenceName, _resolver), out documentation);
                }
            }

            return documentation != null;
        }

        private XElement GetDocumentation(string id) => TryGetDocumentation(IdStringProvider.FindEntity(id, _resolver), out XElement documentation) ? documentation : null;

        private void Add(DocItem item) => _items.Add(item.Id, item);

        public static Dictionary<string, DocItem> GetItems(FileInfo assemblyFile, FileInfo documentationFile, string assemblyPageName, IEnumerable<FileInfo> externLinksFiles)
            => new DocItemReader(assemblyFile, documentationFile, assemblyPageName ?? "index", externLinksFiles)._items;
    }
}
