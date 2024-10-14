namespace VibePass.Core.Models.Ticket;

public record CreateTicketRequest(string Name, decimal Price, int Quantity, string EventId, string? Description);
