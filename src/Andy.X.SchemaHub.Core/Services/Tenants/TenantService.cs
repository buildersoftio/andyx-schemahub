using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Abstractions.Services;
using Andy.X.SchemaHub.IO.Services;
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
            var tenant = GetTenant(tenantName);
            if (tenant == null)
            {
                return false;
            }

            tenant.Status = status;
            tenant.UpdatedDate = DateTime.UtcNow;

            _tenantRepository.UpdateTenant(tenant);

            return true;
        }

        public bool CreateTenant(string tenantName)
        {
            try
            {
                var tenant = new Tenant()
                {
                    Name = tenantName,
                    Status = TenantStatus.Active,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "system"
                };

                _tenantRepository.AddTenant(tenant);

                TenantIOService.TryCreateTenantDirectory(tenantName);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong! Tenant cannot be added, details: {ex.Message}");
                return false;
            }

        }

        public bool DeleteTenant(string tenantName)
        {
            try
            {
                var tenant = GetTenant(tenantName);
                _tenantRepository.RemoveTenant(tenant.Id);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong! Tenant cannot be deleted, details: {ex.Message}");
                return false;
            }
        }

        public Tenant GetTenant(string tenant)
        {
            return _tenantRepository
                .GetTenant(tenant);
        }

        public List<string> GetTenants()
        {
            return _tenantRepository
                .GetTenants()
                .Select(t => t.Name)
                .ToList();
        }
    }
}
