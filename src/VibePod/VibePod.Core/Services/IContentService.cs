using VibePod.Core.Models.Request.Content;
using VibePod.Core.Models.Response;

namespace VibePod.Core.Services;

public interface IContentService
{
    Task<List<ContentResponse>> GetAllAsync();
    Task<ContentResponse> GetByIdAsync(string id);
    Task<ContentResponse> CreateAsync(CreateContentRequest request);
    Task<ContentResponse> UpdateAsync(string id, UpdateContentRequest request);
    Task DeleteAsync(string id);
}
