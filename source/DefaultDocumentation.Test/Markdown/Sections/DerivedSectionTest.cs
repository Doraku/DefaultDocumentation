﻿using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class DerivedSectionTest : ASectionTest<DerivedSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[]
        {
            AssemblyInfo.ClassDocItem,
            AssemblyInfo.StructDocItem
        }.ToDictionary(i => i.Id);

        [Fact]
        public void Name_should_be_Derived() => Check.That(Name).IsEqualTo("Derived");

        [Fact]
        public void Write_should_not_write_When_not_TypeDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.InterfaceDocItem,
@"Derived  
&#8627; [AssemblyInfo](T:DefaultDocumentation.AssemblyInfo 'DefaultDocumentation.AssemblyInfo')  
&#8627; [Struct](T:DefaultDocumentation.AssemblyInfo.Struct 'DefaultDocumentation.AssemblyInfo.Struct')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.InterfaceDocItem,
            w => w.Append("pouet"),
@"pouet

Derived  
&#8627; [AssemblyInfo](T:DefaultDocumentation.AssemblyInfo 'DefaultDocumentation.AssemblyInfo')  
&#8627; [Struct](T:DefaultDocumentation.AssemblyInfo.Struct 'DefaultDocumentation.AssemblyInfo.Struct')");
    }
}
