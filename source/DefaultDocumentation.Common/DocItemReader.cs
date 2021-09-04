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
using NLog;

namespace DefaultDocumentation
{
    internal sealed class DocItemReader
    {
        private readonly ILogger _logger;
        private readonly CSharpDecompiler _decompiler;
        private readonly CSharpResolver _resolver;
        private readonly Dictionary<IModule, IDocumentationProvider> _documentationProviders;
        private readonly Dictionary<string, DocItem> _items;

        private DocItemReader(Settings settings)
        {
            bool IsGenerated(IEntity entity) => entity.EffectiveAccessibility() switch
            {
                Accessibility.Public => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.Public) != 0,
                Accessibility.Private => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.Private) != 0,
                Accessibility.Protected => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.Protected) != 0,
                Accessibility.Internal => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.Internal) != 0,
                Accessibility.ProtectedOrInternal => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.ProtectedInternal) != 0,
                Accessibility.ProtectedAndInternal => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.PrivateProtected) != 0,
                _ => false
            };

            _logger = settings.Logger;
            _decompiler = new CSharpDecompiler(settings.AssemblyFile.FullName, new DecompilerSettings { ThrowOnAssemblyResolveErrors = false });
            _resolver = new CSharpResolver(_decompiler.TypeSystem);
            _documentationProviders = new Dictionary<IModule, IDocumentationProvider>
            {
                [_resolver.Compilation.MainModule] = new XmlDocumentationProvider(settings.DocumentationFile.FullName)
            };

            _items = new Dictionary<string, DocItem>();

            AssemblyDocItem assemblyDocItem = new(
                settings.AssemblyPageName ?? "index",
                _decompiler.TypeSystem.MainModule.AssemblyName,
                GetDocumentation($"T:{_decompiler.TypeSystem.MainModule.AssemblyName}.AssemblyDoc"));
            Add(assemblyDocItem);

            foreach (ITypeDefinition type in _decompiler.TypeSystem.MainModule.TypeDefinitions.Where(t => t.Name != "NamespaceDoc" && t.Name != "AssemblyDoc"))
            {
                if (!IsGenerated(type))
                {
                    _logger.Debug($"Skipping documentation for type \"{type.FullName}\": accessibility \"{type.EffectiveAccessibility()}\" not generated");
                    continue;
                }

                _logger.Debug($"handling type \"{type.FullName}\"");

                List<ITypeDefinition> declaringTypes = new(type.GetDeclaringTypeDefinitions().Skip(1).Reverse());
                List<DocItem> docItemsToAdd = new();

                if (!_items.TryGetValue($"N:{(declaringTypes.FirstOrDefault() ?? type).Namespace}", out DocItem parentDocItem))
                {
                    parentDocItem = new NamespaceDocItem(
                        assemblyDocItem,
                        (declaringTypes.FirstOrDefault() ?? type).Namespace,
                        GetDocumentation($"T:{type.Namespace}.NamespaceDoc"));

                    if (parentDocItem.Documentation?.HasExclude() is true)
                    {
                        _logger.Debug($"Skipping documentation for type \"{type.FullName}\": exclude tag found in namespace \"{parentDocItem.FullName}\" documentation");
                        continue;
                    }

                    docItemsToAdd.Add(parentDocItem);
                }

                foreach (ITypeDefinition currentType in declaringTypes)
                {
                    if (!_items.TryGetValue(currentType.GetIdString(), out DocItem declaringTypeDocItem))
                    {
                        declaringTypeDocItem = GetDocItem(currentType, parentDocItem);

                        if (declaringTypeDocItem.Documentation?.HasExclude() is true)
                        {
                            _logger.Debug($"Skipping documentation for type \"{type.FullName}\": exclude tag found in declaring type \"{declaringTypeDocItem.FullName}\" documentation");
                            parentDocItem = null;
                            break;
                        }

                        docItemsToAdd.Add(declaringTypeDocItem);
                    }

                    parentDocItem = declaringTypeDocItem;
                }

                if (parentDocItem is null)
                {
                    continue;
                }

                TypeDocItem typeDocItem = GetDocItem(type, parentDocItem);

                if (typeDocItem.Documentation?.HasExclude() is true)
                {
                    _logger.Debug($"Skipping documentation for type \"{type.FullName}\": exclude tag found in documentation");
                    continue;
                }

                bool showType = typeDocItem.Documentation != null;

                foreach (IEntity entity in Enumerable.Empty<IEntity>().Concat(type.Fields).Concat(type.Properties).Concat(type.Methods).Concat(type.Events))
                {
                    _logger.Debug($"handling member \"{entity.FullName}\"");

                    if (!IsGenerated(entity))
                    {
                        _logger.Debug($"Skipping documentation for member \"{entity.FullName}\": accessibility \"{entity.EffectiveAccessibility()}\" not generated");
                        continue;
                    }

                    if (!TryGetDocumentation(entity, out XElement documentation))
                    {
                        _logger.Debug($"Skipping documentation for member \"{entity.FullName}\": no documentation");
                        continue;
                    }

                    if (documentation.HasExclude())
                    {
                        _logger.Debug($"Skipping documentation for member \"{entity.FullName}\": exclude tag found in documentation");
                        continue;
                    }

                    showType = true;

                    Add(entity switch
                    {
                        IField field when typeDocItem is EnumDocItem enumDocItem => new EnumFieldDocItem(enumDocItem, field, documentation),
                        IField field => new FieldDocItem(typeDocItem, field, documentation),
                        IProperty property when property.IsExplicitInterfaceImplementation => new ExplicitInterfaceImplementationDocItem(typeDocItem, property, documentation),
                        IProperty property => new PropertyDocItem(typeDocItem, property, documentation),
                        IMethod method when method.IsExplicitInterfaceImplementation => new ExplicitInterfaceImplementationDocItem(typeDocItem, method, documentation),
                        IMethod method when method.IsConstructor => new ConstructorDocItem(typeDocItem, method, documentation),
                        IMethod method when method.IsOperator => new OperatorDocItem(typeDocItem, method, documentation),
                        IMethod method => new MethodDocItem(typeDocItem, method, documentation),
                        IEvent @event => new EventDocItem(typeDocItem, @event, documentation),
                        _ => throw new NotSupportedException()
                    });
                }

                if (showType)
                {
                    foreach (DocItem docItem in docItemsToAdd)
                    {
                        Add(docItem);
                    }

                    Add(typeDocItem);
                }
                else
                {
                    _logger.Debug($"Skipping documentation for type \"{type.FullName}\": no documentation and no documented members");
                }
            }

            foreach (FileInfo linksFile in settings.ExternLinksFiles)
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

        private TypeDocItem GetDocItem(ITypeDefinition type, DocItem parentDocItem)
        {
            TryGetDocumentation(type, out XElement documentation);

            return type.Kind switch
            {
                TypeKind.Class => new ClassDocItem(parentDocItem, type, documentation),
                TypeKind.Struct => new StructDocItem(parentDocItem, type, documentation),
                TypeKind.Interface => new InterfaceDocItem(parentDocItem, type, documentation),
                TypeKind.Enum => new EnumDocItem(parentDocItem, type, documentation),
                TypeKind.Delegate => new DelegateDocItem(parentDocItem, type, documentation),
                _ => throw new NotSupportedException($"type definition kind \"{type.Kind}\" not supported")
            };
        }

        private bool TryGetDocumentation(IEntity entity, out XElement documentation)
        {
            static XElement ConvertToDocumentation(string documentationString) => documentationString is null ? null : XElement.Parse($"<doc>{documentationString}</doc>");

            _logger.Trace($"looking for documentation of \"{entity?.FullName}\"");
            if (entity is null)
            {
                documentation = null;
                return false;
            }

            if (!_documentationProviders.TryGetValue(entity.ParentModule, out IDocumentationProvider documentationProvider))
            {
                _logger.Trace($"adding documentation provider for \"{entity.ParentModule.FullAssemblyName}\"");
                documentationProvider = XmlDocLoader.LoadDocumentation(entity.ParentModule.PEFile) ?? XmlDocLoader.MscorlibDocumentation;
                _documentationProviders.Add(entity.ParentModule, documentationProvider);
            }

            documentation = ConvertToDocumentation(documentationProvider?.GetDocumentation(entity));

            if (documentation.HasInheritDoc(out XElement inheritDoc))
            {
                string referenceName = inheritDoc.GetCRefAttribute();

                if (referenceName is null)
                {
                    _logger.Trace($"looking for inherited documentation of \"{entity.FullName}\"");
                    XElement baseDocumentation = null;
                    if (entity is ITypeDefinition type)
                    {
                        _ = type.GetBaseTypeDefinitions().FirstOrDefault(t => TryGetDocumentation(t, out baseDocumentation));
                    }
                    else if (entity is IMember member && member.IsExplicitInterfaceImplementation)
                    {
                        return TryGetDocumentation(member.ExplicitlyImplementedInterfaceMembers.FirstOrDefault(), out documentation);
                    }
                    else
                    {
                        string id = entity.GetIdString().Substring(entity.DeclaringTypeDefinition.GetIdString().Length);
                        _ = entity
                            .DeclaringTypeDefinition
                            .GetBaseTypeDefinitions()
                            .SelectMany(t => t.Members)
                            .FirstOrDefault(e => e.GetIdString().Substring(e.DeclaringTypeDefinition.GetIdString().Length) == id && TryGetDocumentation(e, out baseDocumentation));
                    }

                    documentation = baseDocumentation;
                }
                else
                {
                    _logger.Trace($"looking for inherited documentation of \"{entity.FullName}\" cref \"{referenceName}\"");
                    return TryGetDocumentation(IdStringProvider.FindEntity(referenceName, _resolver), out documentation);
                }
            }

            return documentation != null;
        }

        private XElement GetDocumentation(string id)
        {
            _logger.Trace($"looking for documentation of \"{id}\"");
            return TryGetDocumentation(IdStringProvider.FindEntity(id, _resolver), out XElement documentation) ? documentation : null;
        }

        private void Add(DocItem item)
        {
            if (!_items.ContainsKey(item.Id))
            {
                _logger.Debug($"adding DocItem \"{item}\" with id \"{item.Id}\"");
                _items.Add(item.Id, item);
            }
            else
            {
                _logger.Warn($"duplicate DocItem \"{item}\" with id \"{item.Id}\" ignored");
            }
        }

        public static Dictionary<string, DocItem> GetItems(Settings settings) => new DocItemReader(settings)._items;
    }
}
