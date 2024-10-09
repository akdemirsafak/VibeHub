using VibePass.Core.Entities;
using VibePass.Core.Models.Ticket;
using VibePass.Core.Repository;
using VibePass.Core.Service;

namespace VibePass.Service.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task CreateAsync(CreateTicketRequest createTicketRequest)
    {
        await _ticketRepository.CreateAsync(new Ticket
        {
            Name=createTicketRequest.Name,
            Price = createTicketRequest.Price,
            Quantity = createTicketRequest.Quantity,
            EventyId = createTicketRequest.EventId,
            Description = createTicketRequest.Description
        });
    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        return await _ticketRepository.DeleteByIdAsync(id);
    }

    public async Task<List<TicketResponse>> GetAllAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }

    public async Task<TicketResponse> GetByIdAsync(string id)
    {
        return await _ticketRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(string id, UpdateTicketRequest updateTicketRequest)
    {
        await _ticketRepository.UpdateAsync(id, new Ticket
        {
            Name = updateTicketRequest.Name,
            Price = updateTicketRequest.Price,
            Quantity = updateTicketRequest.Quantity,
            Description = updateTicketRequest.Description
        });
    }
}
