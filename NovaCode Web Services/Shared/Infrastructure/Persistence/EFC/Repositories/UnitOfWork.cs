using NovaCode_Web_Services.Shared.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Set<TEntity>().Update(entity);
        await CompleteAsync();
    }

    public async Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Set<TEntity>().Remove(entity);
        await Task.CompletedTask;
    }
}