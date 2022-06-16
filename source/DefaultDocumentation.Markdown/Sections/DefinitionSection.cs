using System;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    /// <summary>
    /// <see cref="ISection"/> implementation to write the definition of <see cref="DocItem"/>.
    /// </summary>
    public sealed class DefinitionSection : ISection
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "Definition";

        private static readonly CSharpAmbience _typeAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
        };

        private static readonly CSharpAmbience _baseTypeAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.UseFullyQualifiedTypeNames
                | ConversionFlags.UseFullyQualifiedEntityNames
        };

        private static readonly CSharpAmbience _delegateAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowParameterList
                | ConversionFlags.ShowParameterModifiers
                | ConversionFlags.ShowParameterNames
                | ConversionFlags.ShowReturnType
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        private static readonly CSharpAmbience _methodAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowParameterDefaultValues
                | ConversionFlags.ShowParameterList
                | ConversionFlags.ShowParameterModifiers
                | ConversionFlags.ShowParameterNames
                | ConversionFlags.ShowReturnType
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        private static readonly CSharpAmbience _fieldAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowReturnType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
        };

        private static readonly CSharpAmbience _propertyAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowBody
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowParameterDefaultValues
                | ConversionFlags.ShowParameterList
                | ConversionFlags.ShowParameterModifiers
                | ConversionFlags.ShowParameterNames
                | ConversionFlags.ShowReturnType
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        private static readonly CSharpAmbience _eventAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowBody
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowReturnType
        };

        /// <inheritdoc/>
        public string Name => ConfigName;

        private static void WriteConstraints(IWriter writer, ITypeParameterizedDocItem item)
        {
            static void WriteWhere(IWriter writer, ITypeParameter typeParameter, ref bool whereWritten, string constraint)
            {
                if (!whereWritten)
                {
                    whereWritten = true;
                    writer
                        .AppendLine()
                        .Append("    where ")
                        .Append(typeParameter.Name)
                        .Append(" :");
                }

                writer
                    .Append(" ")
                    .Append(constraint)
                    .Append(",");
            }

            static void WriteConstraints(IWriter writer, ITypeParameter typeParameter)
            {
                bool whereWritten = false;
                if (typeParameter.HasReferenceTypeConstraint)
                {
                    WriteWhere(writer, typeParameter, ref whereWritten, typeParameter.NullabilityConstraint == Nullability.Nullable ? "class?" : "class");
                }
                else if (typeParameter.HasValueTypeConstraint)
                {
                    WriteWhere(writer, typeParameter, ref whereWritten, typeParameter.HasUnmanagedConstraint ? "unmanaged" : "struct");
                }
                else if (typeParameter.NullabilityConstraint == Nullability.NotNullable)
                {
                    WriteWhere(writer, typeParameter, ref whereWritten, "notnull");
                }
                foreach (TypeConstraint typeConstraint in typeParameter.TypeConstraints.Where(c => c.Type.GetDefinition()?.KnownTypeCode is not KnownTypeCode.Object or KnownTypeCode.ValueType))
                {
                    WriteWhere(writer, typeParameter, ref whereWritten, _baseTypeAmbience.ConvertType(typeConstraint.Type));
                }
                if (typeParameter.HasDefaultConstructorConstraint && !typeParameter.HasValueTypeConstraint)
                {
                    WriteWhere(writer, typeParameter, ref whereWritten, "new()");
                }

                if (whereWritten)
                {
                    --writer.Length;
                }
            }

            foreach (TypeParameterDocItem typeParameter in item.TypeParameters)
            {
                WriteConstraints(writer, typeParameter.TypeParameter);
            }
        }

        /// <inheritdoc/>
        public void Write(IWriter writer)
        {
            static IWriter Write(IWriter writer, Action<IWriter> writeAction)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .AppendLine("```csharp");

                writeAction(writer);

                return writer
                    .TrimEnd(Environment.NewLine, " ")
                    .AppendLine()
                    .Append("```");
            }

            _ = writer.GetCurrentItem() switch
            {
                FieldDocItem item => Write(writer, w =>
                {
                    w.Append(_fieldAmbience.ConvertSymbol(item.Field));

                    if (item.Field.IsConst)
                    {
                        string typeDelimiter =
                            item.Field.Type.IsKnownType(KnownTypeCode.String)
                            ? "\""
                            : item.Field.Type.IsKnownType(KnownTypeCode.Char)
                            ? "'"
                            : string.Empty;

                        w
                            .Append(" = ")
                            .Append(typeDelimiter)
                            .Append($"{item.Field.GetConstantValue()}")
                            .Append(typeDelimiter);
                    }

                    w.Append(";");
                }),
                PropertyDocItem item => Write(writer, w => w.Append(_propertyAmbience.ConvertSymbol(item.Property))),
                EventDocItem item => Write(writer, w => w.Append(_eventAmbience.ConvertSymbol(item.Event))),
                ConstructorDocItem item => Write(writer, w => w.Append(_methodAmbience.ConvertSymbol(item.Method)).Append(";")),
                OperatorDocItem item => Write(writer, w => w.Append(_methodAmbience.ConvertSymbol(item.Method)).Append(";")),
                ExplicitInterfaceImplementationDocItem item when item.Member is IEvent => Write(writer, w => w.Append(_eventAmbience.ConvertSymbol(item.Member))),
                ExplicitInterfaceImplementationDocItem item when item.Member is IProperty => Write(writer, w => w.Append(_propertyAmbience.ConvertSymbol(item.Member))),
                ExplicitInterfaceImplementationDocItem item when item.Member is IMethod => Write(writer, w =>
                {
                    w.Append(_methodAmbience.ConvertSymbol(item.Member));
                    WriteConstraints(w, item);
                    w.Append(";");
                }),
                MethodDocItem item => Write(writer, w =>
                {
                    w.Append(_methodAmbience.ConvertSymbol(item.Method));
                    WriteConstraints(w, item);
                    w.Append(";");
                }),
                EnumDocItem item => Write(writer, w =>
                {
                    IType enumType = item.Type.GetEnumUnderlyingType();

                    w
                        .Append(_typeAmbience.ConvertSymbol(item.Type))
                        .Append(enumType.IsKnownType(KnownTypeCode.Int32) ? string.Empty : " : " + enumType.FullName);
                }),
                DelegateDocItem item => Write(writer, w =>
                {
                    w.Append(_delegateAmbience.ConvertSymbol(item.Type));
                    WriteConstraints(writer, item);
                    w.Append(";");
                }),
                TypeDocItem item => Write(writer, w =>
                {
                    w.Append(_typeAmbience.ConvertSymbol(item.Type));

                    IType baseType = item.Type.DirectBaseTypes.FirstOrDefault(t => t.Kind == TypeKind.Class && !t.IsKnownType(KnownTypeCode.Object) && !t.IsKnownType(KnownTypeCode.ValueType));
                    if (baseType != null)
                    {
                        w
                            .Append(" : ")
                            .Append(_baseTypeAmbience.ConvertType(baseType));
                    }

                    foreach (IType @interface in item.Type.DirectBaseTypes.Where(t => t.Kind == TypeKind.Interface && t.GetDefinition()?.Accessibility == Accessibility.Public))
                    {
                        w
                            .AppendLine(baseType is null ? " :" : ",")
                            .Append(_baseTypeAmbience.ConvertType(@interface));

                        baseType = @interface;
                    }

                    WriteConstraints(writer, item);
                }),
                _ => writer
            };
        }
    }
}
