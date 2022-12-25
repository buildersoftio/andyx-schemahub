using Andy.X.SchemaHub.IO.Locations;

namespace Andy.X.SchemaHub.IO.Services
{
    public static class SchemaIOService
    {

        public static bool WriteJsonSchemaFile(string tenant, long schemaId, string schemaName, string version, string jsonContent)
        {
            try
            {
                if (File.Exists(TenantLocations.GetTenantSchemaJsonFile(tenant, schemaId, schemaName, version)))
                {
                    File.Delete(TenantLocations.GetTenantSchemaJsonFile(tenant, schemaId, schemaName, version));
                }

                File.WriteAllText(TenantLocations.GetTenantSchemaJsonFile(tenant, schemaId, schemaName, version), jsonContent);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool WriteYamlSchemaFile(string tenant, long schemaId, string schemaName, string version, string yamlContent)
        {
            try
            {
                if (File.Exists(TenantLocations.GetTenantSchemaYamlFile(tenant, schemaId, schemaName, version)))
                {
                    File.Delete(TenantLocations.GetTenantSchemaYamlFile(tenant, schemaId, schemaName, version));
                }

                File.WriteAllText(TenantLocations.GetTenantSchemaYamlFile(tenant, schemaId, schemaName, version), yamlContent);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WriteCsharpSchemaFile(string tenant, long schemaId, string schemaName, string version, string csharpContent)
        {
            try
            {
                if (File.Exists(TenantLocations.GetTenantSchemaCodeGenCsharpFile(tenant, schemaId, schemaName, version)))
                {
                    File.Delete(TenantLocations.GetTenantSchemaCodeGenCsharpFile(tenant, schemaId, schemaName, version));
                }

                File.WriteAllText(TenantLocations.GetTenantSchemaCodeGenCsharpFile(tenant, schemaId, schemaName, version), csharpContent);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool WriteCsharpTypeSchemaFile(string tenant, long schemaId, string schemaName, string version, string csharpContent)
        {
            try
            {
                if (File.Exists(TenantLocations.GetTenantSchemaCodeGenCsharpTypesFile(tenant, schemaId, schemaName, version)))
                {
                    File.Delete(TenantLocations.GetTenantSchemaCodeGenCsharpTypesFile(tenant, schemaId, schemaName, version));
                }

                File.WriteAllText(TenantLocations.GetTenantSchemaCodeGenCsharpTypesFile(tenant, schemaId, schemaName, version), csharpContent);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WriteTsSchemaFile(string tenant, long schemaId, string schemaName, string version, string tsContent)
        {
            try
            {
                if (File.Exists(TenantLocations.GetTenantSchemaCodeGenTypeScriptFile(tenant, schemaId, schemaName, version)))
                {
                    File.Delete(TenantLocations.GetTenantSchemaCodeGenTypeScriptFile(tenant, schemaId, schemaName, version));
                }

                File.WriteAllText(TenantLocations.GetTenantSchemaCodeGenTypeScriptFile(tenant, schemaId, schemaName, version), tsContent);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool WriteTsTypeSchemaFile(string tenant, long schemaId, string schemaName, string version, string tsContent)
        {
            try
            {
                if (File.Exists(TenantLocations.GetTenantSchemaCodeGenTypeScriptTypesFile(tenant, schemaId, schemaName, version)))
                {
                    File.Delete(TenantLocations.GetTenantSchemaCodeGenTypeScriptTypesFile(tenant, schemaId, schemaName, version));
                }

                File.WriteAllText(TenantLocations.GetTenantSchemaCodeGenTypeScriptTypesFile(tenant, schemaId, schemaName, version), tsContent);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static string ReadJsonSchema(string tenant, long schemaId, string schemaName, string version)
        {
            if (File.Exists(TenantLocations.GetTenantSchemaJsonFile(tenant, schemaId, schemaName, version)) != true)
                return "";

            return File.ReadAllText(TenantLocations.GetTenantSchemaJsonFile(tenant, schemaId, schemaName, version));
        }
        public static string ReadYamlSchema(string tenant, long schemaId, string schemaName, string version)
        {
            if (File.Exists(TenantLocations.GetTenantSchemaYamlFile(tenant, schemaId, schemaName, version)) != true)
                return "";

            return File.ReadAllText(TenantLocations.GetTenantSchemaYamlFile(tenant, schemaId, schemaName, version));
        }

        public static string ReadCsharpSchema(string tenant, long schemaId, string schemaName, string version)
        {
            if (File.Exists(TenantLocations.GetTenantSchemaCodeGenCsharpFile(tenant, schemaId, schemaName, version)) != true)
                return "";

            return File.ReadAllText(TenantLocations.GetTenantSchemaCodeGenCsharpFile(tenant, schemaId, schemaName, version));
        }
        public static string ReadCsharpTypesSchema(string tenant, long schemaId, string schemaName, string version)
        {
            if (File.Exists(TenantLocations.GetTenantSchemaCodeGenCsharpTypesFile(tenant, schemaId, schemaName, version)) != true)
                return "";

            return File.ReadAllText(TenantLocations.GetTenantSchemaCodeGenCsharpTypesFile(tenant, schemaId, schemaName, version));
        }

        public static string ReadTsSchema(string tenant, long schemaId, string schemaName, string version)
        {
            if (File.Exists(TenantLocations.GetTenantSchemaCodeGenTypeScriptFile(tenant, schemaId, schemaName, version)) != true)
                return "";

            return File.ReadAllText(TenantLocations.GetTenantSchemaCodeGenTypeScriptFile(tenant, schemaId, schemaName, version));
        }
        public static string ReadTsTypesSchema(string tenant, long schemaId, string schemaName, string version)
        {
            if (File.Exists(TenantLocations.GetTenantSchemaCodeGenTypeScriptTypesFile(tenant, schemaId, schemaName, version)) != true)
                return "";

            return File.ReadAllText(TenantLocations.GetTenantSchemaCodeGenTypeScriptTypesFile(tenant, schemaId, schemaName, version));
        }
    }
}
