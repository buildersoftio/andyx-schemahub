using Andy.X.SchemaHub.Core.Abstractions.Services;
using Andy.X.SchemaHub.Model;
using Andy.X.SchemaHub.Model.Dtos;
using Andy.X.SchemaHub.Model.Entities.Schemas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Net.Mime;

namespace Andy.X.SchemaHub.App.Controllers
{
    [Route("api/v3/{tenant}/schemas")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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


        [HttpPost("{schema}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "admin")]
        public ActionResult<string> PostSchemas(string tenant, string schema)
        {
            if (_schemaService.CreateSchema(tenant, schema))
                return Ok("Schema is created sucessfully");

            return BadRequest("Something went wrong, Schema isnot created, or it exists");
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Schema>> GetSchemas(string tenant)
        {
            var schemas = _schemaService.GetSchemas(tenant);
            return Ok(schemas);
        }

        [HttpGet("{schema}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize(Roles = "admin,readonly")]
        public ActionResult<List<Schema>> GetSchema(string tenant, string schema)
        {
            var schemas = _schemaService.GetSchema(tenant, schema);
            if (schemas == null)
                return NotFound($"Schema {schema} doesnot exists");

            return Ok(schemas);
        }

        [HttpPost("{schema}/definitions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "admin")]
        public ActionResult<string> PostSchemas(string tenant, string schema, [FromBody] SchemaDefinitionRequest schemaDefinitionDto)
        {

            schemaDefinitionDto.Tenant = tenant;
            schemaDefinitionDto.Schema = schema;

            if (_schemaService.AddSchemaDefinition(schemaDefinitionDto, out string error))
                return Ok("Schema definition is created sucessfully");

            return BadRequest($"Something went wrong, Schema definition isn't created. {error}");
        }

        [HttpPut("{schema}/definitions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "admin")]
        public ActionResult<string> PutSchemas(string tenant, string schema, [FromBody] SchemaDefinitionRequest schemaDefinitionDto)
        {
            schemaDefinitionDto.Tenant = tenant;
            schemaDefinitionDto.Schema = schema;

            if (_schemaService.UpdateSchemaDefinition(schemaDefinitionDto, out string error))
                return Ok("Schema definition is updated sucessfully");

            return BadRequest($"Something went wrong, Schema definition isn't updated. {error}");
        }

        [HttpGet("{schema}/definitions/{version}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize(Roles = "admin,readonly")]
        public ActionResult<SchemaDefinitionResponse> GetDefinition(string tenant, string schema, string version, [FromQuery] SchemaFileType schemaFileType)
        {
            var definition = _schemaService.GetSchemaDefinition(tenant, schema, version, schemaFileType);

            if (definition == null)
                return NotFound($"Definition in version {version} for schema {schema} doesnot exist.");

            return Ok(definition);
        }

        [HttpGet("{schema}/definitions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize(Roles = "admin,readonly")]
        public ActionResult<List<SchemaDefinitionResponse>> GetDefinitions(string tenant, string schema)
        {
            var definition = _schemaService.GetSchemaDefinitions(tenant, schema);

            if (definition == null)
                return NotFound($"There are no definition");

            return Ok(definition);
        }


        [HttpDelete("{schema}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "admin")]
        public ActionResult<string> DeleteSchema(string tenant, string schema)
        {
            if (_schemaService.DeleteSchema(tenant, schema) != true)
                return NotFound($"Something went wrong! Schema {schema} couldnot be deleted.");

            return Ok($"Schema {schema} is deleted succesfully.");
        }

        [HttpPost("{schema}/definitions/{version}/deploy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "admin")]
        public ActionResult<string> DeploySchemaDefinition(string tenant, string schema, string version, [FromBody] DeploySchemaDefinitionRequest deploySchemaDefinitionRequest)
        {

            if (_schemaService.DeploySchema(tenant, schema, version, deploySchemaDefinitionRequest.Topic, out string error))
                return Ok($"Schema with version {version} has been deployed at {deploySchemaDefinitionRequest.Topic} sucessfully.");


            return BadRequest($"Something went wrong, Schema definition isn't deployed. {error}");
        }
    }
}
