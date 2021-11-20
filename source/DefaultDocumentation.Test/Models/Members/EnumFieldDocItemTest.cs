using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members
{
    public sealed class EnumFieldDocItemTest
    {
        [Fact]
        public void EnumFieldDocItem_Should_throw_When_parent_is_null()
        {
            Check.ThatCode(() => new EnumFieldDocItem(null, null, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void EnumFieldDocItem_Should_throw_When_field_is_null()
        {
            Check.ThatCode(() => new EnumFieldDocItem(AssemblyInfo.EnumDocItem, null, null)).Throws<ArgumentNullException>();
        }
    }
}
