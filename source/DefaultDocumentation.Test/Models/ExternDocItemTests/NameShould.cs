using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.ExternDocItemTests;

public sealed class NameShould
{
    [Fact]
    public void ReturnName()
    {
        Check.That(new ExternDocItem("T:id", "test", "name").Name).IsEqualTo("name");
    }
}
