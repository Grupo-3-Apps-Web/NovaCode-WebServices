using NovaCode_Web_Services.Profile.Domain.Model.Commands;
using NovaCode_Web_Services.Profile.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Profile.Interfaces.REST.Transform
{
    public static class CreateProfileCommandFromResourceAssembler
    {
        public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource, int userId)
        {
            return new CreateProfileCommand(
                userId,
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
}