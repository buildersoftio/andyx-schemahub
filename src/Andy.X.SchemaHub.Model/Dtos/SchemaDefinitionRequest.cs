using System.Text.Json.Serialization;

namespace Andy.X.SchemaHub.Model.Dtos
{
    public class SchemaDefinitionRequest
    {
        [JsonIgnore]
        public string? Tenant { get; set; }

        [JsonIgnore]
        public string? Schema { get; set; }

        public string Version { get; set; }

        public string? SchemaPayload { get; set; }

        public SchemaDefinitionRequest()
        {
            Version = "1.0.0";
        }
    }
}
