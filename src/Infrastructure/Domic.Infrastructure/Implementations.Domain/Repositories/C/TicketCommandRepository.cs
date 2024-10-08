using System.Linq.Expressions;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Entities;
using Domic.Persistence.Contexts.C;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class TicketCommandRepository(SQLContext context) : ITicketCommandRepository
{
    public Task<List<Ticket>> FindByUserIdConditionallyAsync(string userId, Expression<Func<Ticket, bool>> condition, 
        CancellationToken cancellationToken
    ) => context.Tickets.AsNoTracking()
                        .Where(ticket => ticket.UserId == userId)
                        .Where(condition)
                        .ToListAsync(cancellationToken);

    public Task<List<Ticket>> FindByCategoryIdConditionallyAsync(string categoryId,
        Expression<Func<Ticket, bool>> condition, CancellationToken cancellationToken
    ) => context.Tickets.AsNoTracking()
                        .Where(ticket => ticket.CategoryId == categoryId)
                        .Where(condition)
                        .ToListAsync(cancellationToken);

    public void Add(Ticket entity) => context.Tickets.Add(entity);

    public void ChangeRange(List<Ticket> entities) => context.Tickets.UpdateRange(entities);
}