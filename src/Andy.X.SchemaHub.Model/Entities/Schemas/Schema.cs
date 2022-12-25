using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Andy.X.SchemaHub.Model.Entities.Schemas
{
    public class Schema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonIgnore]
        public long TenantId { get; set; }

        // will not be implemented in the first version
        [JsonIgnore]
        public long? DomainId { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }  // it should me unique for version

        // Current Version represents the production version of the schema, which clients are connected
        public long? CurrentSchemaDefinitionId { get; set; }

        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
