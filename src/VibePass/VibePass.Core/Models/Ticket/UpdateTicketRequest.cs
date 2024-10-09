namespace VibePass.Core.Models.Ticket;

public record UpdateTicketRequest(string Name, decimal Price, int Quantity, string? Description);