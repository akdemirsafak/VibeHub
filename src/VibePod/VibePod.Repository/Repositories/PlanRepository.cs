using Microsoft.EntityFrameworkCore;
using VibePod.Core.Entities;
using VibePod.Core.Repositories;
using VibePod.Repository.DbContexts;

namespace VibePod.Repository.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly VibePodDbContext _context;

    public PlanRepository(VibePodDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Plan plan)
    {
        await _context.Plans.AddAsync(plan);
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task DeleteAsync(string id)
    {
        await _context.Plans.Where(x => x.Id == id).ExecuteDeleteAsync();
        await _context.SaveChangesAsync(CancellationToken.None); // ihtiyaç var mı kontrol edelim.
    }

    public async Task<IQueryable<Plan>> GetAllAsync()
    {
        return _context.Plans.AsNoTracking();
    }

    public async Task<Plan> GetByIdAsync(string id)
    {
        return await _context.Plans.FindAsync(id);
    }

    public async Task UpdateAsync(Plan plan)
    {
        _context.Plans.Update(plan);
        await _context.SaveChangesAsync(CancellationToken.None);
    }
}
