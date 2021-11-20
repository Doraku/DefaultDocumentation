using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members
{
    public sealed class EventDocItemTest
    {
        [Fact]
        public void EventDocItem_Should_throw_When_parent_is_null()
        {
            Check.ThatCode(() => new EventDocItem(null, null, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void EventDocItem_Should_throw_When_event_is_null()
        {
            Check.ThatCode(() => new EventDocItem(AssemblyInfo.ClassDocItem, null, null)).Throws<ArgumentNullException>();
        }
    }
}
