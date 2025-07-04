namespace NovaCode_Web_Services.Shared.Domain.Repositories;

/// <summary>
///     Unit of Work interface for managing database transactions.
/// </summary>
/// <remarks>
///     This interface defines the basic operations for a unit of work
/// </remarks>
public interface IUnitOfWork
{
    /// <summary>
    ///     Commit changes to the database.
    /// </summary>
    Task CompleteAsync();
    Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
    Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class;
}