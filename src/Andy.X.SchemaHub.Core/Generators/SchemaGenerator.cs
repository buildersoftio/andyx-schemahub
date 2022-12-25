using Andy.X.SchemaHub.IO.Services;
using Andy.X.SchemaHub.Model.Dtos;
using Andy.X.SchemaHub.Model.Entities.Schemas;
using Andy.X.SchemaHub.Model.Entities.Tenants;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using NJsonSchema.CodeGeneration.TypeScript;
using NJsonSchema.Yaml;

namespace Andy.X.SchemaHub.Core.Generators
{
    public static class SchemaGenerator
    {
        public static void GenerateSchemaFiles(SchemaDefinitionRequest schemaDefinitionDto, Tenant tenant, Schema schema)
        {
            var schemaJson = JsonSchema.FromJsonAsync(schemaDefinitionDto.SchemaPayload).Result;

            var jsonSchema = schemaJson.ToJson();
            var yamlSchema = schemaJson.ToYaml();

            var csharGen = new CSharpGenerator(schemaJson, new CSharpGeneratorSettings()
            {
                ClassStyle = CSharpClassStyle.Poco,
                HandleReferences = true,
                Namespace = $"AndyXSchemaHub.CsharpGenerated.{schema.Name}"
            });

            var csharpGeneratedSchema = csharGen.GenerateFile();
            var csharpTypeGeneratedSchema = string.Join("\n\n", csharGen.GenerateTypes().ToList().Select(x => x.Code));

            var tsGen = new TypeScriptGenerator(schemaJson);
            var typescriptGeneratedSchema = tsGen.GenerateFile();
            var typescriptTypeGeneratedSchema = string.Join("\n\n", tsGen.GenerateTypes().ToList().Select(x => x.Code));


            // now we have to store C# and TS code from the the schema.
            SchemaIOService.WriteJsonSchemaFile(tenant.Name, schema.Id, schema.Name, schemaDefinitionDto.Version, jsonSchema);
            SchemaIOService.WriteYamlSchemaFile(tenant.Name, schema.Id, schema.Name, schemaDefinitionDto.Version, yamlSchema);

            SchemaIOService.WriteCsharpSchemaFile(tenant.Name, schema.Id, schema.Name, schemaDefinitionDto.Version, csharpGeneratedSchema);
            SchemaIOService.WriteCsharpTypeSchemaFile(tenant.Name, schema.Id, schema.Name, schemaDefinitionDto.Version, csharpTypeGeneratedSchema);

            SchemaIOService.WriteTsSchemaFile(tenant.Name, schema.Id, schema.Name, schemaDefinitionDto.Version, typescriptGeneratedSchema);
            SchemaIOService.WriteTsTypeSchemaFile(tenant.Name, schema.Id, schema.Name, schemaDefinitionDto.Version, typescriptTypeGeneratedSchema);
        }

    }
}
