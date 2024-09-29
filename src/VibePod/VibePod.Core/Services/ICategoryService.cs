using VibePod.Core.Models.Request.Category;
using VibePod.Core.Models.Response;

namespace VibePod.Core.Services;

public interface ICategoryService
{
    Task<List<CategoryResponse>> GetAllAsync();
    Task<CategoryResponse> GetByIdAsync(string id);
    Task<CategoryResponse> CreateAsync(CreateCategoryRequest request);
    Task<CategoryResponse> UpdateAsync(string id, UpdateCategoryRequest request);
    Task DeleteAsync(string id);

}
