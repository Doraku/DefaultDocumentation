using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NLog;
using NLog.Targets;

namespace DefaultDocumentation;

internal sealed class TaskTarget : TargetWithLayoutHeaderAndFooter
{
    private readonly TaskLoggingHelper _log;

    public TaskTarget(string name, TaskLoggingHelper log)
    {
        Name = name;
        _log = log;
    }

    protected override void Write(LogEventInfo logEvent)
    {
        string log = RenderLogEvent(Layout, logEvent);

        if (logEvent.Level == LogLevel.Trace
            || logEvent.Level == LogLevel.Debug
            || logEvent.Level == LogLevel.Info)
        {
            _log.LogMessage(MessageImportance.High, log);
        }
        else if (logEvent.Level == LogLevel.Warn)
        {
            _log.LogWarning(log);
        }
        else if (logEvent.Level == LogLevel.Error
            || logEvent.Level == LogLevel.Fatal)
        {
            _log.LogError(log);
        }
    }
}
