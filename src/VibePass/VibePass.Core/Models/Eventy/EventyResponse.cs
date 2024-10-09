using VibePass.Core.Models.Category;
using VibePass.Core.Models.Ticket;

namespace VibePass.Core.Models.Eventy;

public class EventyResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; }
    public string? ImageUrl { get; set; }
    //public virtual ICollection<Performer> Performers { get; set; }
    public virtual ICollection<CategoryResponse> Category { get; set; }
    public virtual ICollection<TicketResponse> Tickets { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
