using Microsoft.EntityFrameworkCore;
using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaCode_Web_Services.Navigation.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context) :
    BaseRepository<Vehicle>(context), IVehicleRepository
{
    public new async Task<Vehicle?> FindByIdAsync(int id)
    {
        return await Context.Set<Vehicle>().FirstOrDefaultAsync(vehicle => vehicle.Id == id);
    }
    
    public new async Task<IEnumerable<Vehicle>> ListAsync()
    {
        return await Context.Set<Vehicle>()
            .ToListAsync();
    }
}