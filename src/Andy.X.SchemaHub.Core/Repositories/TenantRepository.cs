using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Contexts;
using Microsoft.Extensions.Logging;

namespace Andy.X.SchemaHub.Core.Repositories
{
    public class TenantRepository: ITenantRepository
    {
        private readonly ILogger<TenantRepository> _logger;
        private readonly TenantDbContext tenantDbContext;

        public TenantRepository(ILogger<TenantRepository> logger)
        {
            _logger = logger;

            // TODO: check how this will operate in a load-test
            tenantDbContext = new TenantDbContext();
            tenantDbContext.Database.EnsureCreated();
        }
    }
}
