using AutoMapper;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request.Vibe;
using VibePod.Core.Models.Response;

namespace VibePod.Service.Mappers;

public class VibeMapper : Profile
{
    public VibeMapper()
    {
        CreateMap<Vibe, VibeResponse>();
        CreateMap<CreateVibeRequest, Vibe>();
    }
}