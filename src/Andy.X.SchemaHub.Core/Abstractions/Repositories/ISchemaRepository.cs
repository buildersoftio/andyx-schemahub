using Andy.X.SchemaHub.Model.Entities.Schemas;
using Andy.X.SchemaHub.Model.Entities.Tenants;

namespace Andy.X.SchemaHub.Core.Abstractions.Repositories
{
    public interface ISchemaRepository
    {
        void AddSchema(Schema schema);
        void ChangeSchemaStatus(long schemaId, SchemaStatus schema);
        void UpdateVersionSchema(long schemaId, string version);

        void AddSchemaDefinition(SchemaDefinition schemaDefinition);

        void AddDraftSchemaDefinition(DraftSchemaDefinition schemaDefinition);
        void UpdateDraftSchemaDefinition(DraftSchemaDefinition schemaDefinition);

        void AddSettings(SchemaSettings schemaSettings);
        void UpdateSettings(SchemaSettings schemaSettings);



        void AddTag(long tenantId, long schemaId, string tag);
    }
}
