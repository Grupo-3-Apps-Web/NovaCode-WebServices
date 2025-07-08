using NovaCode_Web_Services.Publications.Domain.Model.Commands;
using NovaCode_Web_Services.Publications.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Publications.Interfaces.REST.Transform;

public class UpdatePublicationCommandFromResourceAssembler
{
    public static UpdatePublicationCommand ToCommandFromResource(UpdatePublicationResource resource)
    {
        return new UpdatePublicationCommand(
            resource.Model, 
            resource.Brand, 
            resource.Year, 
            resource.Description, 
            resource.Image, 
            resource.Price, 
            resource.PublishedDate);
    }
}