using Andy.X.SchemaHub.IO.Locations;

namespace Andy.X.SchemaHub.IO.Services
{
    public static class TenantIOService
    {
        public static bool TryCreateTenantDirectory(string tenant)
        {
            try
            {
                if (Directory.Exists(TenantLocations.GetTenantDirectory(tenant)) == true)
                {
                    return true;
                }

                Directory.CreateDirectory(TenantLocations.GetTenantDirectory(tenant));
                Directory.CreateDirectory(TenantLocations.GetTenantLogsDirectory(tenant));
                Directory.CreateDirectory(TenantLocations.GetTenantSchemasDirectory(tenant));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool TryCreateSchemaDirectory(string tenant, long schemaId)
        {
            try
            {
                if (Directory.Exists(TenantLocations.GetTenantSchemaDirectory(tenant, schemaId)) == true)
                {
                    return true;
                }

                Directory.CreateDirectory(TenantLocations.GetTenantSchemaDirectory(tenant, schemaId));
                Directory.CreateDirectory(TenantLocations.GetTenantSchemaCodeGenDirectory(tenant, schemaId));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool TryDeleteSchemaDirectory(string tenant, long schemaId)
        {
            try
            {
                Directory.Delete(TenantLocations.GetTenantSchemaDirectory(tenant, schemaId));
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
