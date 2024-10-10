using System.Text;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Internal;

internal sealed class PageWriter : IWriter
{
    private readonly StringBuilder _builder;

    public PageWriter(StringBuilder builder, IPageContext context)
    {
        _builder = builder;

        Context = context;
    }

    #region IWriter

    public IPageContext Context { get; }

    public int Length
    {
        get => _builder.Length;
        set => _builder.Length = value;
    }

    public IWriter Append(string value)
    {
        _builder.Append(value);

        return this;
    }

    public IWriter AppendLine()
    {
        if (Length > 0)
        {
            _builder.AppendLine();
        }

        return this;
    }

    public bool EndsWith(string value)
    {
        if (_builder.Length < value.Length)
        {
            return false;
        }

        for (int i = 0; i < value.Length; ++i)
        {
            if (value[i] != _builder[_builder.Length - value.Length + i])
            {
                return false;
            }
        }

        return true;
    }

    #endregion
}
