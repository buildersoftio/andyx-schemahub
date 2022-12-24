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

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
