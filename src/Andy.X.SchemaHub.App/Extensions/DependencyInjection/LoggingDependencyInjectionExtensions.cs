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
                .WriteTo.File(logFileLocatiom, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
