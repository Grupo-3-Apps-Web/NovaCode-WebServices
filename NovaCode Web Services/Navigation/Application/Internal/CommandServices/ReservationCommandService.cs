using Cortex.Mediator;
using NovaCode_Web_Services.Navigation.Domain.Model.Commands;
using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Navigation.Domain.Services;
using NovaCode_Web_Services.Shared.Domain.Model.Events;
using NovaCode_Web_Services.Shared.Domain.Repositories;

namespace NovaCode_Web_Services.Navigation.Application.Internal.CommandServices;

public class ReservationCommandService(IReservationRepository reservationRepository, IVehicleRepository vehicleRepository,
    IMediator mediator, IUnitOfWork unitOfWork) : IReservationCommandService
{
    public async Task<Reservation?> Handle(CreateReservationCommand command)
    {
        var vehicle = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicle == null) throw new Exception("Vehicle not found");
        var reservation = new Reservation
        {
            VehicleId = command.VehicleId,
            UserId = command.UserId,
            ReservedAt = DateTime.UtcNow
        };
        await reservationRepository.AddAsync(reservation);
        
        await mediator.PublishAsync(new VehicleReservedEvent(
            reservation.VehicleId, reservation.UserId, reservation.ReservedAt, vehicle.Model,
            vehicle.Brand, vehicle.Year, vehicle.Description, vehicle.Image, vehicle.Price, vehicle.PublishedDate));
        
        return reservation;
    }
}