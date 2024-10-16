namespace VibePass.Core.Models.Category;

public class CategoryResponse : BaseResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
