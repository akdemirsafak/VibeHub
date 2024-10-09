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
        CreateMap<CreateTicketRequest,Ticket>();
        CreateMap<CreateEventyRequest,Eventy>();
        CreateMap<CreateCategoryRequest,Category>();
    }     
}
