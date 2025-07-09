using NovaCode_Web_Services.Navigation.Domain.Model.Entities;

namespace NovaCode_Web_Services.Navigation.Domain.Repositories;

public interface IReservationRepository
{
    Task AddAsync(Reservation reservation);
    Task<IEnumerable<Reservation>> ListAsync();
    Task<Reservation?> FindByIdAsync(int id);
}