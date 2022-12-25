using Andy.X.SchemaHub.Model;
using Andy.X.SchemaHub.Model.Dtos;
using Andy.X.SchemaHub.Model.Entities.Schemas;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Andy.X.SchemaHub.Core.Abstractions.Services
{
    public interface ISchemaService
    {
        bool CreateSchema(string tenant, string schemaName);

        // delete everything related to schema with schemaId
        bool DeleteSchema(string tenant, string schemaName);

        Schema? GetSchema(string tenant, string schemaName);
        List<Schema> GetSchemas(string tenant);


        bool AddSchemaDefinition(SchemaDefinitionRequest schemaDefinitionDto, out string error);
        bool UpdateSchemaDefinition(SchemaDefinitionRequest schemaDefinitionDto, out string error);
        SchemaDefinitionResponse GetSchemaDefinition(string tenant, string schemaName, string version, SchemaFileType schema);
        List<SchemaDefinitionResponse> GetSchemaDefinitions(string tenant, string schemaName);



        bool DeploySchema(string tenant, string schemaName, string version, string topic, out string error);
        bool ValidateSchemaDefinition(string tenant, string schemaName, string version);


    }
}
