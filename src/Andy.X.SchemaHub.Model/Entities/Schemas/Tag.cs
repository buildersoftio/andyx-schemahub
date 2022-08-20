namespace Andy.X.SchemaHub.Model.Entities.Schemas
{
    public class Tag
    {
        public long TenantId { get; set; }
        public long SchemaId { get; set; }
        public string? Name { get; set; }
    }
}
