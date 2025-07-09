using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NovaCode_Web_Services.Navigation.Application.Internal.CommandServices;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Navigation.Domain.Services;
using NovaCode_Web_Services.Navigation.Infrastructure.Persistence.EFC.Repositories;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available operations for managing reservations in the NovaCode Platform.")]
public class ReservationsController(IReservationCommandService reservationCommandService, IReservationRepository reservationRepository) : ControllerBase
{
    [HttpGet("{reservationId:int}")]
    [SwaggerOperation(
        Summary = "Get reservation by Id",
        Description = "Retrieves a reservation available in the NovaCode Platform.",
        OperationId = "GetReservationById")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a reservation", typeof(ReservationResource))]
    public async Task<IActionResult> GetReservationById(int reservationId)
    {
        var reservation = await reservationRepository.FindByIdAsync(reservationId);
        if (reservation is null)
        {
            return NotFound();
        }
        var reservationResource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
        return Ok(reservationResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new reservation",
        Description = "Create a new reservation",
        OperationId = "CreateReservation")
    ]
    [SwaggerResponse(StatusCodes.Status201Created, "The reservation was created", typeof(ReservationResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The reservation could not be created")]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationResource resource)
    {
        var createReservationCommand = CreateReservationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var reservation = await reservationCommandService.Handle(createReservationCommand);
        if (reservation is null) return BadRequest();
        var reservationResource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
        return CreatedAtAction(nameof(GetReservationById), new { reservationId = reservationResource.Id }, reservationResource);
    }
}