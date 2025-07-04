using Microsoft.EntityFrameworkCore;
using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaCode_Web_Services.Navigation.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context) :
    BaseRepository<Review>(context), IReviewRepository
{
    public new async Task<Review?> FindByIdAsync(int id)
    {
        return await Context.Set<Review>()
            .Include(review => review.Vehicle)
            .FirstOrDefaultAsync(review => review.Id == id);
    }
    public async Task<IEnumerable<Review>> FindByVehicleIdAsync(int vehicleId)
    {
        return await Context.Set<Review>()
            .Include(review => review.Vehicle)
            .Where(review => review.VehicleId == vehicleId)
            .ToListAsync();
    }
}