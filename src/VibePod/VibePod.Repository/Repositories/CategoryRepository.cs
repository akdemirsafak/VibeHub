using VibePod.Core.Entities;
using VibePod.Core.Repositories;
using VibePod.Repository.DbContexts;

namespace VibePod.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(VibePodDbContext vibePodDbContext) : base(vibePodDbContext)
    {
    }
}
