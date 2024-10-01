using AutoMapper;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request.Content;
using VibePod.Core.Models.Response;
using VibePod.Core.Repositories;
using VibePod.Core.Services;

namespace VibePod.Service.Services;

public class ContentService : IContentService
{
    private readonly IContentRepository _contentRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IVibeRepository _vibeRepository;
    private readonly IMapper _mapper;

    public ContentService(IContentRepository contentRepository, 
        IMapper mapper)
    {
        _contentRepository = contentRepository;
        _mapper = mapper;
    }

    public async Task<ContentResponse> CreateAsync(CreateContentRequest request)
    {
        List<Vibe> vibeList = new();
        foreach (var vibeId in request.SelectedMoods)
        {
            Vibe existVibe = await _vibeRepository.GetByIdAsync(vibeId);
            if (existVibe is not null)
                vibeList.Add(existVibe);
        }

        //Categories
        List<Category> categoryList = new();
        foreach (var categoryId in request.SelectedCategories)
        {
            Category existCategory = await _categoryRepository.GetByIdAsync(categoryId);
            if (existCategory != null)
                categoryList.Add(existCategory);
        }

        var content = new Content()
        {
            Name = request.Name,
            Lyrics = request.Lyrics,
            //ImageUrl = imageUrl,    => File upload is not implemented yet
            Categories = categoryList,
            Vibes = vibeList
        };

        //SaveOperations
        await _contentRepository.CreateAsync(content);
        //return content.Adapt<CreatedContentResponse>();
        return _mapper.Map<ContentResponse>(content);
    }

    public async Task DeleteAsync(string id)
    {
        var content = await _contentRepository.GetByIdAsync(id);
        await _contentRepository.DeleteAsync(content);
    }

    public async Task<List<ContentResponse>> GetAllAsync()
    {
        var contents= await _contentRepository.GetAllAsync();

        return _mapper.Map<List<ContentResponse>>(contents);    
    }

    public async Task<ContentResponse> GetByIdAsync(string id)
    {
        var content= await _contentRepository.GetByIdAsync(id);
        return _mapper.Map<ContentResponse>(content);
    }

    public async Task<ContentResponse> UpdateAsync(string id, UpdateContentRequest request)
    {
        var content= await _contentRepository.GetByIdAsync(id);
        content.Name = request.Name;
        content.Lyrics = request.Lyrics;
        // Burada diğer alanları doldurabiliriz.
        await _contentRepository.UpdateAsync(content);
        return _mapper.Map<ContentResponse>(content);
    }
}