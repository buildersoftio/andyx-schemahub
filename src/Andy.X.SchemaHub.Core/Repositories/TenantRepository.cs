using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Contexts;
using Andy.X.SchemaHub.Model.Entities.Tenants;
using Microsoft.Extensions.Logging;

namespace Andy.X.SchemaHub.Core.Repositories
{
    public class TenantRepository : ITenantRepository
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

        public void AddTenant(Tenant tenant)
        {
            lock (tenantDbContext)
            {
                tenantDbContext
                    .Tenants
                    .Add(tenant);

                tenantDbContext.SaveChanges();
            }
        }

        public void UpdateTenant(Tenant tenant)
        {
            lock (tenantDbContext)
            {
                tenantDbContext.Tenants.Update(tenant);
                tenantDbContext.SaveChanges();
            }
        }

        public List<Tenant> GetTenants()
        {
            return tenantDbContext
                .Tenants
                .ToList();
        }

        public Tenant GetTenant(long id)
        {
            return tenantDbContext
                .Tenants
                .Find(id)!;
        }

        public void RemoveTenant(long id)
        {
            var tenant = tenantDbContext.Tenants.Find(id);
            if (tenant == null)
            {
                return;
            }

            tenantDbContext.Tenants.Remove(tenant);
            tenantDbContext.SaveChanges();
        }

        public Tenant GetTenant(string tenantName)
        {
            return tenantDbContext
                .Tenants
                .Where(x => x.Name == tenantName)
                .FirstOrDefault()!;
        }
    }
}
