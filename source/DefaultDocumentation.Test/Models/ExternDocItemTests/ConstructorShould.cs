using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.ExternDocItemTests;

public sealed class ConstructorShould
{
    [Fact]
    public void ThrowWhenUrlIsNull()
    {
        Check.ThatCode(() => new ExternDocItem("T:id", null!, null)).Throws<ArgumentNullException>();
    }
}
