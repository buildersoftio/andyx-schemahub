using Andy.X.SchemaHub.Model.Entities.Tenants;

namespace Andy.X.SchemaHub.Core.Abstractions.Services
{
    public interface ITenantService
    {
        bool CreateTenant(string tenantName);
        bool DeleteTenant(string tenantName);

        bool ChangeTenantStatus(string tenantName, TenantStatus status);

        Tenant GetTenantDetails(string tenant);
        List<Tenant> GetTenants();
    }
}
