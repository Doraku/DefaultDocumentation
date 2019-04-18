using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Test
{
    public class ConverterTest
    {
        [Fact]
        public void Test()
        {
            Check.That(nameof(Dummy)).IsNotNull();
            Check.That(nameof(DefaultDocumentation));
        }
    }
}
