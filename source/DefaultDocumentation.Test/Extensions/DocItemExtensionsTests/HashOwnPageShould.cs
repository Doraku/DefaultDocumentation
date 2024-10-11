using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultDocumentation.Extensions.DocItemExtensionsTests;

public sealed class HashOwnPageShould
{
    public static TheoryData<GeneratedPages, DocItem, bool> HasOwnPageData
        => new()
        {
            { GeneratedPages.Default, AssemblyInfo.AssemblyDocItem, false },
            { GeneratedPages.Assembly, AssemblyInfo.AssemblyDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.NamespaceDocItem, false },
            { GeneratedPages.Namespaces, AssemblyInfo.NamespaceDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.ClassDocItem, false },
            { GeneratedPages.Classes, AssemblyInfo.ClassDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.DelegateDocItem, false },
            { GeneratedPages.Delegates, AssemblyInfo.DelegateDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.EnumDocItem, false },
            { GeneratedPages.Enums, AssemblyInfo.EnumDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.StructDocItem, false },
            { GeneratedPages.Structs, AssemblyInfo.StructDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.InterfaceDocItem, false },
            { GeneratedPages.Interfaces, AssemblyInfo.InterfaceDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.ConstructorDocItem, false },
            { GeneratedPages.Constructors, AssemblyInfo.ConstructorDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.EventDocItem, false },
            { GeneratedPages.Events, AssemblyInfo.EventDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.FieldDocItem, false },
            { GeneratedPages.Fields, AssemblyInfo.FieldDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.MethodWithReturnDocItem, false },
            { GeneratedPages.Methods, AssemblyInfo.MethodWithReturnDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.OperatorDocItem, false },
            { GeneratedPages.Operators, AssemblyInfo.OperatorDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.PropertyDocItem, false },
            { GeneratedPages.Properties, AssemblyInfo.PropertyDocItem, true },

            { GeneratedPages.Default, AssemblyInfo.ExplicitPropertyDocItem, false },
            { GeneratedPages.ExplicitInterfaceImplementations, AssemblyInfo.ExplicitPropertyDocItem, true }
        };

    [Theory]
    [MemberData(nameof(HasOwnPageData))]
    public void ReturnExpected(GeneratedPages generatedPages, DocItem item, bool result)
    {
        IGeneralContext context = Substitute.For<IGeneralContext>();
        ISettings settings = Substitute.For<ISettings>();

        context.Settings.Returns(settings);
        settings.GeneratedPages.Returns(generatedPages);

        Check.That(item.HasOwnPage(context)).IsEqualTo(result);
    }

    [Fact]
    public void ReturnTrueWhenAssemblyDocItemAndHasAssemblyPageName()
    {
        IGeneralContext context = Substitute.For<IGeneralContext>();
        ISettings settings = Substitute.For<ISettings>();

        context.Settings.Returns(settings);
        settings.GeneratedPages.Returns(GeneratedPages.Default);

        settings.AssemblyPageName.Returns("test");

        Check.That(AssemblyInfo.AssemblyDocItem.HasOwnPage(context)).IsTrue();
    }

    [Fact]
    public void ReturnTrueWhenAssemblyDocItemAndHasDocumentation()
    {
        IGeneralContext context = Substitute.For<IGeneralContext>();
        ISettings settings = Substitute.For<ISettings>();

        context.Settings.Returns(settings);
        settings.GeneratedPages.Returns(GeneratedPages.Default);

        Check.That(new AssemblyDocItem("Test", "Test", new XElement("test")).HasOwnPage(context)).IsTrue();
    }

    [Fact]
    public void ReturnTrueWhenAssemblyDocItemAndMultipleNamespace()
    {
        IGeneralContext context = Substitute.For<IGeneralContext>();
        ISettings settings = Substitute.For<ISettings>();

        context.Settings.Returns(settings);
        context.Items.Returns(new DocItem[] { new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "namespace1", null), new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "namespace2", null) }.ToDictionary(item => item.Id));
        settings.GeneratedPages.Returns(GeneratedPages.Default);

        Check.That(AssemblyInfo.AssemblyDocItem.HasOwnPage(context)).IsTrue();
    }
}
