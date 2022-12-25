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

        public void AddSchema(Schema schema)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .Schemas
                    .Add(schema);

                _schemaDbContext.SaveChanges();
            }
        }

        public void AddSchemaDefinition(SchemaDefinition schemaDefinition)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .SchemaDefinitions
                    .Add(schemaDefinition);

                _schemaDbContext.SaveChanges();
            }
        }

        public void AddSchemaSettings(SchemaSettings schemaSettings)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .SchemaSettings
                    .Add(schemaSettings);

                _schemaDbContext.SaveChanges();
            }
        }

        public void AddTag(long tenantId, long schemaId, string tag)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .Tags
                    .Add(new Tag() { Name = tag, SchemaId = schemaId, TenantId = tenantId });

                _schemaDbContext.SaveChanges();
            }
        }

        public void AddTopicSchemaLink(TopicSchemaLink topicSchemaLink)
        {
            lock (topicSchemaLink)
            {
                _schemaDbContext
                    .TopicSchemaLinks
                    .Add(topicSchemaLink);

                _schemaDbContext.SaveChanges();
            }
        }

        public void DeleteSchema(Schema schema)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .Schemas
                    .Remove(schema);

                _schemaDbContext.SaveChanges();
            }
        }

        public void DeleteSchemaDefinition(SchemaDefinition schemaDefinition)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .SchemaDefinitions
                    .Remove(schemaDefinition);

                _schemaDbContext.SaveChanges();
            }
        }

        public void DeleteSchemaSettings(SchemaSettings schemaSettings)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .SchemaSettings
                    .Remove(schemaSettings);

                _schemaDbContext.SaveChanges();
            }
        }

        public void DeleteTag(long tenantId, long schemaId, string tag)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .Tags
                    .Remove(new Tag() { Name = tag, SchemaId = schemaId, TenantId = tenantId });

                _schemaDbContext.SaveChanges();
            }
        }

        public void DeleteTopicSchemaLink(TopicSchemaLink topicSchemaLink)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .TopicSchemaLinks
                    .Remove(topicSchemaLink);

                _schemaDbContext.SaveChanges();
            }
        }

        public void EditSchema(Schema schema)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .Schemas
                    .Update(schema);

                _schemaDbContext.SaveChanges();
            }
        }

        public void EditSchemaDefinition(SchemaDefinition schemaDefinition)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .SchemaDefinitions
                    .Update(schemaDefinition);

                _schemaDbContext.SaveChanges();
            }
        }

        public void EditSchemaSettings(SchemaSettings schemaSettings)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .SchemaSettings
                    .Update(schemaSettings);

                _schemaDbContext.SaveChanges();
            }
        }

        public void EditTopicSchemaLink(TopicSchemaLink topicSchemaLink)
        {
            lock (_schemaDbContext)
            {
                _schemaDbContext
                    .TopicSchemaLinks
                    .Update(topicSchemaLink);

                _schemaDbContext.SaveChanges();
            }
        }

        public Schema GetSchema(long tenantId, string schemaName)
        {
            return _schemaDbContext
                .Schemas
                .Where(x => x.TenantId == tenantId && x.Name == schemaName)
                .FirstOrDefault()!;
        }

        public Schema GetSchema(long schemaId)
        {
            return _schemaDbContext
                .Schemas
                .Find(schemaId)!;
        }

        public SchemaDefinition? GetSchemaDefinition(long schemaId, string version)
        {
            return _schemaDbContext
                .SchemaDefinitions
                .Where(x=> x.SchemaId == schemaId && x.Version == version)
                .FirstOrDefault()!;
        }

        public List<SchemaDefinition> GetSchemaDefinitions(long schemaId)
        {
            return _schemaDbContext
                .SchemaDefinitions
                .Where(x => x.SchemaId == schemaId)
                .ToList();
        }

        public List<Schema> GetSchemas(long tenantId)
        {
            return _schemaDbContext
                .Schemas
                .Where(x => x.TenantId == tenantId)
                .ToList();
        }
    }
}
