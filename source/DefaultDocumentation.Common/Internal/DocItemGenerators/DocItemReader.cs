﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Resolver;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Internal.DocItemGenerators;

internal sealed class DocItemReader : IDocItemGenerator
{
    private sealed class Reader
    {
        private readonly IDocItemsContext _context;
        private readonly CSharpDecompiler _decompiler;
        private readonly CSharpResolver _resolver;
        private readonly Dictionary<IModule, IDocumentationProvider> _documentationProviders;

        public Reader(IDocItemsContext context)
        {
            _context = context;
            _decompiler = new CSharpDecompiler(context.Settings.AssemblyFile.FullName, new DecompilerSettings { ThrowOnAssemblyResolveErrors = false });
            _resolver = new CSharpResolver(_decompiler.TypeSystem);
            _documentationProviders = new Dictionary<IModule, IDocumentationProvider>()
            {
                [_resolver.Compilation.MainModule] = new XmlDocumentationProvider(context.Settings.DocumentationFile.FullName)
            };
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

            _context.Settings.Logger.Trace($"looking for documentation of \"{entity?.FullName}\"");
            if (entity?.ParentModule?.PEFile is null)
            {
                documentation = null;
                return false;
            }

            if (!_documentationProviders.TryGetValue(entity.ParentModule, out IDocumentationProvider documentationProvider))
            {
                _context.Settings.Logger.Trace($"loading documentation provider for \"{entity.ParentModule.PEFile.FileName}\"");
                documentationProvider = XmlDocLoader.LoadDocumentation(entity.ParentModule.PEFile) ?? XmlDocLoader.MscorlibDocumentation;
                _documentationProviders.Add(entity.ParentModule, documentationProvider);
            }

            documentation = ConvertToDocumentation(documentationProvider?.GetDocumentation(entity));

            if (documentation.HasInheritDoc(out XElement? inheritDoc))
            {
                string? referenceName = inheritDoc.GetCRefAttribute();

                if (referenceName is null)
                {
                    _context.Settings.Logger.Trace($"looking for inherited documentation of \"{entity.FullName}\"");
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
                    _context.Settings.Logger.Trace($"looking for inherited documentation of \"{entity.FullName}\" cref \"{referenceName}\"");

                    return TryGetDocumentation(IdStringProvider.FindEntity(referenceName, _resolver), out documentation, referencedIds);
                }
                else
                {
                    _context.Settings.Logger.Trace($"cyclic inherited documentation detected for cref \"{referenceName}\", handled as no documentation available");

                    documentation = null;
                    return false;
                }
            }

            return documentation != null;
        }

        private XElement? GetDocumentation(string id)
        {
            _context.Settings.Logger.Trace($"looking for documentation of \"{id}\"");
            return TryGetDocumentation(IdStringProvider.FindEntity(id, _resolver), out XElement? documentation) ? documentation : null;
        }

        public void Execute()
        {
            AssemblyDocItem assemblyDocItem = new(
                _context.Settings.AssemblyPageName ?? "index",
                _decompiler.TypeSystem.MainModule.AssemblyName,
                GetDocumentation($"T:{_decompiler.TypeSystem.MainModule.AssemblyName}.AssemblyDoc"));

            _context.Add(assemblyDocItem);

            foreach (ITypeDefinition type in _decompiler.TypeSystem.MainModule.TypeDefinitions.Where(type => type.Name is not "NamespaceDoc" and not "AssemblyDoc"))
            {
                _context.Settings.Logger.Debug($"handling type \"{type.FullName}\"");

                if (type.IsCompilerGenerated())
                {
                    _context.Settings.Logger.Debug($"Skipping documentation for type \"{type.FullName}\": compiler generated");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(type.Namespace))
                {
                    _context.Settings.Logger.Debug($"Skipping documentation for type \"{type.FullName}\": empty namespace");
                    continue;
                }

                if (!type.IsVisibleInDocumentation(_context.Settings))
                {
                    _context.Settings.Logger.Debug($"Skipping documentation for type \"{type.FullName}\": accessibility \"{type.EffectiveAccessibility()}\" not generated");
                    continue;
                }

                List<ITypeDefinition> declaringTypes = new(type.GetDeclaringTypeDefinitions().Skip(1).Reverse());
                List<DocItem> docItemsToAdd = [];

                if (!_context.Items.TryGetValue($"N:{(declaringTypes.FirstOrDefault() ?? type).Namespace}", out DocItem? parentDocItem))
                {
                    parentDocItem = new NamespaceDocItem(
                        assemblyDocItem,
                        (declaringTypes.FirstOrDefault() ?? type).Namespace,
                        GetDocumentation($"T:{type.Namespace}.NamespaceDoc"));

                    if (parentDocItem.Documentation?.HasExclude() is true)
                    {
                        _context.Settings.Logger.Debug($"Skipping documentation for type \"{type.FullName}\": exclude tag found in namespace \"{parentDocItem.FullName}\" documentation");
                        continue;
                    }

                    docItemsToAdd.Add(parentDocItem);
                }

                foreach (ITypeDefinition currentType in declaringTypes)
                {
                    if (!_context.Items.TryGetValue(currentType.GetIdString(), out DocItem declaringTypeDocItem))
                    {
                        declaringTypeDocItem = GetDocItem(currentType, parentDocItem);

                        if (currentType.IsCompilerGenerated())
                        {
                            _context.Settings.Logger.Debug($"Skipping documentation for type \"{type.FullName}\": declaring type \"{declaringTypeDocItem.FullName}\" is compiler generated");
                            parentDocItem = null;
                            break;
                        }

                        if (declaringTypeDocItem.Documentation?.HasExclude() is true)
                        {
                            _context.Settings.Logger.Debug($"Skipping documentation for type \"{type.FullName}\": exclude tag found in declaring type \"{declaringTypeDocItem.FullName}\" documentation");
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
                    _context.Settings.Logger.Debug($"Skipping documentation for type \"{type.FullName}\": exclude tag found in documentation");
                    continue;
                }

                bool showType = typeDocItem.Documentation != null || _context.Settings.IncludeUndocumentedItems;

                if (typeDocItem is not DelegateDocItem)
                {
                    foreach (IEntity entity in Enumerable.Empty<IEntity>().Concat(type.Fields).Concat(type.Properties).Concat(type.Methods).Concat(type.Events))
                    {
                        _context.Settings.Logger.Debug($"handling member \"{entity.FullName}\"");

                        if (entity.IsCompilerGenerated()
                            || (entity is IField && typeDocItem is EnumDocItem && entity.Name == "value__"))
                        {
                            _context.Settings.Logger.Debug($"Skipping documentation for member \"{entity.FullName}\": compiler generated");
                            continue;
                        }

                        if (!entity.IsVisibleInDocumentation(_context.Settings))
                        {
                            _context.Settings.Logger.Debug($"Skipping documentation for member \"{entity.FullName}\": accessibility \"{entity.EffectiveAccessibility()}\" not generated");
                            continue;
                        }

                        if (!TryGetDocumentation(entity, out XElement? documentation) && !_context.Settings.IncludeUndocumentedItems)
                        {
                            _context.Settings.Logger.Debug($"Skipping documentation for member \"{entity.FullName}\": no documentation");
                            continue;
                        }

                        if (documentation.HasExclude())
                        {
                            _context.Settings.Logger.Debug($"Skipping documentation for member \"{entity.FullName}\": exclude tag found in documentation");
                            continue;
                        }

                        if (entity.IsDefaultConstructor() && documentation is null)
                        {
                            _context.Settings.Logger.Debug($"Skipping documentation for member \"{entity.FullName}\": default constructor");
                            continue;
                        }

                        showType = true;

                        _context.Add(entity switch
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
                        _context.Add(docItem);
                    }
                }
                else
                {
                    _context.Settings.Logger.Debug($"Skipping documentation for type \"{type.FullName}\": no documentation and no documented members");
                }
            }
        }
    }

    public string Name => nameof(DocItemReader);

    public void Generate(IDocItemsContext context)
    {
        new Reader(context).Execute();
    }
}