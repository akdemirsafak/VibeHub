using VibePass.Core.Models.Eventy;

namespace VibePass.Core.Models.Ticket;

public class TicketResponse : BaseResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public virtual EventyResponse Eventy { get; set; }
    public string EventyId { get; set; }
}
