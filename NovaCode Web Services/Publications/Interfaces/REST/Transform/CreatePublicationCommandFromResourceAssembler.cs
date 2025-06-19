using NovaCode_Web_Services.Publications.Domain.Model.Commands;
using NovaCode_Web_Services.Publications.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Publications.Interfaces.REST.Transform
{
public static class CreatePublicationCommandFromResourceAssembler
{
    public static CreatePublicationCommand ToCommandFromResource(CreatePublicationResource resource)
    {
        return new CreatePublicationCommand(resource.Model, resource.Brand, resource.Year, resource.Description, 
            resource.Image, resource.Price, resource.PublishedDate);
    }
}
}