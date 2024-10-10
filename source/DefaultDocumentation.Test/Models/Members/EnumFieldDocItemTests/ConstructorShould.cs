using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.Members.EnumFieldDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenParentIsNull()
    {
        Check.ThatCode(() => new EnumFieldDocItem(null!, null!, null)).Throws<ArgumentNullException>();
    }

    [Fact]
    public void ThrowWhenFieldIsNull()
    {
        Check.ThatCode(() => new EnumFieldDocItem(AssemblyInfo.EnumDocItem, null!, null)).Throws<ArgumentNullException>();
    }
}
