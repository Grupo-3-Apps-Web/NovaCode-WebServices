using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;

public static class VehicleResourceFromEntityAssembler
{
    public static VehicleResource ToResourceFromEntity(Vehicle entity)
    {
        return new VehicleResource(entity.Id, entity.Model, entity.Brand, entity.Year, entity.Description, entity.Image,
            entity.Price, entity.Rating);
    }
}