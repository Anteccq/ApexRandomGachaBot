using Discord;
using Microsoft.Extensions.Logging;

namespace ApexRandomGachaBot.Logging;

public static class LogSeverityExtensions
{
    public static LogLevel ToLogLevel(this LogSeverity severity)
        => severity switch
        {
            LogSeverity.Critical => LogLevel.Critical,
            LogSeverity.Warning => LogLevel.Warning,
            LogSeverity.Error => LogLevel.Error,
            LogSeverity.Debug => LogLevel.Debug,
            LogSeverity.Info => LogLevel.Information,
            LogSeverity.Verbose => LogLevel.Trace,
            _ => LogLevel.None
        };
}