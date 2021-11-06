using System;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Models
{
    public sealed class ExternDocItemTest
    {
        [Fact]
        public void ExternDocItem_Should_throw_When_url_is_null() => Check.ThatCode(() => new ExternDocItem("T:id", null, null)).Throws<ArgumentNullException>();

        [Fact]
        public void Url_Should_return_url() => Check.That(new ExternDocItem("T:id", "test", null).Url).IsEqualTo("test");

        [Fact]
        public void FullName_Should_return_id_without_prefix() => Check.That(new ExternDocItem("T:id", "test", null).FullName).IsEqualTo("id");

        [Fact]
        public void Name_Should_return_name() => Check.That(new ExternDocItem("T:id", "test", "name").Name).IsEqualTo("name");
    }
}
