using System;

namespace DefaultDocumentation.Markdown.Internal;

internal sealed class DisposableAction : IDisposable
{
    private readonly Action _action;

    public DisposableAction(Action action)
    {
        _action = action;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _action();
    }
}
