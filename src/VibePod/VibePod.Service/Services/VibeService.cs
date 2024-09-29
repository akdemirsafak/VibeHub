using AutoMapper;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request.Vibe;
using VibePod.Core.Models.Response;
using VibePod.Core.Repositories;
using VibePod.Core.Services;

namespace VibePod.Service.Services;

public class VibeService : IVibeService
{

    private readonly IVibeRepository _vibeRepository;
    private readonly IMapper _mapper;

    public VibeService(IVibeRepository vibeRepository, 
        IMapper mapper)
    {
        _vibeRepository = vibeRepository;
        _mapper = mapper;
    }

    public async Task<VibeResponse> CreateAsync(CreateVibeRequest request)
    {
        var entity= _mapper.Map<Vibe>(request);
        entity.CreatedAt = DateTime.UtcNow;
        await _vibeRepository.CreateAsync(entity);
        return _mapper.Map<VibeResponse>(entity);
    }

    public async Task DeleteAsync(string id)
    {
        var vibe=await _vibeRepository.GetByIdAsync(id);
        vibe.IsDeleted = true;
        vibe.DeletedAt = DateTime.UtcNow;
        await _vibeRepository.UpdateAsync(vibe);

        //await _vibeRepository.DeleteAsync(vibe);
    }

    public async Task<List<VibeResponse>> GetAllAsync()
    {
        var plans= await _vibeRepository.GetAllAsync();
        return _mapper.Map<List<VibeResponse>>(plans);
    }

    public async Task<VibeResponse> GetByIdAsync(string id)
    {
        var vibe= await _vibeRepository.GetByIdAsync(id);
        return _mapper.Map<VibeResponse>(vibe);
    }

    public async Task<VibeResponse> UpdateAsync(string id, UpdateVibeRequest request)
    {
        var entity= await _vibeRepository.GetByIdAsync(id);
        entity.Name = request.Name;
        entity.ImageUrl = request.ImageUrl;
        entity.UpdatedAt = DateTime.UtcNow;
        await _vibeRepository.UpdateAsync(entity);
        return _mapper.Map<VibeResponse>(entity);

    }
}
