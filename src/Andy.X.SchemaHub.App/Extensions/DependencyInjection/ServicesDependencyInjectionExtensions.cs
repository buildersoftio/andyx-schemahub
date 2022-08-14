using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Andy.X.SchemaHub.App.Extensions.DependencyInjection
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ISchemaRepository, SchemaRepository>();
        }
    }
}
