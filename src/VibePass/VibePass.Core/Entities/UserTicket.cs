namespace VibePass.Core.Entities;

public class UserTicket
{
    public string Id { get; set; }
    public string EventName { get; set; }
    public string TicketName { get; set; }
    public string TicketId { get; set; }
    public decimal Price { get; set; }
    public string Address { get; set; }
    public string UserId { get; set; }
    public string UserFullName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public bool IsUsed { get; set; }
    public bool IsExpired { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string QRCode { get; set; }

}
