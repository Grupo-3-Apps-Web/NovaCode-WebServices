using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;
using NovaCode_Web_Services.Navigation.Domain.Model.Queries;
using NovaCode_Web_Services.Navigation.Domain.Services;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available operations for managing vehicles in the NovaCode Platform.")]
public class VehiclesController(IVehicleQueryService vehicleQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all Vehicles",
        Description = "Retrieves all vehicles available in the NovaCode Platform.",
        OperationId = "GetReviewById")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all vehicles", typeof(VehicleResource))]
    public async Task<IActionResult> GetAllVehicles()
    {
        var vehicles = await vehicleQueryService.Handle(new GetAllVehiclesQuery());
        var vehiclesResources = vehicles.Select(VehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(vehiclesResources);
    }
}