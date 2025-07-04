using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NovaCode_Web_Services.Navigation.Domain.Model.Queries;
using NovaCode_Web_Services.Navigation.Domain.Services;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available operations for managing reviews in the NovaCode Platform.")]
public class ReviewsController
(IReviewCommandService reviewCommandService, IReviewQueryService reviewQueryService) : ControllerBase
{
    [HttpGet("{reviewId:int}")]
    [SwaggerOperation(
        Summary = "Get review by Id",
        Description = "Retrieves a review available in the NovaCode Platform.",
        OperationId = "GetReviewById")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a review", typeof(ReviewResource))]
    public async Task<IActionResult> GetReviewById(int reviewId)
    {
        var getReviewByIdQuery = new GetReviewByIdQuery(reviewId);
        var review = await reviewQueryService.Handle(getReviewByIdQuery);
        if (review is null)
        {
            return NotFound();
        }
        var tutorialResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(tutorialResource);
    }
    
    [HttpPut("{reviewId:int}")]
    [SwaggerOperation(
        Summary = "Update a review",
        Description = "Update a review",
        OperationId = "UpdateReview")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was updated", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The review could not be updated")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review was not found")]
    public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] UpdateReviewResource resource)
    {
        if(reviewId != resource.Id)
        {
            return BadRequest();
        }
        var updateReviewCommand = UpdateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await reviewCommandService.Handle(updateReviewCommand);
        if (review is null)
        {
            return NotFound();
        }
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new review",
        Description = "Create a new review",
        OperationId = "CreateReview")
    ]
    [SwaggerResponse(StatusCodes.Status201Created, "The review was created", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The review could not be created")]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var createdReviewCommand = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await reviewCommandService.Handle(createdReviewCommand);
        if (review is null) return BadRequest();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetReviewById), new { reviewId = reviewResource.Id }, reviewResource);
    }
}