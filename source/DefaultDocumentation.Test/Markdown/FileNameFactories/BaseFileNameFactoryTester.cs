using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using NFluent;

namespace DefaultDocumentation.Markdown.FileNameFactories;

public class BaseFileNameFactoryTester<T> : BaseWriterTester
    where T : IFileNameFactory, new()
{
    private readonly T _factory;

    public string Name => _factory.Name;

    protected BaseFileNameFactoryTester()
    {
        _factory = new T();
    }

    protected void Test(DocItem item, string expectedFileName) => Check.That(_factory.GetFileName(_context.Value, item)).IsEqualTo(expectedFileName);
}
