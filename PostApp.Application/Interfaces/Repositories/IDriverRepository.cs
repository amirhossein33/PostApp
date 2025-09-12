using PostApp.Domain.Entities;

namespace PostApp.Application.Interfaces.Repositories;

/// <summary>
/// Driver-specific repository interface
/// </summary>
public interface IDriverRepository : IRepository<Driver>
{
    /// <summary>
    /// Gets driver by driver number
    /// </summary>
    Task<Driver?> GetByDriverNumberAsync(string driverNumber, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all active drivers
    /// </summary>
    Task<IEnumerable<Driver>> GetActiveDriversAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all running drivers
    /// </summary>
    Task<IEnumerable<Driver>> GetRunningDriversAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets drivers with their missions
    /// </summary>
    Task<IEnumerable<Driver>> GetDriversWithMissionsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets driver with missions by id
    /// </summary>
    Task<Driver?> GetDriverWithMissionsByIdAsync(int id, CancellationToken cancellationToken = default);
}