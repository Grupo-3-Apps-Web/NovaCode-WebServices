using NovaCode_Web_Services.Profile.Domain.Model.Aggregate;
using NovaCode_Web_Services.Profile.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Profile.Interfaces.REST.Transform;

public class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Domain.Model.Aggregate.Profile entity)
    {
        return new ProfileResource(
            entity.Id,
            entity.FullName,
            entity.Email,
            entity.Phone,
            entity.Address,
            entity.Birthday,
            entity.Dni,
            entity.ImageProfile
        );
    }
}