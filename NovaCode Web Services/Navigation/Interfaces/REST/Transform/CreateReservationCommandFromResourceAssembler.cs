using NovaCode_Web_Services.Navigation.Domain.Model.Commands;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;

public static class CreateReservationCommandFromResourceAssembler
{
    public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource)
    {
        return new CreateReservationCommand(resource.VehicleId, resource.UserId);
    }
}