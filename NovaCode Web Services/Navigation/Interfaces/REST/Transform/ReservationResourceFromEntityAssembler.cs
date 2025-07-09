using NovaCode_Web_Services.IAM.Interfaces.REST.Transform;
using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;

public static class ReservationResourceFromEntityAssembler
{
    public static ReservationResource ToResourceFromEntity(Reservation entity)
    {
        return new ReservationResource(
            entity.Id,
            UserResourceFromEntityAssembler.ToResourceFromEntity(entity.User),
            VehicleResourceFromEntityAssembler.ToResourceFromEntity(entity.Vehicle),
            entity.ReservedAt);
    }
}