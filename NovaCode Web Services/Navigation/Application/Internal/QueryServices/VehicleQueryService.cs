using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;
using NovaCode_Web_Services.Navigation.Domain.Model.Queries;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Navigation.Domain.Services;
using NovaCode_Web_Services.Publications.Domain.Model.Queries;

namespace NovaCode_Web_Services.Navigation.Application.Internal.QueryServices;

public class VehicleQueryService(IVehicleRepository vehicleRepository) : IVehicleQueryService
{
    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query)
    {
        return await vehicleRepository.ListAsync();
    }
}