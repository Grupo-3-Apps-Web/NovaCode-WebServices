using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Shared.Domain.Repositories;

namespace NovaCode_Web_Services.Navigation.Domain.Repositories;

public interface IReviewRepository : IBaseRepository<Review>
{
    Task<IEnumerable<Review>> FindByVehicleIdAsync(int vehicleId);
}