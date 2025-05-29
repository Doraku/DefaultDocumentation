using System;
using System.Xml.Linq;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models;

/// <summary>
/// Represent an <see cref="IEntity"/> documentation.
/// </summary>
public abstract class EntityDocItem : DocItem
{
    private static readonly CSharpAmbience _fullNameAmbience = new()
    {
        ConversionFlags =
            ConversionFlags.ShowParameterList
            | ConversionFlags.ShowTypeParameterList
            | ConversionFlags.UseFullyQualifiedTypeNames
            | ConversionFlags.ShowDeclaringType
            | ConversionFlags.UseFullyQualifiedEntityNames
    };

    private static readonly CSharpAmbience _nameAmbience = new()
    {
        ConversionFlags =
            ConversionFlags.ShowParameterList
            | ConversionFlags.ShowTypeParameterList
    };

    private static readonly CSharpAmbience _explicitNameAmbience = new()
    {
        ConversionFlags =
            ConversionFlags.ShowParameterList
            | ConversionFlags.ShowTypeParameterList
            | ConversionFlags.UseFullyQualifiedEntityNames
    };

    /// <summary>
    /// Gets the <see cref="IEntity"/> of the current instance.
    /// </summary>
    public IEntity Entity { get; }

    private protected EntityDocItem(DocItem parent, IEntity entity, XElement? documentation)
        : base(
            parent, entity.GetIdString(),
            GetFullName(entity).Replace("?", string.Empty),
            entity.ToString((entity as IMember)?.IsExplicitInterfaceImplementation ?? false ? _explicitNameAmbience : _nameAmbience).Replace("?", string.Empty),
            documentation)
    {
        Entity = entity;
    }

    private static string GetFullName(IEntity entity)
    {
        string fullName = entity.ToString(_fullNameAmbience);

        if (entity.SymbolKind == SymbolKind.Operator)
        {
            int offset = 17;
            int index = fullName.IndexOf("implicit operator ", StringComparison.Ordinal);
            if (index < 0)
            {
                index = fullName.IndexOf("explicit operator ", StringComparison.Ordinal);

                if (index < 0)
                {
                    index = fullName.IndexOf("operator ", StringComparison.Ordinal);
                    offset = fullName.IndexOf('(') - index;
                }
            }

            if (index >= 0)
            {
                fullName = fullName[..index] + entity.Name + fullName[(index + offset)..];
            }
        }

        return fullName;
    }
}
