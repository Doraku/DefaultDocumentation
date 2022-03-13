using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using NFluent;

namespace DefaultDocumentation.Markdown.Markdown.FileNameFactories
{
    public class AFileNameFactoryTest<T> : AWriterTest
        where T : IFileNameFactory, new()
    {
        private readonly T _factory;

        public string Name => _factory.Name;

        protected AFileNameFactoryTest()
        {
            _factory = new T();
        }

        protected void Test(DocItem item, string expectedFileName) => Check.That(_factory.GetFileName(_context.Value, item)).IsEqualTo(expectedFileName);
    }
}
