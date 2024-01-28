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
                | ConversionFlags.SupportRecordClasses
                | ConversionFlags.SupportRecordStructs
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
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowParameterDefaultValues
                | ConversionFlags.ShowParameterList
                | ConversionFlags.ShowParameterModifiers
                | ConversionFlags.ShowParameterNames
                | ConversionFlags.ShowReturnType
                | ConversionFlags.UseFullyQualifiedTypeNames
                | ConversionFlags.SupportInitAccessors
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


            static void WritePropertyMethod(IWriter writer, IMethod? method, string name)
            {
                if (!method.IsVisibleInDocumentation(writer.Context.Settings))
                {
                    return;
                }

                writer
                    .Append((method!.IsExplicitInterfaceImplementation ? method.ExplicitlyImplementedInterfaceMembers.FirstOrDefault() : method).Accessibility switch
                    {
                        Accessibility.Private => " private ",
                        Accessibility.Internal => " internal ",
                        Accessibility.Protected => " protected ",
                        Accessibility.ProtectedAndInternal => " private protected ",
                        Accessibility.ProtectedOrInternal => " protected internal ",
                        _ => " "
                    })
                    .Append(name)
                    .Append(";");
            }

            static void WriteProperty(IWriter writer, IProperty property)
            {
                writer
                    .Append(property.ToString(_propertyAmbience))
                    .Append(" {");

                WritePropertyMethod(writer, property.Getter, "get");
                WritePropertyMethod(writer, property.Setter, property.Setter?.IsInitOnly ?? false ? "init" : "set");

                writer.Append(" }");
            }

            _ = writer.GetCurrentItem() switch
            {
                FieldDocItem item => Write(writer, w =>
                {
                    w.Append(item.Field.ToString(_fieldAmbience));

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
                PropertyDocItem item => Write(writer, w => WriteProperty(w, item.Property)),
                EventDocItem item => Write(writer, w => w.Append(item.Event.ToString(_eventAmbience))),
                ConstructorDocItem item => Write(writer, w => w.Append(item.Method.ToString(_methodAmbience)).Append(";")),
                OperatorDocItem item => Write(writer, w => w.Append(item.Method.ToString(_methodAmbience)).Append(";")),
                ExplicitInterfaceImplementationDocItem item when item.Member is IEvent => Write(writer, w => w.Append(item.Member.ToString(_eventAmbience))),
                ExplicitInterfaceImplementationDocItem item when item.Member is IProperty property => Write(writer, w => WriteProperty(w, property)),
                ExplicitInterfaceImplementationDocItem item when item.Member is IMethod => Write(writer, w =>
                {
                    w.Append(item.Member.ToString(_methodAmbience));
                    WriteConstraints(w, item);
                    w.Append(";");
                }),
                MethodDocItem item => Write(writer, w =>
                {
                    w.Append(item.Method.ToString(_methodAmbience));
                    WriteConstraints(w, item);
                    w.Append(";");
                }),
                EnumDocItem item => Write(writer, w =>
                {
                    IType enumType = item.Type.GetEnumUnderlyingType();

                    w
                        .Append(item.Type.ToString(_typeAmbience))
                        .Append(enumType.IsKnownType(KnownTypeCode.Int32) ? string.Empty : " : " + enumType.FullName);
                }),
                DelegateDocItem item => Write(writer, w =>
                {
                    w.Append(item.Type.ToString(_delegateAmbience));
                    WriteConstraints(writer, item);
                    w.Append(";");
                }),
                TypeDocItem item => Write(writer, w =>
                {
                    w.Append(item.Type.ToString(_typeAmbience));

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
                            .Append(baseType is null ? " : " : ", ")
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
