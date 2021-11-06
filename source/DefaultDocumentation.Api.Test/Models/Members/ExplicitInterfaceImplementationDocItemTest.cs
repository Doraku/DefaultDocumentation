using System;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members
{
    public sealed class ExplicitInterfaceImplementationDocItemTest
    {
        [Fact]
        public void ExplicitInterfaceImplementationDocItem_Should_throw_When_parent_is_null_for_property()
        {
            Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(null, default(IProperty), null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ExplicitInterfaceImplementationDocItem_Should_throw_When_method_is_null_for_property()
        {
            Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(AssemblyInfo.ClassDocItem, default(IProperty), null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ExplicitInterfaceImplementationDocItem_Should_throw_When_parent_is_null_for_method()
        {
            Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(null, default(IMethod), null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ExplicitInterfaceImplementationDocItem_Should_throw_When_method_is_null_for_method()
        {
            Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(AssemblyInfo.ClassDocItem, default(IMethod), null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ExplicitInterfaceImplementationDocItem_Should_throw_When_parent_is_null_for_event()
        {
            Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(null, default(IEvent), null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ExplicitInterfaceImplementationDocItem_Should_throw_When_method_is_null_for_event()
        {
            Check.ThatCode(() => new ExplicitInterfaceImplementationDocItem(AssemblyInfo.ClassDocItem, default(IEvent), null)).Throws<ArgumentNullException>();
        }
    }
}
