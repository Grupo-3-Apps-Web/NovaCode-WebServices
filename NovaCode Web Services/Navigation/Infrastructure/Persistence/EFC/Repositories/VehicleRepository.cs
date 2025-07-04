using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaCode_Web_Services.Navigation.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context) :
    BaseRepository<Vehicle>(context), IVehicleRepository
{
    
}