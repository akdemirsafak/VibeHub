using VibePass.Core.Entities;
using VibePass.Core.Models.Category;

namespace VibePass.Core.Repository;

public interface ICategoryRepository : IGenericRepository<Category, CategoryResponse>
{
}