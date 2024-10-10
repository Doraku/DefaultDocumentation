using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members.OperatorDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new OperatorDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenEventIsNull()
    {
        Check.ThatCode(() => new OperatorDocItem(AssemblyInfo.ClassDocItem, null!, null)).Throws<ArgumentNullException>();
    }
}
