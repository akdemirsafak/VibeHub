using VibePod.Core.Entities;

namespace VibePod.Core.Repositories;

public interface IPlanRepository
{
    Task<IQueryable<Plan>> GetAllAsync();
    Task<Plan> GetByIdAsync(string id);
    Task CreateAsync(Plan plan);
    Task UpdateAsync(Plan plan);
    Task DeleteAsync(string id);
}
