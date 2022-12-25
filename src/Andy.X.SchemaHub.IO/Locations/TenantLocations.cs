using System.Globalization;

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


        // schemas

        public static string GetTenantSchemasDirectory(string tenant)
        {
            return Path.Combine(GetTenantDirectory(tenant), "schemas");
        }

        public static string GetTenantSchemaDirectory(string tenant, long schemaId)
        {
            return Path.Combine(GetTenantSchemasDirectory(tenant), schemaId.ToString());
        }

        public static string GetTenantSchemaJsonFile(string tenant, long schemaId, string schemaName, string version)
        {
            return Path.Combine(GetTenantSchemaDirectory(tenant, schemaId), $"{version}-{schemaName}.json");
        }
        public static string GetTenantSchemaYamlFile(string tenant, long schemaId, string schemaName, string version)
        {
            return Path.Combine(GetTenantSchemaDirectory(tenant, schemaId), $"{version}-{schemaName}.yaml");
        }

        public static string GetTenantSchemaCodeGenDirectory(string tenant, long schemaId)
        {
            return Path.Combine(GetTenantSchemaDirectory(tenant, schemaId), "code-generated");
        }

        public static string GetTenantSchemaCodeGenCsharpFile(string tenant, long schemaId, string schemaName, string version)
        {
            return Path.Combine(GetTenantSchemaCodeGenDirectory(tenant, schemaId), $"{version}-{schemaName}.cs");
        }

        public static string GetTenantSchemaCodeGenCsharpTypesFile(string tenant, long schemaId, string schemaName, string version)
        {
            return Path.Combine(GetTenantSchemaCodeGenDirectory(tenant, schemaId), $"{version}-{schemaName}-types.cs");
        }

        public static string GetTenantSchemaCodeGenTypeScriptFile(string tenant, long schemaId, string schemaName, string version)
        {
            return Path.Combine(GetTenantSchemaCodeGenDirectory(tenant, schemaId), $"{version}-{schemaName}.ts");
        }

        public static string GetTenantSchemaCodeGenTypeScriptTypesFile(string tenant, long schemaId, string schemaName, string version)
        {
            return Path.Combine(GetTenantSchemaCodeGenDirectory(tenant, schemaId), $"{version}-{schemaName}-types.ts");
        }
    }
}
