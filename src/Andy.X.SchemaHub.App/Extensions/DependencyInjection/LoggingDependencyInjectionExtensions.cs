using Andy.X.SchemaHub.IO.Locations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Andy.X.SchemaHub.App.Extensions.DependencyInjection
{
    public static class LoggingDependencyInjectionExtensions
    {
        public static void AddSerilogLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string logFileLocatiom = AppLocations.LogFile();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.File(logFileLocatiom,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss}  andyx-schemahub   {Level,-12} {0,-3} | {0,-3} {Message}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
