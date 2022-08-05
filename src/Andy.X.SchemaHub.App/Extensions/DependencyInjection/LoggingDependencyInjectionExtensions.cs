using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Andy.X.SchemaHub.App.Extensions.DependencyInjection
{
    public static class LoggingDependencyInjectionExtensions
    {
        public static void AddSerilogLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //string logFileLocatiom = ConfigurationLocations.NodeLoggingFile();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                // initial, we are not storing logs here, logs will be stored in andy x topic.
                //.WriteTo.File(logFileLocatiom, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
