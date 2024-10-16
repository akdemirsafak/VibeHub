using VibePass.Core.Entities;
using VibePass.Core.Models.Performer;
using VibePass.Core.Repository;
using VibePass.Core.Service;

namespace VibePass.Service.Services;

public class PerformerService : IPerformerService
{
    private readonly IPerformerRepository _performerRepository;

    public PerformerService(IPerformerRepository performerRepository)
    {
        _performerRepository = performerRepository;
    }

    public async Task CreateAsync(CreatePerformerRequest performerRequest)
    {
        Performer performer = new Performer
        {
            Name = performerRequest.Name,
            LastName = performerRequest.LastName,
            About = performerRequest.About,
            BirthDate = performerRequest.BirthDate
        };
        await _performerRepository.CreateAsync(performer);
    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        return await _performerRepository.DeleteByIdAsync(id);
    }

    public async Task<List<PerformerResponse>> GetAllAsync()
    {
        return await _performerRepository.GetAllAsync();
    }

    public async Task<PerformerResponse> GetByIdAsync(string id)
    {
        return await _performerRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(string id, UpdatePerformerRequest performerRequest)
    {
        await _performerRepository.UpdateAsync(id, new Performer
        {
            Name = performerRequest.Name,
            LastName = performerRequest.LastName,
            About = performerRequest.About,
            BirthDate = performerRequest.BirthDate
        }); 
    }
}
