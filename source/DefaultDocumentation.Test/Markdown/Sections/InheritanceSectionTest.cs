﻿using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class InheritanceSectionTest : ASectionTest<InheritanceSection>
    {
        [Fact]
        public void Name_should_be_Inheritance() => Check.That(Name).IsEqualTo("Inheritance");

        [Fact]
        public void Write_should_not_write_When_not_TypeDocItem() => Test(string.Empty);

        [Fact]
        public void Write_should_not_write_When_StructDocItem() => Test(
            AssemblyInfo.StructDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.ClassDocItem,
            "Inheritance [System.Object](T:System.Object 'System.Object') &#129106; AssemblyInfo");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.ClassDocItem,
            w => w.Append("pouet"),
@"pouet

Inheritance [System.Object](T:System.Object 'System.Object') &#129106; AssemblyInfo");
    }
}
