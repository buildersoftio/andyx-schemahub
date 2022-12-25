using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Andy.X.SchemaHub.Model.Entities.Schemas
{
    public class SchemaDefinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long SchemaId { get; set; }

        public string Version { get; set; }
        public string SchemaPayload { get; set; }

        // map schemaFileLocations from a List<string> use (,) comma as delimiter.
        public string SchemaFileLocations { get; set; }

        public SchemaStatus Status { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
