using NovaCode_Web_Services.Publications.Domain.Model.Aggregate;
using NovaCode_Web_Services.Publications.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaCode_Web_Services.Publications.Infrastructure.Persistence.EFC.Repositories;

public class PublicationRepository(AppDbContext context) : BaseRepository<Publication>(context), IPublicationRepository
{
    
}