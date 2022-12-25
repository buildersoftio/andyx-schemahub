using Andy.X.SchemaHub.Model.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Andy.X.SchemaHub.App.Extensions.DependencyInjection
{
    public static class ConfigurationDependencyInjectionExtensions
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.BindNodeConfiguration(configuration);
            services.BindCredentialsConfiguration(configuration);
        }

        private static void BindNodeConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var nodeConfiguration = new NodeConfiguration();
            nodeConfiguration.NodeId = configuration.GetValue<string>("NodeId");
            services.AddSingleton(nodeConfiguration);
        }

        private static void BindCredentialsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var credentialsConfiguration = new List<CredentialsConfiguration>();
            configuration.Bind("Credentials", credentialsConfiguration);
            services.AddSingleton(credentialsConfiguration);
        }
    }
}
