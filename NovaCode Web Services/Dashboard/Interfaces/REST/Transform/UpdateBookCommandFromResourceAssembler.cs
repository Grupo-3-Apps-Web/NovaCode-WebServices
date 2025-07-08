using NovaCode_Web_Services.Dashboard.Domain.Model.Commands;
using NovaCode_Web_Services.Dashboard.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Dashboard.Interfaces.REST.Transform;

public class UpdateBookCommandFromResourceAssembler
{
    public static UpdateBookCommand ToCommandFromResource(UpdateBookResource resource)
    {
        return new UpdateBookCommand(
            resource.Model,
            resource.Brand,
            resource.Year,
            resource.Description,
            resource.Image,
            resource.Price,
            resource.Rating);
    }
}