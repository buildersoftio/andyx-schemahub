namespace Andy.X.SchemaHub.IO.Locations
{
    public static class TenantLocations
    {
        public static string GetTenantDirectory(string tenant)
        {
            return Path.Combine(AppLocations.GetStoreDirectory(), tenant);
        }

        public static string GetTenantLogsDirectory(string tenant)
        {
            return Path.Combine(TenantLocations.GetTenantDirectory(tenant), "logs");
        }
    }
}
