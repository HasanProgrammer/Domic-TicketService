using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Domain.Service.Entities;
using Domic.Persistence.Contexts.C;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class TicketCommandRepository(SQLContext context) : ITicketCommandRepository
{
    public void Add(Ticket entity) => context.Tickets.Add(entity);
}