using NovaCode_Web_Services.Publications.Domain.Model.Aggregate;
using NovaCode_Web_Services.Publications.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Publications.Interfaces.REST.Transform;

public class PublicationResourceFromEntityAssembler
{
    public static PublicationResource ToResourceFromEntity(Publication entity)
    {
        return new PublicationResource(entity.Id, entity.Model, entity.Brand, entity.Year, entity.Description, entity.Image, entity.Price, entity.PublishedDate);
    }
}