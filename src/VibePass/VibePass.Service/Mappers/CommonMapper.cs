using AutoMapper;
using VibePass.Core.Entities;
using VibePass.Core.Models.Category;
using VibePass.Core.Models.Eventy;
using VibePass.Core.Models.Ticket;

namespace VibePass.Service.Mappers;

public class CommonMapper : Profile
{
    public CommonMapper()
    {
        ////
        CreateMap<CreateTicketRequest, Ticket>()
            .ForMember(destinationMember => destinationMember.CreatedAt, memberOptions => memberOptions.MapFrom(source => DateTime.UtcNow));
        CreateMap<TicketResponse, Ticket>().ReverseMap();
        ////
        CreateMap<CreateEventyRequest, Eventy>()
            .ForMember(destinationMember => destinationMember.CreatedAt, memberOptions => memberOptions.MapFrom(source => DateTime.UtcNow));
        CreateMap<EventyResponse, Eventy>().ReverseMap();
        ////
        CreateMap<CreateCategoryRequest, Category>()
            .ForMember(destinationMember => destinationMember.CreatedAt, memberOptions => memberOptions.MapFrom(source => DateTime.UtcNow));
        CreateMap<CategoryResponse, Category>().ReverseMap();
    }
}
