using VibePass.Core.Models.Eventy;

namespace VibePass.Core.Service;

public interface IEventyService
{
    Task<List<EventyResponse>> GetAllAsync();
    Task<EventyResponse> GetByIdAsync(string id);
    Task CreateAsync(CreateEventyRequest createEventyRequest);
    Task UpdateAsync(string id, UpdateEventyRequest updateEventyRequest);
    Task<int> DeleteByIdAsync(string id);
}
