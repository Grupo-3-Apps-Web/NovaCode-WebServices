using NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;
using NovaCode_Web_Services.Dashboard.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Dashboard.Interfaces.REST.Transform;

public class BookResourceFromEntityAssembler
{
    public static BookResource ToResourceFromEntity(Book entity)
    {
        return new BookResource(
            entity.Id,
            entity.Model,
            entity.Brand,
            entity.Year,
            entity.Description,
            entity.Image,
            entity.Price,
            entity.PublishedDate);
    }
}