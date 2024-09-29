using Microsoft.EntityFrameworkCore;
using VibePod.Core.Repositories;
using VibePod.Repository.DbContexts;

namespace VibePod.Repository.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly VibePodDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    public GenericRepository(VibePodDbContext vibePodDbContext)
    {
        _context = vibePodDbContext;
        _dbSet = _context.Set<TEntity>();
    }
    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(TEntity entity)
    {
        _context.Remove(entity);
        return _context.SaveChangesAsync();
    }

    public async Task<IQueryable<TEntity>> GetAllAsync()
    {
        return _dbSet.AsNoTracking();

    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}