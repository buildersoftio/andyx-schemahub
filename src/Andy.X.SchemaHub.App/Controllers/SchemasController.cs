using Microsoft.AspNetCore.Mvc;

namespace Andy.X.SchemaHub.App.Controllers
{
    [Route("api/v1/{tenant}/schemas")]
    [ApiController]
    public class SchemasController : ControllerBase
    {
        public SchemasController()
        {

        }
    }
}
