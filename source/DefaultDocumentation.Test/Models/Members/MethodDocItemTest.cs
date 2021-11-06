using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members
{
    public sealed class EventDMethodDocItemTestcItemTest
    {
        [Fact]
        public void MethodDocItem_Should_throw_When_parent_is_null()
        {
            Check.ThatCode(() => new MethodDocItem(null, null, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void MethodDocItem_Should_throw_When_event_is_null()
        {
            Check.ThatCode(() => new MethodDocItem(AssemblyInfo.ClassDocItem, null, null)).Throws<ArgumentNullException>();
        }
    }
}
