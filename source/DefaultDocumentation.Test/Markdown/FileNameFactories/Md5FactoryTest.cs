using DefaultDocumentation.Markdown.FileNameFactories;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Markdown.FileNameFactories
{
    public sealed class Md5FactoryTest : AFileNameFactoryTest<Md5Factory>
    {
        [Fact]
        public void Name_Should_return_FullName() => Check.That(Name).IsEqualTo("Md5");

        [Fact]
        public void GetFileName_Should_return_Md5() => Test(AssemblyInfo.ClassDocItem, "NFMDH6WUUDQ1ZFSD9PKB7FIB9.md");
 
        [Fact]
        public void GetFileName_Should_encode_as_nonnegative_BigInteger() =>
            // Note: this name value was specifically chosen so that new BigInteger(MD5(UTF8Bytes(name))) < 0, therefore
            // making our extra logic to ensure it is non-negative important.
            GetAndValidateHash("ab");

        [Fact]
        public void GetFileName_Should_produce_shorter_hashes_for_leading_zeros() =>
            // Note: this name value was specifically chosen so that the MD5 hash has multiple trailing zeros, yielding
            // a small BigInteger value that requires fewer digits to encode
            Check.That(GetAndValidateHash("W6D.IDDYuW")).IsEqualTo("9M5VBXDZBVZ0R9EMU25.md");

        private string GetAndValidateHash(string fullName)
        {
            DocItem item = new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, fullName, documentation: null);
            string hash = new Md5Factory().GetFileName(_context.Value, item);
            Check.That(hash).Matches(@"^[0-9A-Z]{1,25}\.md$");
            return hash;
        }
    }
}
