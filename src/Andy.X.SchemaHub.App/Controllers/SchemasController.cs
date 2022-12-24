using Andy.X.SchemaHub.Core.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Andy.X.SchemaHub.App.Controllers
{
    [Route("api/v1/{tenant}/schemas")]
    [ApiController]
    public class SchemasController : ControllerBase
    {
        private readonly ILogger<SchemasController> _logger;
        private readonly ISchemaService _schemaService;

        public SchemasController(ILogger<SchemasController> logger, ISchemaService schemaService)
        {
            _logger = logger;
            _schemaService = schemaService;
        }


        [HttpGet()]
        public ActionResult<string> GetSchemas()
        {
            return Ok("Hello world!");
        }
    }
}
