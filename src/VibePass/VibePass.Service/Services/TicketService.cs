using AutoMapper;
using VibePass.Core.Entities;
using VibePass.Core.Models.Ticket;
using VibePass.Core.Repository;
using VibePass.Core.Service;

namespace VibePass.Service.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public TicketService(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateTicketRequest createTicketRequest)
    {
        Ticket ticket = _mapper.Map<Ticket>(createTicketRequest);
        await _ticketRepository.CreateAsync(ticket);
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
        var ticket = await _ticketRepository.GetByIdAsync(id);
        if (ticket == null)
        {
            throw new Exception("Ticket not found.");
        }
        var entity = _mapper.Map<Ticket>(ticket);
        entity.Name = updateTicketRequest.Name;
        entity.Price = updateTicketRequest.Price;
        entity.Quantity = updateTicketRequest.Quantity;
        entity.Description = updateTicketRequest.Description;

        await _ticketRepository.UpdateAsync(id, entity);
    }
}
