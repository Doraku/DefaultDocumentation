using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.ExternDocItemTests;

public sealed class FullNameShould
{
    [Fact]
    public void ReturnIdWithoutPrefix()
    {
        Check.That(new ExternDocItem("T:id", "test", null).FullName).IsEqualTo("id");
    }
}
