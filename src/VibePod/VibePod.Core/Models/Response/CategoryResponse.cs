namespace VibePod.Core.Models.Response;

public class CategoryResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
