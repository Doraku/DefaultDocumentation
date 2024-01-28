using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members
{
    public sealed class ConstructorDocItemTest
    {
        [Fact]
        public void ConstructorDocItem_Should_throw_When_parent_is_null()
        {
            Check.ThatCode(() => new ConstructorDocItem(null!, null!, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ConstructorDocItem_Should_throw_When_method_is_null()
        {
            Check.ThatCode(() => new ConstructorDocItem(AssemblyInfo.ClassDocItem, null!, null)).Throws<ArgumentNullException>();
        }
    }
}
