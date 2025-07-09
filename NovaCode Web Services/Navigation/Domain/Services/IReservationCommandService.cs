using NovaCode_Web_Services.Navigation.Domain.Model.Commands;
using NovaCode_Web_Services.Navigation.Domain.Model.Entities;

namespace NovaCode_Web_Services.Navigation.Domain.Services;

public interface IReservationCommandService
{
    Task<Reservation?> Handle(CreateReservationCommand command);
}