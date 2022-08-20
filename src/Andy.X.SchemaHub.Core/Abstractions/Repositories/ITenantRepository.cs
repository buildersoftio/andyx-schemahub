using Andy.X.SchemaHub.Model.Entities.Tenants;

namespace Andy.X.SchemaHub.Core.Abstractions.Repositories
{
    public interface ITenantRepository
    {
        void AddTenant(string tenantName);
        void RemoveTenant(long id);
        void ChangeStatus(long id, TenantStatus tenantStatus);

        Tenant GetTenant(long id);
        List<Tenant> GetAll();
    }
}
