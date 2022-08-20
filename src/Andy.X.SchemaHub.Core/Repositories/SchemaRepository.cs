using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Contexts;
using Andy.X.SchemaHub.Model.Entities.Schemas;
using Microsoft.Extensions.Logging;

namespace Andy.X.SchemaHub.Core.Repositories
{
    public class SchemaRepository : ISchemaRepository
    {
        private readonly ILogger<SchemaRepository> _logger;
        private readonly SchemaDbContext _schemaDbContext;
        public SchemaRepository(ILogger<SchemaRepository> logger)
        {
            _logger = logger;

            _schemaDbContext = new SchemaDbContext();
            _schemaDbContext.Database.EnsureCreated();
        }

        public void AddDraftSchemaDefinition(DraftSchemaDefinition schemaDefinition)
        {
            throw new NotImplementedException();
        }

        public void AddSchema(Schema schema)
        {
            throw new NotImplementedException();
        }

        public void AddSchemaDefinition(SchemaDefinition schemaDefinition)
        {
            throw new NotImplementedException();
        }

        public void AddSettings(SchemaSettings schemaSettings)
        {
            throw new NotImplementedException();
        }

        public void AddTag(long tenantId, long schemaId, string tag)
        {
            throw new NotImplementedException();
        }

        public void ChangeSchemaStatus(long schemaId, SchemaStatus schema)
        {
            throw new NotImplementedException();
        }

        public void UpdateDraftSchemaDefinition(DraftSchemaDefinition schemaDefinition)
        {
            throw new NotImplementedException();
        }

        public void UpdateSettings(SchemaSettings schemaSettings)
        {
            throw new NotImplementedException();
        }

        public void UpdateVersionSchema(long schemaId, string version)
        {
            throw new NotImplementedException();
        }
    }
}
