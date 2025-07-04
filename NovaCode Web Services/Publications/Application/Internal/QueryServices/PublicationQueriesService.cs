using NovaCode_Web_Services.Publications.Domain.Model.Aggregate;
using NovaCode_Web_Services.Publications.Domain.Model.Queries;
using NovaCode_Web_Services.Publications.Domain.Repositories;
using NovaCode_Web_Services.Publications.Domain.Services;

namespace NovaCode_Web_Services.Publications.Application.Internal.QueryServices;

public class PublicationQueriesService(IPublicationRepository publicationRepository): IPublicationQueryService
{
    public async Task<IEnumerable<Publication>> Handle(GetAllPublicationsQuery query)
    {
        return await publicationRepository.ListAsync();
    }

    public async Task<Publication?> Handle(GetPublicationByIdQuery query)
    {
        return await publicationRepository.FindByIdAsync(query.PublicationId);
    }
}