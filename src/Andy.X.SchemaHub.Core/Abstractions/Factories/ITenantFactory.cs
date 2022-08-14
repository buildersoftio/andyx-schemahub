using Andy.X.SchemaHub.Model.Entities.Tenants;

namespace Andy.X.SchemaHub.Core.Abstractions.Factories
{
    public interface ITenantFactory
    {
        Tenant CreateTenantEntity(string tenantName, TenantStatus tenantStatus, string addedBy);
    }
}
