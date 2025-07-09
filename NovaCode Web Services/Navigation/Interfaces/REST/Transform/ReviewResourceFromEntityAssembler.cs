using NovaCode_Web_Services.IAM.Interfaces.REST.Transform;
using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;

public static class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(Review entity)
    {
        return new ReviewResource(
            entity.Id,
            entity.Score,
            entity.Comment,
            VehicleResourceFromEntityAssembler.ToResourceFromEntity(entity.Vehicle),
            UserResourceFromEntityAssembler.ToResourceFromEntity(entity.User));
    }
}