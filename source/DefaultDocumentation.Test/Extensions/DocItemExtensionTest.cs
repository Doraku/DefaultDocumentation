using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultDocumentation.Models
{
    public sealed class DocItemExtensionTest
    {
        public static IEnumerable<object[]> HasOwnPageData
        {
            get
            {
                yield return new object[] { GeneratedPages.Default, AssemblyInfo.AssemblyDocItem, false };
                yield return new object[] { GeneratedPages.Assembly, AssemblyInfo.AssemblyDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.NamespaceDocItem, false };
                yield return new object[] { GeneratedPages.Namespaces, AssemblyInfo.NamespaceDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.ClassDocItem, false };
                yield return new object[] { GeneratedPages.Classes, AssemblyInfo.ClassDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.DelegateDocItem, false };
                yield return new object[] { GeneratedPages.Delegates, AssemblyInfo.DelegateDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.EnumDocItem, false };
                yield return new object[] { GeneratedPages.Enums, AssemblyInfo.EnumDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.StructDocItem, false };
                yield return new object[] { GeneratedPages.Structs, AssemblyInfo.StructDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.InterfaceDocItem, false };
                yield return new object[] { GeneratedPages.Interfaces, AssemblyInfo.InterfaceDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.ConstructorDocItem, false };
                yield return new object[] { GeneratedPages.Constructors, AssemblyInfo.ConstructorDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.EventDocItem, false };
                yield return new object[] { GeneratedPages.Events, AssemblyInfo.EventDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.FieldDocItem, false };
                yield return new object[] { GeneratedPages.Fields, AssemblyInfo.FieldDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.MethodWithReturnDocItem, false };
                yield return new object[] { GeneratedPages.Methods, AssemblyInfo.MethodWithReturnDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.OperatorDocItem, false };
                yield return new object[] { GeneratedPages.Operators, AssemblyInfo.OperatorDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.PropertyDocItem, false };
                yield return new object[] { GeneratedPages.Properties, AssemblyInfo.PropertyDocItem, true };

                yield return new object[] { GeneratedPages.Default, AssemblyInfo.ExplicitPropertyDocItem, false };
                yield return new object[] { GeneratedPages.ExplicitInterfaceImplementations, AssemblyInfo.ExplicitPropertyDocItem, true };
            }
        }

        [Theory]
        [MemberData(nameof(HasOwnPageData))]
        public void HasOwnPage_Should_return_expected(GeneratedPages generatedPages, DocItem item, bool result)
        {
            IGeneralContext context = Substitute.For<IGeneralContext>();
            ISettings settings = Substitute.For<ISettings>();

            context.Settings.Returns(settings);
            settings.GeneratedPages.Returns(generatedPages);

            Check.That(item.HasOwnPage(context)).IsEqualTo(result);
        }

        [Fact]
        public void HasOwnPage_Should_return_true_When_AssemblyDocItem_and_has_AssemblyPageName()
        {
            IGeneralContext context = Substitute.For<IGeneralContext>();
            ISettings settings = Substitute.For<ISettings>();

            context.Settings.Returns(settings);
            settings.GeneratedPages.Returns(GeneratedPages.Default);

            settings.AssemblyPageName.Returns("test");

            Check.That(AssemblyInfo.AssemblyDocItem.HasOwnPage(context)).IsTrue();
        }

        [Fact]
        public void HasOwnPage_Should_return_true_When_AssemblyDocItem_and_has_documentation()
        {
            IGeneralContext context = Substitute.For<IGeneralContext>();
            ISettings settings = Substitute.For<ISettings>();

            context.Settings.Returns(settings);
            settings.GeneratedPages.Returns(GeneratedPages.Default);

            Check.That(new AssemblyDocItem("Test", "Test", new XElement("test")).HasOwnPage(context)).IsTrue();
        }

        [Fact]
        public void HasOwnPage_Should_return_true_When_AssemblyDocItem_and_multiple_namespace()
        {
            IGeneralContext context = Substitute.For<IGeneralContext>();
            ISettings settings = Substitute.For<ISettings>();

            context.Settings.Returns(settings);
            context.Items.Returns(new DocItem[] { new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "namespace1", null), new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "namespace2", null) }.ToDictionary(i => i.Id));
            settings.GeneratedPages.Returns(GeneratedPages.Default);

            Check.That(AssemblyInfo.AssemblyDocItem.HasOwnPage(context)).IsTrue();
        }
    }
}
