using VibePass.Core.Models.Performer;

namespace VibePass.Core.Service;

public interface IPerformerService
{
    Task<List<PerformerResponse>> GetAllAsync();
    Task<PerformerResponse> GetByIdAsync(string id);
    Task CreateAsync(CreatePerformerRequest performerRequest);
    Task UpdateAsync(string id, UpdatePerformerRequest performerRequest);
    Task<int> DeleteByIdAsync(string id);
}
