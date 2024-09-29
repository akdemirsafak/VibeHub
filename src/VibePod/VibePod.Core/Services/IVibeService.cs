using VibePod.Core.Models.Request.Vibe;
using VibePod.Core.Models.Response;

namespace VibePod.Core.Services;

public interface IVibeService
{
    Task<List<VibeResponse>> GetAllAsync();
    Task<VibeResponse> GetByIdAsync(string id);
    Task<VibeResponse> CreateAsync(CreateVibeRequest request);
    Task<VibeResponse> UpdateAsync(string id, UpdateVibeRequest request);
    Task DeleteAsync(string id);
}
