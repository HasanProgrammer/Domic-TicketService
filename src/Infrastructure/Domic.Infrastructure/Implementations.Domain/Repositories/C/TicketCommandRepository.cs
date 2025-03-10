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
                        .Where(ticket => ticket.CreatedBy == userId)
                        .Where(condition)
                        .ToListAsync(cancellationToken);

    public Task<List<Ticket>> FindByCategoryIdAsync(string categoryId, CancellationToken cancellationToken) 
        =>  context.Tickets.AsNoTracking()
                           .Where(ticket => ticket.CategoryId == categoryId)
                           .ToListAsync(cancellationToken);

    public Task AddAsync(Ticket entity, CancellationToken cancellationToken)
    {
        context.Tickets.Add(entity);

        return Task.CompletedTask;
    }

    public Task ChangeRangeAsync(List<Ticket> entities, CancellationToken cancellationToken)
    {
        context.Tickets.UpdateRange(entities);

        return Task.CompletedTask;
    }
}