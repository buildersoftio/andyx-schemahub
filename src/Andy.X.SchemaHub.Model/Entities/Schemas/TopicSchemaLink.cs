using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Andy.X.SchemaHub.Model.Entities.Schemas
{
    public class TopicSchemaLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TenantId { get; set; }


        // Topic example is be 'tenant/product/component/topic'
        public string Topic { get; set; }
        public long SchemaId { get; set; }
        public long SchemaDefinitionId { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
