using System;
using Microsoft.Build.Utilities;
using Microsoft.Extensions.Logging;

namespace DefaultDocumentation;

internal sealed class TaskLogger : ILogger
{
    private sealed class DummyDisposable : IDisposable
    {
        public void Dispose() { }
    }

    private const string _header = "[DefaultDocumentation]";

    private static readonly IDisposable _scope = new DummyDisposable();

    private readonly TaskLoggingHelper _logger;
    private readonly LogLevel _logLevel;

    public TaskLogger(TaskLoggingHelper logger, LogLevel logLevel)
    {
        _logger = logger;
        _logLevel = logLevel;
    }

    public IDisposable BeginScope<TState>(TState state) => _scope;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= _logLevel;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        string message = _header + $"[{logLevel}] " + formatter(state, exception);
        switch (logLevel)
        {
            case LogLevel.Trace:
            case LogLevel.Debug:
            case LogLevel.Information:
                _logger.LogMessage(message);
                break;

            case LogLevel.Warning:
                _logger.LogWarning(message);
                break;

            case LogLevel.Error:
            case LogLevel.Critical:
                _logger.LogError(message);
                break;
        }
    }
}
