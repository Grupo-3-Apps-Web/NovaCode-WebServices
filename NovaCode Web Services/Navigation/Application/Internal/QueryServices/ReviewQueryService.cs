using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;
using NovaCode_Web_Services.Navigation.Domain.Model.Queries;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Navigation.Domain.Services;

namespace NovaCode_Web_Services.Navigation.Application.Internal.QueryServices;

public class ReviewQueryService(IReviewRepository reviewRepository) : IReviewQueryService
{

    public async Task<Review?> Handle(GetReviewByIdQuery query)
    {
        return await reviewRepository.FindByIdAsync(query.ReviewId);
    }
    
    public async Task<IEnumerable<Review>> Handle(GetAllReviewsByVehicleIdQuery query)
    {
        return await reviewRepository.FindByVehicleIdAsync(query.VehicleId);
    }
}