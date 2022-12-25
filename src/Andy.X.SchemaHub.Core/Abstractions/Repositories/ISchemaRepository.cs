using Andy.X.SchemaHub.Model.Entities.Schemas;

namespace Andy.X.SchemaHub.Core.Abstractions.Repositories
{
    public interface ISchemaRepository
    {
        void AddSchema(Schema schema);
        void EditSchema(Schema schema);
        void DeleteSchema(Schema schema);

        Schema GetSchema(long tenantId, string schemaName);
        Schema GetSchema(long schemaId);
        List<Schema> GetSchemas(long tenantId);

        void AddSchemaDefinition(SchemaDefinition schemaDefinition);
        void EditSchemaDefinition(SchemaDefinition schemaDefinition);
        void DeleteSchemaDefinition(SchemaDefinition schemaDefinition);

        SchemaDefinition? GetSchemaDefinition(long schemaId, string version);
        List<SchemaDefinition> GetSchemaDefinitions(long schemaId);

        void AddSchemaSettings(SchemaSettings schemaSettings);
        void EditSchemaSettings(SchemaSettings schemaSettings);
        void DeleteSchemaSettings(SchemaSettings schemaSettings);


        void AddTopicSchemaLink(TopicSchemaLink topicSchemaLink);
        void EditTopicSchemaLink(TopicSchemaLink topicSchemaLink);
        void DeleteTopicSchemaLink(TopicSchemaLink topicSchemaLink);

        void AddTag(long tenantId, long schemaId, string tag);
        void DeleteTag(long tenantId, long schemaId, string tag);
    }
}
