using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Contexts;
using Andy.X.SchemaHub.Model.Entities.Tenants;
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

        public void AddTenant(string tenantName)
        {
            throw new NotImplementedException();
        }

        public void ChangeStatus(long id, TenantStatus tenantStatus)
        {
            throw new NotImplementedException();
        }

        public List<Tenant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tenant GetTenant(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveTenant(long id)
        {
            throw new NotImplementedException();
        }
    }
}
