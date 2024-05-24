using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Persistence.Contexts.C;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class TicketCommandRepository(SQLContext context) : ITicketCommandRepository
{
    public void Add(Ticket entity) => context.Tickets.Add(entity);
}