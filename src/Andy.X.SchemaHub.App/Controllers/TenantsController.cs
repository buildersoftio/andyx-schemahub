using Andy.X.SchemaHub.Core.Abstractions.Services;
using Andy.X.SchemaHub.Model.Entities.Tenants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Mime;

namespace Andy.X.SchemaHub.App.Controllers
{
    [Route("api/v1/tenants")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ILogger<TenantsController> _logger;
        private readonly ITenantService _tenantService;

        public TenantsController(ILogger<TenantsController> logger, ITenantService tenantService)
        {
            _logger = logger;
            _tenantService = tenantService;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<string>> GetTenants()
        {
            var tenants = _tenantService.GetTenants();
            if (tenants != null)
                return Ok(tenants);

            return NotFound("There are not tenants registered");
        }

        [HttpGet("{tenant}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Tenant> GetTenant(string tenant)
        {
            var tenants = _tenantService.GetTenant(tenant);
            if (tenants != null)
                return Ok(tenants);

            return NotFound($"Tenant {tenant} doesnot exists.");
        }

        [HttpPost("{tenant}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> PostTenant(string tenant)
        {
            var result = _tenantService.CreateTenant(tenant);
            if (result != true)
                return BadRequest("Something went wrong, tenant is not created.");

            return Ok($"Tenant {tenant} is created sucessfully.");
        }


        [HttpPut("tenant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> PutTenant(string tenant, [FromBody] TenantStatus tenantStatus)
        {
            var result = _tenantService.ChangeTenantStatus(tenant, tenantStatus);
            if (result != true)
                return BadRequest("Something went wrong, tenant status is not changed.");

            return Ok($"Tenant status for {tenant} is changed sucessfully.");
        }
    }
}
