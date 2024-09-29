using VibePod.Core.Models.Request;
using VibePod.Core.Models.Response;

namespace VibePod.Core.Services;

public interface IPlanService
{
    Task<List<PlanResponse>> GetAllAsync();
    Task<PlanResponse> GetByIdAsync(string id);
    Task<PlanResponse> CreateAsync(CreatePlanRequest request);
    Task<PlanResponse> UpdateAsync(string id, UpdatePlanRequest request);
    Task DeleteAsync(string id);

}
