using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Types
{
    public sealed class TypeDocItemTest
    {
        [Fact]
        public void TypeDocItem_Should_throw_When_parent_is_null()
        {
            Check.ThatCode(() => new ClassDocItem(null!, null!, null)).Throws<ArgumentException>();
        }

        [Fact]
        public void TypeDocItem_Should_throw_When_type_is_null()
        {
            Check.ThatCode(() => new ClassDocItem(AssemblyInfo.NamespaceDocItem, null!, null)).Throws<ArgumentNullException>();
        }
    }
}
