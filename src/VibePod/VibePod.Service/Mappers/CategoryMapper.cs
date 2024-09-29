using AutoMapper;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request.Category;
using VibePod.Core.Models.Response;

namespace VibePod.Service.Mappers;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryResponse>();
        CreateMap<CreateCategoryRequest, Category>();

    }
}
