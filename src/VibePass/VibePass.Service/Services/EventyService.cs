using VibePass.Core.Models.Eventy;
using VibePass.Core.Repository;
using VibePass.Core.Service;

namespace VibePass.Service.Services;

public class EventyService : IEventyService
{
    private readonly IEventyRepository _eventyRepository;

    public EventyService(IEventyRepository eventyRepository)
    {
        _eventyRepository = eventyRepository;
    }

    public Task CreateAsync(CreateEventyRequest createEventyRequest)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<EventyResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EventyResponse> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, UpdateEventyRequest updateEventyRequest)
    {
        throw new NotImplementedException();
    }
}