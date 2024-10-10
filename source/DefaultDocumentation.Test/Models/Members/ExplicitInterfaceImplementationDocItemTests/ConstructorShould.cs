using System;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members.ExplicitInterfaceImplementationDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNullForProperty()
    {
        Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(null!, default(IProperty)!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenMethodIsNullForProperty()
    {
        Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(AssemblyInfo.ClassDocItem, default(IProperty)!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenParentIsNullForMethod()
    {
        Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(null!, default(IMethod)!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenMethodIsNullForMethod()
    {
        Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(AssemblyInfo.ClassDocItem, default(IMethod)!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenParentIsNullForEvent()
    {
        Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(null!, default(IEvent)!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenMethodIsNullForEvent()
    {
        Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(AssemblyInfo.ClassDocItem, default(IEvent)!, null)).Throws<ArgumentNullException>();
    }
}
