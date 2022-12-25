namespace Andy.X.SchemaHub.IO.Locations
{
    public static class AppLocations
    {
        public static string GetRootDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetDataDirectory()
        {
            return Path.Combine(GetRootDirectory(), "data");
        }

        public static string GetLogsDirectory()
        {
            return Path.Combine(GetDataDirectory(), "log");
        }

        public static string LogFile()
        {
            // date is added from serilog logging library.
            return Path.Combine(GetLogsDirectory(), "schemahub_.log");
        }

        public static string GetStoreDirectory()
        {
            return Path.Combine(GetDataDirectory(), "store");
        }

        public static string GetTenantStoreFile()
        {
            return Path.Combine(GetStoreDirectory(), "tenants_store.andx");
        }

        public static string GetSchemasDirectory()
        {
            return Path.Combine(GetStoreDirectory(), "schemas-log");
        }

        public static string GetschemasStoreFile()
        {
            return Path.Combine(GetSchemasDirectory(), "schemas_store.andx");
        }
    }
}
