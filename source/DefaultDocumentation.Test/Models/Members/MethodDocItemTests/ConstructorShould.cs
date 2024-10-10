using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members.MethodDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new MethodDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenEventIsNull()
    {
        Check.ThatCode(() => new MethodDocItem(AssemblyInfo.ClassDocItem, null!, null)).Throws<ArgumentNullException>();
    }
}
