using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Abstractions.Services;
using Andy.X.SchemaHub.Core.Generators;
using Andy.X.SchemaHub.IO.Services;
using Andy.X.SchemaHub.Model;
using Andy.X.SchemaHub.Model.Dtos;
using Andy.X.SchemaHub.Model.Entities.Schemas;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Andy.X.SchemaHub.Core.Services.Schemas
{
    public class SchemaService : ISchemaService
    {
        private readonly ILogger<SchemaService> _logger;
        private readonly ISchemaRepository _schemaRepository;
        private readonly ITenantRepository _tenantRepository;

        public SchemaService(ILogger<SchemaService> logger, ISchemaRepository schemaRepository, ITenantRepository tenantRepository)
        {
            _logger = logger;
            _schemaRepository = schemaRepository;
            _tenantRepository = tenantRepository;
        }

        public bool CreateSchema(string tenant, string schemaName)
        {
            var tenantDetails = _tenantRepository.GetTenant(tenant);
            if (tenantDetails == null)
                return false;

            var schema = _schemaRepository.GetSchema(tenantDetails.Id, schemaName);
            if (schema != null)
                return false;

            schema = new Schema() { TenantId = tenantDetails.Id, Name = schemaName, CreatedBy = "system", CreatedDate = DateTimeOffset.Now };

            _schemaRepository.AddSchema(schema);

            // TODO: add default settings for schema

            // create schemaFolder
            TenantIOService.TryCreateSchemaDirectory(tenant, schema.Id);

            return true;
        }

        public Schema? GetSchema(string tenant, string schemaName)
        {
            var tenantDetails = _tenantRepository.GetTenant(tenant);
            if (tenantDetails == null)
                return null;

            return _schemaRepository.GetSchema(tenantDetails.Id, schemaName);
        }

        public List<Schema> GetSchemas(string tenant)
        {
            var tenantDetails = _tenantRepository.GetTenant(tenant);
            if (tenantDetails == null)
                return null!;

            return _schemaRepository.GetSchemas(tenantDetails.Id);
        }

        public bool AddSchemaDefinition(SchemaDefinitionRequest schemaDefinitionDto, out string error)
        {
            error = $"Tenant {schemaDefinitionDto.Tenant} doesnot exists.";
            var tenant = _tenantRepository.GetTenant(schemaDefinitionDto.Tenant!);
            if (tenant == null)
                return false;

            error = $"Schema {schemaDefinitionDto.Schema} doesnot exists.";
            var schema = _schemaRepository.GetSchema(tenant.Id, schemaDefinitionDto.Schema!);
            if (schema == null)
                return false;

            var schemaDefinition = _schemaRepository.GetSchemaDefinition(schema.Id, schemaDefinitionDto.Version);
            if (schemaDefinition != null)
            {
                error = $"This version exists, to update the definition please create a new version.";
                return false;
            }


            try
            {
                // validate json schema
                // try to convert to C# code, if it worked schema is valid
                SchemaGenerator.GenerateSchemaFiles(schemaDefinitionDto, tenant, schema);

                schemaDefinition = new SchemaDefinition()
                {
                    SchemaId = schema.Id,
                    SchemaFileLocations = $"{schemaDefinitionDto.Version}-{schema.Name}.json",
                    Version = schemaDefinitionDto.Version,
                    SchemaPayload = "N/A-its-FILE",
                    Status = SchemaStatus.Draft,
                    CreatedBy = "system",
                    CreatedDate = DateTimeOffset.Now
                };
                _schemaRepository.AddSchemaDefinition(schemaDefinition);

                error = "";
                return true;

            }
            catch (Exception)
            {
                error = "The uploaded schema is not a valid JSON Schema, definition is not processed.";
                return false;
            }
        }

        public bool UpdateSchemaDefinition(SchemaDefinitionRequest schemaDefinitionDto, out string error)
        {
            error = $"Tenant {schemaDefinitionDto.Tenant} doesnot exists.";
            var tenant = _tenantRepository.GetTenant(schemaDefinitionDto.Tenant!);
            if (tenant == null)
                return false;

            error = $"Schema {schemaDefinitionDto.Schema} doesnot exists.";
            var schema = _schemaRepository.GetSchema(tenant.Id, schemaDefinitionDto.Schema!);
            if (schema == null)
                return false;

            var schemaDefinition = _schemaRepository.GetSchemaDefinition(schema.Id, schemaDefinitionDto.Version);
            if (schemaDefinition == null)
            {
                error = $"This definition doesnot exits, please add it by using the correct endpoint.";
                return false;
            }

            if (schemaDefinition.Status != SchemaStatus.Draft)
            {
                error = $"This definition is ACTIVE, it cannot be updated. Only DRAFT Definitions can be updated. Please create a new Definition with new version.";
                return false;
            }

            try
            {
                // validate json schema
                // try to convert to C# code, if it worked schema is valid
                SchemaGenerator.GenerateSchemaFiles(schemaDefinitionDto, tenant, schema);

                schemaDefinition.UpdatedDate = DateTimeOffset.Now;
                schemaDefinition.UpdatedBy = "system";

                _schemaRepository.EditSchemaDefinition(schemaDefinition);

                error = "";
                return true;
            }
            catch (Exception)
            {
                error = "The uploaded schema is not a valid JSON Schema, definition is not processed.";
                return false;
            }

            throw new NotImplementedException();
        }

        public bool DeleteSchema(string tenantName, string schemaName)
        {
            var tenant = _tenantRepository.GetTenant(tenantName);
            if (tenant == null)
                return false;

            var schema = _schemaRepository.GetSchema(tenant.Id, schemaName);
            if (schema == null)
                return false;

            var definitions = _schemaRepository.GetSchemaDefinitions(schema.Id);
            foreach (var definition in definitions)
            {
                _schemaRepository.DeleteSchemaDefinition(definition);
            }

            _schemaRepository.DeleteSchema(schema);
            TenantIOService.TryDeleteSchemaDirectory(tenantName, schema.Id);

            return true;
        }

        public bool DeploySchema(string tenantName, string schemaName, string version, string topic, out string error)
        {
            error = $"Tenant {tenantName} doesnot exists.";
            var tenant = _tenantRepository.GetTenant(tenantName);
            if (tenant == null)
                return false;

            error = $"Schema {schemaName} doesnot exists.";
            var schema = _schemaRepository.GetSchema(tenant.Id, schemaName);
            if (schema == null)
                return false;

            error = $"Definition on version {version} doesnot exists.";
            var definition = _schemaRepository.GetSchemaDefinition(schema.Id, version);
            if (definition == null)
                return false;

            error = $"Only DRAFT definitions can be deployed";
            if (definition.Status != SchemaStatus.Draft)
                return false;


            var topicSchemaLink = new TopicSchemaLink()
            {
                SchemaDefinitionId = definition.Id,
                TenantId = tenant.Id,
                SchemaId = schema.Id,
                Topic = topic,
                CreatedBy = "system",
                CreatedDate = DateTimeOffset.Now
            };

            _schemaRepository.AddTopicSchemaLink(topicSchemaLink);

            definition.Status = SchemaStatus.Active;
            definition.UpdatedDate = DateTimeOffset.Now;
            definition.UpdatedBy = "system";
            _schemaRepository.EditSchemaDefinition(definition);

            schema.CurrentSchemaDefinitionId = definition.Id;
            schema.UpdatedDate = DateTimeOffset.Now;
            _schemaRepository.EditSchema(schema);

            error = "";
            return true;
        }

        public SchemaDefinitionResponse GetSchemaDefinition(string tenant, string schemaName, string version, SchemaFileType schemaType)
        {
            var tenantDetails = _tenantRepository.GetTenant(tenant);
            if (tenantDetails == null)
                return null!;

            var schema = _schemaRepository.GetSchema(tenantDetails.Id, schemaName);
            if (schema == null)
                return null!;

            string fileContent = string.Empty;

            var schemaDefinition = _schemaRepository.GetSchemaDefinition(schema.Id, version);
            if (schemaDefinition == null)
                return null!;


            switch (schemaType)
            {
                case SchemaFileType.JSON:
                    fileContent = SchemaIOService.ReadJsonSchema(tenant, schema.Id, schemaName, version);
                    break;
                case SchemaFileType.YAML:
                    fileContent = SchemaIOService.ReadYamlSchema(tenant, schema.Id, schemaName, version);
                    break;
                case SchemaFileType.CSharp:
                    fileContent = SchemaIOService.ReadCsharpSchema(tenant, schema.Id, schemaName, version);
                    break;
                case SchemaFileType.CsharpTypes:
                    fileContent = SchemaIOService.ReadCsharpTypesSchema(tenant, schema.Id, schemaName, version);
                    break;
                case SchemaFileType.TS:
                    fileContent = SchemaIOService.ReadTsSchema(tenant, schema.Id, schemaName, version);
                    break;
                case SchemaFileType.TSTypes:
                    fileContent = SchemaIOService.ReadTsTypesSchema(tenant, schema.Id, schemaName, version);
                    break;
                default:
                    break;
            }


            return new SchemaDefinitionResponse()
            {
                Tenant = tenant,
                Schema = schemaName,
                Version = version,
                SchemaPayload = fileContent,
                DefinitionId = schemaDefinition.Id
            };
        }

        public List<SchemaDefinitionResponse> GetSchemaDefinitions(string tenant, string schemaName)
        {
            var tenantDetails = _tenantRepository.GetTenant(tenant);
            if (tenantDetails == null)
                return null!;

            var schema = _schemaRepository.GetSchema(tenantDetails.Id, schemaName);
            if (schema == null)
                return null!;

            var results = new List<SchemaDefinitionResponse>();
            _schemaRepository.GetSchemaDefinitions(schema.Id).ForEach(definition =>
            {
                results.Add(new SchemaDefinitionResponse()
                {
                    Tenant = tenant,
                    Schema = schemaName,
                    Version = definition.Version,
                    DefinitionId = definition.Id,
                    SchemaPayload = "REQUEST-specific-Schema"
                });
            });

            return results;
        }

        public bool ValidateSchemaDefinition(string tenant, string schemaName, string version)
        {
            throw new NotImplementedException();
        }
    }
}
