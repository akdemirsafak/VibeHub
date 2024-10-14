using AutoMapper;
using VibePass.Core.Entities;
using VibePass.Core.Models.Category;
using VibePass.Core.Repository;
using VibePass.Core.Service;

namespace VibePass.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCategoryRequest categoryRequest)
    {
        Category category = _mapper.Map<Category>(categoryRequest);
        await _categoryRepository.CreateAsync(category);
    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        return await _categoryRepository.DeleteByIdAsync(id);
    }

    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<CategoryResponse> GetByIdAsync(string id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(string id, UpdateCategoryRequest categoryRequest)
    {
        await _categoryRepository.UpdateAsync(id, new Category
        {
            Name = categoryRequest.Name,
            Description = categoryRequest.Description
        });
    }
}
