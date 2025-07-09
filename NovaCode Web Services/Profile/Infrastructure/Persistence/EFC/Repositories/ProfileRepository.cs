using NovaCode_Web_Services.Profile.Domain.Model.Aggregate;
using NovaCode_Web_Services.Profile.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaCode_Web_Services.Profile.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<ProfileAggregate>(context), IProfileRepository
{
    
}