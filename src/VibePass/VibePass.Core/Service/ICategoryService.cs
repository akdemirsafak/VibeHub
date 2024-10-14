using VibePass.Core.Models.Category;

namespace VibePass.Core.Service;

public interface ICategoryService
{
    Task<List<CategoryResponse>> GetAllAsync();
    Task<CategoryResponse> GetByIdAsync(string id);
    Task CreateAsync(CreateCategoryRequest categoryRequest);
    Task UpdateAsync(string id, UpdateCategoryRequest categoryRequest);
    Task<int> DeleteByIdAsync(string id);
}
