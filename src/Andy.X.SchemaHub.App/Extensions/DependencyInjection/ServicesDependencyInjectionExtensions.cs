using Andy.X.SchemaHub.Core.Abstractions.Services;
using Andy.X.SchemaHub.Core.Services.Schemas;
using Andy.X.SchemaHub.Core.Services.Tenants;
using Microsoft.Extensions.DependencyInjection;

namespace Andy.X.SchemaHub.App.Extensions.DependencyInjection
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ITenantService, TenantService>();
            services.AddSingleton<ISchemaService, SchemaService>();
        }
    }
}
