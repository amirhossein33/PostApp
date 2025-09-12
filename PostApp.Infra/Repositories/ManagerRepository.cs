using Microsoft.EntityFrameworkCore;
using PostApp.Application.Interfaces.Repositories;
using PostApp.Domain.Entities;
using PostApp.Infra.Data;

namespace PostApp.Infra.Repositories;

/// <summary>
/// Manager repository implementation
/// </summary>
public class ManagerRepository : Repository<Manager>, IManagerRepository
{
    public ManagerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Manager?> GetByManagerNumberAsync(string managerNumber, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FirstOrDefaultAsync(m => m.ManagerNumber == managerNumber, cancellationToken);
    }

    public async Task<IEnumerable<Manager>> GetManagersWithMissionsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Missions)
            .ToListAsync(cancellationToken);
    }

    public async Task<Manager?> GetManagerWithMissionsByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Missions)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }
}