using NovaCode_Web_Services.Profile.Domain.Model.Aggregate;
using NovaCode_Web_Services.Profile.Domain.Model.Queries;

namespace NovaCode_Web_Services.Profile.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<ProfileAggregate>> Handle(GetAllProfilesQuery query);
    
    Task<ProfileAggregate?> Handle(GetProfileByIdQuery query);
}