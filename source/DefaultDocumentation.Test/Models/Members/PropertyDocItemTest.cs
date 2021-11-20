using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members
{
    public sealed class PropertyDocItemTest
    {
        [Fact]
        public void PropertyDocItem_Should_throw_When_parent_is_null()
        {
            Check.ThatCode(() => new PropertyDocItem(null, null, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void PropertyDocItem_Should_throw_When_event_is_null()
        {
            Check.ThatCode(() => new PropertyDocItem(AssemblyInfo.ClassDocItem, null, null)).Throws<ArgumentNullException>();
        }
    }
}
