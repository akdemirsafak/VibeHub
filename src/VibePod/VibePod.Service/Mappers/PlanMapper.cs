using AutoMapper;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request;
using VibePod.Core.Models.Response;

namespace VibePod.Service.Mappers;

public sealed class PlanMapper : Profile
{
    public PlanMapper()
    {
        CreateMap<CreatePlanRequest, Plan>();
        CreateMap<Plan, PlanResponse>().ReverseMap();
    }
}
