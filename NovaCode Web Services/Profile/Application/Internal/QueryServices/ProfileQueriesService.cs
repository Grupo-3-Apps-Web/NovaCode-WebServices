using NovaCode_Web_Services.Profile.Domain.Model.Aggregate;
using NovaCode_Web_Services.Profile.Domain.Model.Queries;
using NovaCode_Web_Services.Profile.Domain.Repositories;
using NovaCode_Web_Services.Profile.Domain.Services;

namespace NovaCode_Web_Services.Profile.Application.Internal.QueryServices;

public class ProfileQueriesService(IProfileRepository profileRepository) : IProfileQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregate.Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Domain.Model.Aggregate.Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.UserId);
    }
}