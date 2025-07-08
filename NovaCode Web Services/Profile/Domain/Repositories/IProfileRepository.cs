using NovaCode_Web_Services.Profile.Domain.Model.Aggregate;
using NovaCode_Web_Services.Shared.Domain.Repositories;

namespace NovaCode_Web_Services.Profile.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Model.Aggregate.Profile>
{
}