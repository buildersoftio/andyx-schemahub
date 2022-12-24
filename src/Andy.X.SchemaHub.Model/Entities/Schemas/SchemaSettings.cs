using System.ComponentModel.DataAnnotations;

namespace Andy.X.SchemaHub.Model.Entities.Schemas
{
    public class SchemaSettings
    {
        [Key]
        public long SchemaId { get; set; }

        // in case that version is forced
        // the first production version will be v1.0.0,
        // for each new minor update will be v1.0.1,
        // user will not be able to add a specific version.
        public bool IsVersionForced { get; set; }

        public bool IsBackwardCompatibility { get; set; }
        public bool IsForwardCompatibility { get; set; }

        public int NumberOfVersionsSupportedForCompatibility { get; set; }

        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
