using NFluent;
using Xunit;

namespace DefaultDocumentation.Models.ExternDocItemTests;

public sealed class UrlShould
{
    [Fact]
    public void ReturnUrl()
    {
        Check.That(new ExternDocItem("T:id", "test", null).Url).IsEqualTo("test");
    }
}
