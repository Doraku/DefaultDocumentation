using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Resolver;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;
using NLog;

namespace DefaultDocumentation.Internal;

internal sealed class DocItemReader
{
    private readonly ILogger _logger;
    private readonly CSharpDecompiler _decompiler;
    private readonly CSharpResolver _resolver;
    private readonly Dictionary<IModule, IDocumentationProvider> _documentationProviders;
    private readonly Dictionary<string, DocItem> _items;

    private DocItemReader(Settings settings)
    {
        _logger = settings.Logger;
        _decompiler = new CSharpDecompiler(settings.AssemblyFile.FullName, new DecompilerSettings { ThrowOnAssemblyResolveErrors = false });
        _resolver = new CSharpResolver(_decompiler.TypeSystem);
        _documentationProviders = new Dictionary<IModule, IDocumentationProvider>
        {
            [_resolver.Compilation.MainModule] = new XmlDocumentationProvider(settings.DocumentationFile.FullName)
        };

        _items = [];

        AssemblyDocItem assemblyDocItem = new(
            settings.AssemblyPageName ?? "index",
            _decompiler.TypeSystem.MainModule.AssemblyName,
            GetDocumentation($"T:{_decompiler.TypeSystem.MainModule.AssemblyName}.AssemblyDoc"));
        Add(assemblyDocItem);

        foreach (ITypeDefinition type in _decompiler.TypeSystem.MainModule.TypeDefinitions.Where(type => type.Name is not "NamespaceDoc" and not "AssemblyDoc"))
        {
            _logger.Debug($"handling type \"{type.FullName}\"");

            if (type.IsCompilerGenerated())
            {
                _logger.Debug($"Skipping documentation for type \"{type.FullName}\": compiler generated");
                continue;
            }

            if (string.IsNullOrWhiteSpace(type.Namespace))
            {
                _logger.Debug($"Skipping documentation for type \"{type.FullName}\": empty namespace");
                continue;
            }

            if (!type.IsVisibleInDocumentation(settings))
            {
                _logger.Debug($"Skipping documentation for type \"{type.FullName}\": accessibility \"{type.EffectiveAccessibility()}\" not generated");
                continue;
            }

            List<ITypeDefinition> declaringTypes = new(type.GetDeclaringTypeDefinitions().Skip(1).Reverse());
            List<DocItem> docItemsToAdd = [];

            if (!_items.TryGetValue($"N:{(declaringTypes.FirstOrDefault() ?? type).Namespace}", out DocItem? parentDocItem))
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

                    if (currentType.IsCompilerGenerated())
                    {
                        _logger.Debug($"Skipping documentation for type \"{type.FullName}\": declaring type \"{declaringTypeDocItem.FullName}\" is compiler generated");
                        parentDocItem = null;
                        break;
                    }

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
            docItemsToAdd.Add(typeDocItem);

            if (typeDocItem.Documentation.HasExclude())
            {
                _logger.Debug($"Skipping documentation for type \"{type.FullName}\": exclude tag found in documentation");
                continue;
            }

            bool showType = typeDocItem.Documentation != null || settings.IncludeUndocumentedItems;

            if (typeDocItem is not DelegateDocItem)
            {
                foreach (IEntity entity in Enumerable.Empty<IEntity>().Concat(type.Fields).Concat(type.Properties).Concat(type.Methods).Concat(type.Events))
                {
                    _logger.Debug($"handling member \"{entity.FullName}\"");

                    if (entity.IsCompilerGenerated()
                        || (entity is IField && typeDocItem is EnumDocItem && entity.Name == "value__"))
                    {
                        _logger.Debug($"Skipping documentation for member \"{entity.FullName}\": compiler generated");
                        continue;
                    }

                    if (!entity.IsVisibleInDocumentation(settings))
                    {
                        _logger.Debug($"Skipping documentation for member \"{entity.FullName}\": accessibility \"{entity.EffectiveAccessibility()}\" not generated");
                        continue;
                    }

                    if (!TryGetDocumentation(entity, out XElement? documentation) && !settings.IncludeUndocumentedItems)
                    {
                        _logger.Debug($"Skipping documentation for member \"{entity.FullName}\": no documentation");
                        continue;
                    }

                    if (documentation.HasExclude())
                    {
                        _logger.Debug($"Skipping documentation for member \"{entity.FullName}\": exclude tag found in documentation");
                        continue;
                    }

                    if (entity.IsDefaultConstructor() && documentation is null)
                    {
                        _logger.Debug($"Skipping documentation for member \"{entity.FullName}\": default constructor");
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
                        IEvent @event when @event.IsExplicitInterfaceImplementation => new ExplicitInterfaceImplementationDocItem(typeDocItem, @event, documentation),
                        IEvent @event => new EventDocItem(typeDocItem, @event, documentation),
                        _ => throw new NotSupportedException()
                    });
                }
            }

            if (showType)
            {
                foreach (DocItem docItem in docItemsToAdd)
                {
                    Add(docItem);
                }
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
                string[] items = reader.ReadLine().Split(['|'], 3);

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
        TryGetDocumentation(type, out XElement? documentation);

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

    private bool TryGetDocumentation(IEntity? entity, [NotNullWhen(true)] out XElement? documentation, HashSet<string>? referencedIds = null)
    {
        static XElement? ConvertToDocumentation(string? documentationString) => documentationString is null ? null : XElement.Parse($"<doc>{documentationString}</doc>");

        referencedIds ??= [];

        _logger.Trace($"looking for documentation of \"{entity?.FullName}\"");
        if (entity?.ParentModule?.PEFile is null)
        {
            documentation = null;
            return false;
        }

        if (!_documentationProviders.TryGetValue(entity.ParentModule, out IDocumentationProvider documentationProvider))
        {
            _logger.Trace($"loading documentation provider for \"{entity.ParentModule.PEFile.FileName}\"");
            documentationProvider = XmlDocLoader.LoadDocumentation(entity.ParentModule.PEFile) ?? XmlDocLoader.MscorlibDocumentation;
            _documentationProviders.Add(entity.ParentModule, documentationProvider);
        }

        documentation = ConvertToDocumentation(documentationProvider?.GetDocumentation(entity));

        if (documentation.HasInheritDoc(out XElement? inheritDoc))
        {
            string? referenceName = inheritDoc.GetCRefAttribute();

            if (referenceName is null)
            {
                _logger.Trace($"looking for inherited documentation of \"{entity.FullName}\"");
                XElement? baseDocumentation = null;
                if (entity is ITypeDefinition type)
                {
                    _ = type
                        .GetAllBaseTypeDefinitions()
                        .Reverse()
                        .Skip(1)
                        .FirstOrDefault(baseType => TryGetDocumentation(baseType, out baseDocumentation, referencedIds));
                }
                else if (entity is IMember member && member.IsExplicitInterfaceImplementation)
                {
                    return TryGetDocumentation(member.ExplicitlyImplementedInterfaceMembers.FirstOrDefault(), out documentation, referencedIds);
                }
                else
                {
                    string id = entity.GetIdString()[entity.DeclaringTypeDefinition.GetIdString().Length..];
                    _ = entity
                        .DeclaringTypeDefinition
                        .GetAllBaseTypeDefinitions()
                        .Reverse()
                        .Skip(1)
                        .SelectMany(baseType => baseType.Members)
                        .FirstOrDefault(member => member.GetIdString()[member.DeclaringTypeDefinition.GetIdString().Length..] == id && TryGetDocumentation(member, out baseDocumentation, referencedIds));
                }

                documentation = baseDocumentation;
            }
            else if (referencedIds.Add(referenceName))
            {
                _logger.Trace($"looking for inherited documentation of \"{entity.FullName}\" cref \"{referenceName}\"");

                return TryGetDocumentation(IdStringProvider.FindEntity(referenceName, _resolver), out documentation, referencedIds);
            }
            else
            {
                _logger.Trace($"cyclic inherited documentation detected for cref \"{referenceName}\", handled as no documentation available");

                documentation = null;
                return false;
            }
        }

        return documentation != null;
    }

    private XElement? GetDocumentation(string id)
    {
        _logger.Trace($"looking for documentation of \"{id}\"");
        return TryGetDocumentation(IdStringProvider.FindEntity(id, _resolver), out XElement? documentation) ? documentation : null;
    }

    private void Add(DocItem item)
    {
        if (!_items.ContainsKey(item.Id))
        {
            _logger.Debug($"adding DocItem \"{item}\" with id \"{item.Id}\"");
            _items.Add(item.Id, item);

            if (item is ITypeParameterizedDocItem typeParameterized)
            {
                foreach (TypeParameterDocItem typeParameter in typeParameterized.TypeParameters)
                {
                    Add(typeParameter);
                }
            }

            if (item is IParameterizedDocItem parameterized)
            {
                foreach (ParameterDocItem parameter in parameterized.Parameters)
                {
                    Add(parameter);
                }
            }
        }
        else
        {
            _logger.Warn($"duplicate DocItem \"{item}\" with id \"{item.Id}\" ignored");
        }
    }

    public static IReadOnlyDictionary<string, DocItem> GetItems(Settings settings) => new DocItemReader(settings)._items;
}
