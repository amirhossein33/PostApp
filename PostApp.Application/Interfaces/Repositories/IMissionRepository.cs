using PostApp.Domain.Entities;

namespace PostApp.Application.Interfaces.Repositories;

/// <summary>
/// Mission-specific repository interface
/// </summary>
public interface IMissionRepository : IRepository<Mission>
{
    /// <summary>
    /// Gets missions by manager id
    /// </summary>
    Task<IEnumerable<Mission>> GetByManagerIdAsync(int managerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets missions by driver id
    /// </summary>
    Task<IEnumerable<Mission>> GetByDriverIdAsync(int driverId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets missions created within date range
    /// </summary>
    Task<IEnumerable<Mission>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets missions with manager and driver details
    /// </summary>
    Task<IEnumerable<Mission>> GetMissionsWithDetailsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets mission with details by id
    /// </summary>
    Task<Mission?> GetMissionWithDetailsByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets recent missions (last 30 days)
    /// </summary>
    Task<IEnumerable<Mission>> GetRecentMissionsAsync(CancellationToken cancellationToken = default);
}