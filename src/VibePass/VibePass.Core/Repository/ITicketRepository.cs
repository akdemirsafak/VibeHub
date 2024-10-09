using VibePass.Core.Entities;
using VibePass.Core.Models.Ticket;

namespace VibePass.Core.Repository;

public interface ITicketRepository : IGenericRepository<Ticket, TicketResponse>
{
}
