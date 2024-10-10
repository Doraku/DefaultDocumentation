using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members.EventDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new EventDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenEventIsNull()
    {
        Check.ThatCode(() => new EventDocItem(AssemblyInfo.ClassDocItem, null!, null)).Throws<ArgumentNullException>();
    }
}
