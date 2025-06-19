using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NovaCode_Web_Services.Publications.Domain.Model.Commands;
using NovaCode_Web_Services.Publications.Domain.Model.Queries;
using NovaCode_Web_Services.Publications.Domain.Services;
using NovaCode_Web_Services.Publications.Interfaces.REST.Resources;
using NovaCode_Web_Services.Publications.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaCode_Web_Services.Publications.Interfaces.REST;


[ApiController]
[Route("api/v1/myPublishedVehicles")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Published Vehicles Endpoints.")]

public class PublicationsController(IPublicationCommandService publicationCommandService, IPublicationQueryService publicationQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get All Publications", "Get a list of all publications.", OperationId = "GetAllPublications")]
    [SwaggerResponse(200, "The list of Publications was found and returned.", typeof(IEnumerable<PublicationResource>))]
    
    public async Task<IActionResult> GetAllPublications()
    {
        var getAllPublicationsQuery = new GetAllPublicationsQuery();
        var publications = await publicationQueryService.Handle(getAllPublicationsQuery);

        if (publications == null || !publications.Any())
        {
            return NotFound("No publications found.");
        }

        var publicationResources = publications.Select(PublicationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(publicationResources);
    }
    
    [HttpGet("{myPublishedVehiclesId:int}")]
    [SwaggerOperation("Get Publication by Id", "Get a publication by its unique identifier.", OperationId = "GetPublicationById")]
    [SwaggerResponse(200, "The Publication was found and returned.", typeof(PublicationResource))]
    [SwaggerResponse(404, "The Publication was not found.")]
    
    public async Task<IActionResult> GetPublicationById(int myPublishedVehiclesId)
    {
        var getPublicationByIdQuery = new GetPublicationByIdQuery(myPublishedVehiclesId);
        var publication = await publicationQueryService.Handle(getPublicationByIdQuery);

        if (publication == null)
        {
            return NotFound($"Publication with ID {myPublishedVehiclesId} not found.");
        }

        var publicationResource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(publication);
        return Ok(publicationResource);
    }
    
    [HttpPost]
    [SwaggerOperation("Create new Publication", "Create a new Publication.", OperationId = "CreatePublication")]
    [SwaggerResponse(201, "The Publication was created successfully.", typeof(PublicationResource))]
    [SwaggerResponse(400, "The Publication was not created.")]
    
    public async Task<IActionResult> CreatePublication([FromBody] CreatePublicationCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid publication data.");
        }

        var createdPublication = await publicationCommandService.Handle(command);

        if (createdPublication == null)
        {
            return BadRequest("Failed to create publication.");
        }

        var publicationResource = PublicationResourceFromEntityAssembler.ToResourceFromEntity(createdPublication);
        return CreatedAtAction(nameof(GetPublicationById), new { myPublishedVehiclesId = createdPublication.Id }, publicationResource);
    }
    
    [HttpDelete("{id:int}")]
    [SwaggerOperation("Delete Publication Information", "Delete Publication Information", OperationId = "DeletePublication")]
    
    public async Task<IActionResult> DeletePublication(int id)
    {
        try
        {
            var deletePublicationCommand = new DeletePublicationCommand(id);
            var publicationDeleted = await publicationCommandService.Handle(deletePublicationCommand);
            
            if (publicationDeleted is null)
                return NotFound($"Publication with id {id} not found.");

            return Ok("Publication deleted successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}