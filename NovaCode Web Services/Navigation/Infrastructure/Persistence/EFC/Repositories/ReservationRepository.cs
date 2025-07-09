using Microsoft.EntityFrameworkCore;
using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaCode_Web_Services.Navigation.Infrastructure.Persistence.EFC.Repositories;

public class ReservationRepository(AppDbContext context) :
    BaseRepository<Reservation>(context), IReservationRepository
{
    public async Task AddAsync(Reservation reservation)
    {
        await Context.Set<Reservation>().AddAsync(reservation);
    }
    
    public new async Task<Reservation?> FindByIdAsync(int id)
    {
        return await Context.Set<Reservation>().FirstOrDefaultAsync(reservation => reservation.Id == id);
    }
    
    public new async Task<IEnumerable<Reservation>> ListAsync()
    {
        return await Context.Set<Reservation>()
            .ToListAsync();
    }
}