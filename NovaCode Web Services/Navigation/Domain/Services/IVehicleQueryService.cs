using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;
using NovaCode_Web_Services.Navigation.Domain.Model.Queries;

namespace NovaCode_Web_Services.Navigation.Domain.Services;

public interface IVehicleQueryService
{
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query);
}