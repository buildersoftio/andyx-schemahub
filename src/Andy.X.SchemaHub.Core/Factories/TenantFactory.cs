using Andy.X.SchemaHub.Core.Abstractions.Factories;
using Andy.X.SchemaHub.Model.Entities.Tenants;

namespace Andy.X.SchemaHub.Core.Factories
{
    public class TenantFactory : ITenantFactory
    {
        public Tenant CreateTenantEntity(string tenantName, TenantStatus tenantStatus, string addedBy)
        {
            return new Tenant()
            {
                Name = tenantName,
                Status = tenantStatus,
                CreatedDate = DateTime.Now,
                CreatedBy = addedBy
            };
        }
    }
}
