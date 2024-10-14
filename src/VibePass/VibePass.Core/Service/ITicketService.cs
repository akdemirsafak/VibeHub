using VibePass.Core.Models.Ticket;

namespace VibePass.Core.Service;

public interface ITicketService
{
    Task<List<TicketResponse>> GetAllAsync();
    Task<TicketResponse> GetByIdAsync(string id);
    Task CreateAsync(CreateTicketRequest createTicketRequest);
    Task UpdateAsync(string id, UpdateTicketRequest updateTicketRequest);
    Task<int> DeleteByIdAsync(string id);
}
