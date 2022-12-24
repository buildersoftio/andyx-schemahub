using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Abstractions.Services;
using Microsoft.Extensions.Logging;

namespace Andy.X.SchemaHub.Core.Services.Schemas
{
    public class SchemaService : ISchemaService
    {
        private readonly ILogger<SchemaService> _logger;
        private readonly ISchemaRepository _schemaRepository;

        public SchemaService(ILogger<SchemaService> logger, ISchemaRepository schemaRepository)
        {
            _logger = logger;
            _schemaRepository = schemaRepository;
        }
    }
}
