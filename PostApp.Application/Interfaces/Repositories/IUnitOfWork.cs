namespace PostApp.Application.Interfaces.Repositories;

/// <summary>
/// Unit of Work pattern interface for managing transactions and repositories
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Driver repository
    /// </summary>
    IDriverRepository Drivers { get; }

    /// <summary>
    /// Manager repository
    /// </summary>
    IManagerRepository Managers { get; }

    /// <summary>
    /// Mission repository
    /// </summary>
    IMissionRepository Missions { get; }

    /// <summary>
    /// Saves all changes asynchronously
    /// </summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Begins a database transaction
    /// </summary>
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Commits the current transaction
    /// </summary>
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Rolls back the current transaction
    /// </summary>
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}