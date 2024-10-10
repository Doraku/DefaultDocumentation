using System;
using DefaultDocumentation.Api;
using DefaultDocumentation.Internal;
using DefaultDocumentation.Models;
using NFluent;

namespace DefaultDocumentation.Markdown.Sections;

public abstract class BaseSectionTester<T> : BaseWriterTester
    where T : ISection, new()
{
    private readonly T _sectionWriter;

    public string Name => _sectionWriter.Name;

    protected BaseSectionTester()
    {
        _sectionWriter = new T();
    }

    protected void Test(DocItem item, Func<IWriter, IWriter> initializer, string expectedOutput)
    {
        _builder.Clear();
        IWriter writer = initializer(new PageWriter(_builder, new PageContext(_context.Value, item)));

        _sectionWriter.Write(writer);

        Check.That(_builder.ToString()).IsEqualTo(expectedOutput);
    }

    protected void Test(Func<IWriter, IWriter> initializer, string expectedOutput) => Test(_docItem, initializer, expectedOutput);

    protected void Test(DocItem item, string expectedOutput) => Test(item, static w => w, expectedOutput);

    protected void Test(string expectedOutput) => Test(_docItem, expectedOutput);
}
