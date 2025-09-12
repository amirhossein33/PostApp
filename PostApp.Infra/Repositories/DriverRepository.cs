using Microsoft.EntityFrameworkCore;
using PostApp.Application.Interfaces.Repositories;
using PostApp.Domain.Entities;
using PostApp.Infra.Data;

namespace PostApp.Infra.Repositories;

public class DriverRepository : Repository<Driver>, IDriverRepository
{
    public DriverRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Driver?> GetByDriverNumberAsync(string driverNumber, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FirstOrDefaultAsync(d => d.DriverNumber == driverNumber, cancellationToken);
    }

    public async Task<IEnumerable<Driver>> GetActiveDriversAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(d => d.Active)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Driver>> GetRunningDriversAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(d => d.IsRunning && d.Active)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Driver>> GetDriversWithMissionsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(d => d.Missions)
            .ToListAsync(cancellationToken);
    }

    public async Task<Driver?> GetDriverWithMissionsByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(d => d.Missions)
            .ThenInclude(m => m.Manager)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }
}