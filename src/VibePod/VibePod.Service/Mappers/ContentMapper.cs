using AutoMapper;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request.Content;
using VibePod.Core.Models.Response;

namespace VibePod.Service.Mappers;

public class ContentMapper : Profile
{
    public ContentMapper()
    {
        CreateMap<Content, ContentResponse>();
        CreateMap<CreateContentRequest, Content>();
    }
}
