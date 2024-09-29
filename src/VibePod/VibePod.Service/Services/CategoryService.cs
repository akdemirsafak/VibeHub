using AutoMapper;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request.Category;
using VibePod.Core.Models.Response;
using VibePod.Core.Repositories;
using VibePod.Core.Services;

namespace VibePod.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository,
    IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryResponse> CreateAsync(CreateCategoryRequest request)
    {
        Category category = _mapper.Map<Category>(request);
        category.CreatedAt = DateTime.UtcNow;
        await _categoryRepository.CreateAsync(category);
        return _mapper.Map<CategoryResponse>(category);

    }

    public async Task DeleteAsync(string id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        category.IsDeleted = true;
        category.DeletedAt = DateTime.UtcNow;
        await _categoryRepository.UpdateAsync(category);
        //await _categoryRepository.DeleteAsync(id);
    }

    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        var result = await _categoryRepository.GetAllAsync();
        return _mapper.Map<List<CategoryResponse>>(result.ToList());
    }

    public async Task<CategoryResponse> GetByIdAsync(string id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        return _mapper.Map<CategoryResponse>(category);
    }

    public async Task<CategoryResponse> UpdateAsync(string id, UpdateCategoryRequest request)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        category.Name = request.Name;
        category.ImageUrl = request.ImageUrl;
        category.UpdatedAt = DateTime.UtcNow;


        await _categoryRepository.UpdateAsync(category);

        return _mapper.Map<CategoryResponse>(category);
    }
}
