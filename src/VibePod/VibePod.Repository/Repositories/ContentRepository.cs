using VibePod.Core.Entities;
using VibePod.Core.Repositories;
using VibePod.Repository.DbContexts;

namespace VibePod.Repository.Repositories;

public class ContentRepository : GenericRepository<Content>, IContentRepository
{
    public ContentRepository(VibePodDbContext vibePodDbContext) : base(vibePodDbContext)
    {
    }
}
