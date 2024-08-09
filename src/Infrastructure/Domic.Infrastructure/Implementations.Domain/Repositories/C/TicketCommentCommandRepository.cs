using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Persistence.Contexts.C;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class TicketCommentCommandRepository(SQLContext context) : ITicketCommentCommandRepository
{
    public void Add(TicketComment entity) => context.TicketComments.Add(entity);
}