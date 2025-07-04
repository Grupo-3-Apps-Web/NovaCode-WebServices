using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NovaCode_Web_Services.Navigation.Domain.Model.Queries;
using NovaCode_Web_Services.Navigation.Domain.Services;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST;

[ApiController]
[Route("api/v1/vehicles/{vehicleId:int}/reviews")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available operations for managing vehicles-reviews.")]
public class VehicleReviewsController(IReviewQueryService reviewQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all reviews by vehicle id",
        Description = "Get all reviews by vehicle id",
        OperationId = "GetAllReviewsByVehicleId")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns list of reviews", typeof(IEnumerable<ReviewResource>))]
    public async Task<IActionResult> GetReviewsByVehicleId(int vehicleId)
    {
        var getReviewsByVehicleIdQuery = new GetAllReviewsByVehicleIdQuery(vehicleId);
        var reviews = await reviewQueryService.Handle(getReviewsByVehicleIdQuery);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }
}