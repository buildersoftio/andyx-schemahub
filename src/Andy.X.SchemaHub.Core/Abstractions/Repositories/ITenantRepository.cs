using Andy.X.SchemaHub.Model.Entities.Tenants;

namespace Andy.X.SchemaHub.Core.Abstractions.Repositories
{
    public interface ITenantRepository
    {
        void AddTenant(Tenant tenant);
        void RemoveTenant(long id);
        void UpdateTenant(Tenant tenant);

        Tenant GetTenant(long id);
        Tenant GetTenant(string tenantName);
        List<Tenant> GetTenants();
    }
}
