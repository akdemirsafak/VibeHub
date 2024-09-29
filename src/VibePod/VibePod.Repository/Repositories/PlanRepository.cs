using VibePod.Core.Entities;
using VibePod.Core.Repositories;
using VibePod.Repository.DbContexts;

namespace VibePod.Repository.Repositories;

public class PlanRepository : GenericRepository<Plan>, IPlanRepository
{
    public PlanRepository(VibePodDbContext vibePodDbContext) : base(vibePodDbContext)
    {
    }
}
