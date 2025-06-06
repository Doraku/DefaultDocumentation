﻿using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections;

/// <summary>
/// <see cref="ISection"/> implementation to write the types/members implemented by the <see cref="DocItem"/>.
/// </summary>
public sealed class ImplementSection : ISection
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Implement";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer)
    {
        writer.ThrowIfNull();

        IEnumerable<INamedElement> GetImplementation(IMember member)
        {
            string id = member.GetIdString()[member.DeclaringTypeDefinition.GetIdString().Length..];

            return member
                .DeclaringTypeDefinition
                .GetAllBaseTypeDefinitions()
                .Reverse()
                .Skip(1)
                .Where(type => type.Kind == TypeKind.Interface && type.GetDefinition()?.Accessibility == Accessibility.Public)
                .SelectMany(type => type.Members)
                .Where(member => member.GetIdString()[member.DeclaringTypeDefinition.GetIdString().Length..] == id);
        }

        List<INamedElement> implementations = [.. writer.GetCurrentItem() switch
        {
            TypeDocItem typeItem => typeItem.Type.DirectBaseTypes.Where(type => type.Kind == TypeKind.Interface && type.GetDefinition()?.Accessibility == Accessibility.Public).OfType<INamedElement>(),
            PropertyDocItem propertyItem => GetImplementation(propertyItem.Property),
            MethodDocItem methodItem => GetImplementation(methodItem.Method),
            EventDocItem eventItem => GetImplementation(eventItem.Event),
            ExplicitInterfaceImplementationDocItem explicitItem => explicitItem.Member.ExplicitlyImplementedInterfaceMembers,
            _ => []
        }];

        if (implementations.Count > 0)
        {
            writer
                .EnsureLineStartAndAppendLine()
                .Append("Implements ");

            bool firstWritten = false;
            foreach (INamedElement implementation in implementations)
            {
                if (!firstWritten)
                {
                    firstWritten = true;
                }
                else
                {
                    writer.Append(", ");
                }

                writer.AppendLink(writer.GetCurrentItem(), implementation);
            }
        }
    }
}
