using NovaCode_Web_Services.Profile.Domain.Model.Aggregate;
using NovaCode_Web_Services.Profile.Domain.Model.Queries;

namespace NovaCode_Web_Services.Profile.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Model.Aggregate.Profile>> Handle(GetAllProfilesQuery query);
    
    Task<Model.Aggregate.Profile?> Handle(GetProfileByIdQuery query);
}