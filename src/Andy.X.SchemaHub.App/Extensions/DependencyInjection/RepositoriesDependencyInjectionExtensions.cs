using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Andy.X.SchemaHub.App.Extensions.DependencyInjection
{
    public static class RepositoriesDependencyInjectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ITenantRepository, TenantRepository>();
            services.AddSingleton<ISchemaRepository, SchemaRepository>();
        }
    }
}
