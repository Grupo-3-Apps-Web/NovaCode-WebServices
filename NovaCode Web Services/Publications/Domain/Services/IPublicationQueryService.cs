using NovaCode_Web_Services.Publications.Domain.Model.Aggregate;
using NovaCode_Web_Services.Publications.Domain.Model.Queries;

namespace NovaCode_Web_Services.Publications.Domain.Services;

public interface IPublicationQueryService
{
    Task<IEnumerable<Publication>> Handle(GetAllPublicationsQuery query);
    
    Task<Publication?> Handle(GetPublicationByIdQuery query);
}