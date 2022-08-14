using Andy.X.SchemaHub.Core.Abstractions.Repositories;
using Andy.X.SchemaHub.Core.Contexts;
using Microsoft.Extensions.Logging;

namespace Andy.X.SchemaHub.Core.Repositories
{
    public class SchemaRepository : ISchemaRepository
    {
        private readonly ILogger<SchemaRepository> _logger;
        private readonly SchemaDbContext _schemaDbContext;
        public SchemaRepository(ILogger<SchemaRepository> logger)
        {
            _logger = logger;

            _schemaDbContext = new SchemaDbContext();
            _schemaDbContext.Database.EnsureCreated();
        }
    }
}
