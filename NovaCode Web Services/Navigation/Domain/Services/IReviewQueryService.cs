using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;
using NovaCode_Web_Services.Navigation.Domain.Model.Queries;

namespace NovaCode_Web_Services.Navigation.Domain.Services;

public interface IReviewQueryService
{
    Task<Review?> Handle(GetReviewByIdQuery query);
    Task<IEnumerable<Review>> Handle(GetAllReviewsByVehicleIdQuery query);
}