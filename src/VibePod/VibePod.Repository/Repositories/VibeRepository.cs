using VibePod.Core.Entities;
using VibePod.Core.Repositories;
using VibePod.Repository.DbContexts;

namespace VibePod.Repository.Repositories;

public class VibeRepository : GenericRepository<Vibe>, IVibeRepository
{
    public VibeRepository(VibePodDbContext vibePodDbContext) : base(vibePodDbContext)
    {
    }
}
