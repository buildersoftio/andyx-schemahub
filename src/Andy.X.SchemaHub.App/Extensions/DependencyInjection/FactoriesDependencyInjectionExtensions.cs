using Andy.X.SchemaHub.Core.Abstractions.Factories;
using Andy.X.SchemaHub.Core.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Andy.X.SchemaHub.App.Extensions.DependencyInjection
{
    public static class FactoriesDependencyInjectionExtensions
    {
        public static void AddFactories(this IServiceCollection services)
        {
            services.AddSingleton<ITenantFactory, TenantFactory>();
            services.AddSingleton<ISchemaFactory, SchemaFactory>();
        }
    }
}
