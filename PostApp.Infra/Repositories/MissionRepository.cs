using Microsoft.EntityFrameworkCore;
using PostApp.Application.Interfaces.Repositories;
using PostApp.Domain.Entities;
using PostApp.Infra.Data;

namespace PostApp.Infra.Repositories;

/// <summary>
/// Mission repository implementation
/// </summary>
public class MissionRepository : Repository<Mission>, IMissionRepository
{
    public MissionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Mission>> GetByManagerIdAsync(int managerId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(m => m.ManagerId == managerId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Mission>> GetByDriverIdAsync(int driverId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(m => m.DriverId == driverId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Mission>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(m => m.CreatedDatetime >= startDate && m.CreatedDatetime <= endDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Mission>> GetMissionsWithDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Manager)
            .Include(m => m.Driver)
            .ToListAsync(cancellationToken);
    }

    public async Task<Mission?> GetMissionWithDetailsByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Manager)
            .Include(m => m.Driver)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Mission>> GetRecentMissionsAsync(CancellationToken cancellationToken = default)
    {
        var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
        return await _dbSet
            .Where(m => m.CreatedDatetime >= thirtyDaysAgo)
            .Include(m => m.Manager)
            .Include(m => m.Driver)
            .OrderByDescending(m => m.CreatedDatetime)
            .ToListAsync(cancellationToken);
    }
}