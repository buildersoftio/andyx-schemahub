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
        public long DomainId { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }  // it should me unique for domain
        public string Version { get; set; }
        public string SchemaPayload { get; set; }

        public List<string> SchemaFileLocations { get; set; }

        public SchemaStatus Status { get; set; }
    }
}
