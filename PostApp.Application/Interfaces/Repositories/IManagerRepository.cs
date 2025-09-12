using PostApp.Domain.Entities;

namespace PostApp.Application.Interfaces.Repositories;

/// <summary>
/// Manager-specific repository interface
/// </summary>
public interface IManagerRepository : IRepository<Manager>
{
    /// <summary>
    /// Gets manager by manager number
    /// </summary>
    Task<Manager?> GetByManagerNumberAsync(string managerNumber, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets managers with their missions
    /// </summary>
    Task<IEnumerable<Manager>> GetManagersWithMissionsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets manager with missions by id
    /// </summary>
    Task<Manager?> GetManagerWithMissionsByIdAsync(int id, CancellationToken cancellationToken = default);
}