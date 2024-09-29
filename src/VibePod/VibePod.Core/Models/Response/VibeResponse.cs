namespace VibePod.Core.Models.Response;

public class VibeResponse
{
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public virtual ICollection<ContentResponse> Contents { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
