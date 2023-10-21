using Microsoft.AspNetCore.Builder;
using Serilog;
using System.IO;

namespace Startup.LogSettings
{
    public static class SerilogSettings
    {
        public const string LogTemplateConsole =
            "[{Level:u3}] <{ThreadId}> :: {Message:lj}{NewLine}{Exception}";
        public const string LogTemplateFile =
            "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] <{ThreadId}> :: {Message:lj}{NewLine}{Exception}";
        public static void AddSerilog(this WebApplicationBuilder builder)
        {
            builder.Host
                .UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .WriteTo.Console(outputTemplate: LogTemplateConsole)
                .WriteTo.File(
                    outputTemplate: LogTemplateFile,
                    path: Path.Combine(Paths.Logs, ".log"),
                    shared: true,
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 1 * 1024 * 1024
                )
            );
        }
    }
}
