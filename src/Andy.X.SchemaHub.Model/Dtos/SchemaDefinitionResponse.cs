namespace Andy.X.SchemaHub.Model.Dtos
{
    public class SchemaDefinitionResponse
    {
        public string? Tenant { get; set; }
        public string? Schema { get; set; }

        public string Version { get; set; }

        public long DefinitionId { get; set; }

        public string? SchemaPayload { get; set; }
    }
}
