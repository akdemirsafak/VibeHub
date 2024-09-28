using AutoMapper;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request;
using VibePod.Core.Models.Response;
using VibePod.Core.Repositories;
using VibePod.Core.Services;

namespace VibePod.Service.Services;

public class PlanService : IPlanService
{
    private readonly IPlanRepository _planRepository;
    private readonly IMapper _mapper;

    public PlanService(IPlanRepository planRepository, IMapper mapper)
    {
        _planRepository = planRepository;
        _mapper = mapper;
    }

    public async Task<PlanResponse> CreateAsync(CreatePlanRequest request)
    {
        Plan plan= _mapper.Map<Plan>(request);
        plan.CreatedAt = DateTime.UtcNow;
        await _planRepository.CreateAsync(plan);
        return _mapper.Map<PlanResponse>(plan);

    }

    public async Task DeleteAsync(string id)
    {
        var plan= await _planRepository.GetByIdAsync(id);
        plan.IsDeleted = true;
        plan.DeletedAt = DateTime.UtcNow;
        await _planRepository.UpdateAsync(plan);
        //await _planRepository.DeleteAsync(id);
    }

    public async Task<List<PlanResponse>> GetAlLAsync()
    {
        var result = await _planRepository.GetAllAsync();
        return  _mapper.Map<List<PlanResponse>>(result.ToList());
    }

    public async Task<PlanResponse> GetByIdAsync(string id)
    {
        var plan = await _planRepository.GetByIdAsync(id);

        return _mapper.Map<PlanResponse>(plan);
    }

    public async Task<PlanResponse> UpdateAsync(string id, UpdatePlanRequest request)
    {
        var plan= await _planRepository.GetByIdAsync(id);
        plan.Name = request.Name;
        plan.Description = request.Description;
        plan.Price = request.Price;
        plan.UpdatedAt = DateTime.UtcNow;


        await _planRepository.UpdateAsync(plan);

        return _mapper.Map<PlanResponse>(plan);
    }
}
