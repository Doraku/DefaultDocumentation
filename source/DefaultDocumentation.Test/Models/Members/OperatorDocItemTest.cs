using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members
{
    public sealed class OperatorDocItemTest
    {
        [Fact]
        public void OperatorDocItem_Should_throw_When_parent_is_null()
        {
            Check.ThatCode(() => new OperatorDocItem(null, null, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void OperatorDocItem_Should_throw_When_event_is_null()
        {
            Check.ThatCode(() => new OperatorDocItem(AssemblyInfo.ClassDocItem, null, null)).Throws<ArgumentNullException>();
        }
    }
}
