namespace VibePass.Core.Models.Eventy;

public class EventyResponse : BaseResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; }
    public string? ImageUrl { get; set; }
    //public virtual ICollection<Performer> Performers { get; set; }
    //public virtual ICollection<CategoryResponse> Category { get; set; }
    //public virtual ICollection<TicketResponse> Tickets { get; set; }
   
}
