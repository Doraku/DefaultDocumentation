using System;
using Microsoft.Extensions.Logging;

namespace DefaultDocumentation;

internal sealed class ConsoleLogger : ILogger
{
    private sealed class DummyDisposable : IDisposable
    {
        public void Dispose() { }
    }

    private const string _header = "[DefaultDocumentation]";

    private static readonly IDisposable _scope = new DummyDisposable();

    private readonly LogLevel _logLevel;

    public ConsoleLogger(LogLevel logLevel)
    {
        _logLevel = logLevel;
    }

    public IDisposable BeginScope<TState>(TState state) => _scope;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= _logLevel;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        Console.WriteLine(_header + $"[{logLevel}] " + formatter(state, exception));
    }
}
