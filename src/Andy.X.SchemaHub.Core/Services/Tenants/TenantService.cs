using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Abstractions.Services;
using Andy.X.SchemaHub.Model.Entities.Tenants;
using Microsoft.Extensions.Logging;

namespace Andy.X.SchemaHub.Core.Services.Tenants
{
    public class TenantService : ITenantService
    {
        private readonly ILogger<TenantService> _logger;
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ILogger<TenantService> logger, ITenantRepository tenantRepository)
        {
            _logger = logger;
            _tenantRepository = tenantRepository;
        }

        public bool ChangeTenantStatus(string tenantName, TenantStatus status)
        {
            throw new NotImplementedException();
        }

        public bool CreateTenant(string tenantName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTenant(string tenantName)
        {
            throw new NotImplementedException();
        }

        public Tenant GetTenantDetails(string tenant)
        {
            throw new NotImplementedException();
        }

        public List<Tenant> GetTenants()
        {
            throw new NotImplementedException();
        }
    }
}
