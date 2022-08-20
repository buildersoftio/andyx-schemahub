using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Andy.X.SchemaHub.Model.Entities.Schemas
{
    public class Schema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long TenantId { get; set; }

        // Will not be implemented in the first version
        public long? DomainId { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }  // it should me unique for version

        // Current Version represents the production version of the schema, which clients are connected
        public string CurrentVersion { get; set; }

        public SchemaStatus Status { get; set; }
    }
}
