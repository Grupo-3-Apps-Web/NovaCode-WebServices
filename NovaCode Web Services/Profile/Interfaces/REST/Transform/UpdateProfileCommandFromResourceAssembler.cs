using NovaCode_Web_Services.Profile.Domain.Model.Commands;
using NovaCode_Web_Services.Profile.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Profile.Interfaces.REST.Transform;

public class UpdateProfileCommandFromResourceAssembler
{
    public static UpdateProfileCommand ToCommandFromResource(UpdateProfileResource resource)
    {
        return new UpdateProfileCommand(
            resource.FullName,
            resource.Email,
            resource.Phone,
            resource.Address,
            resource.Birthday,
            resource.Dni,
            resource.ImageProfile
        );
    }
}