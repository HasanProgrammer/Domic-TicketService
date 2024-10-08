using System.Linq.Expressions;
using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Ticket.Contracts.Interfaces;

public interface ITicketCommandRepository : ICommandRepository<Entities.Ticket, string>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<List<Entities.Ticket>> FindByUserIdConditionallyAsync(string userId, 
        Expression<Func<Entities.Ticket, bool>> condition, CancellationToken cancellationToken
    );

    public void ChangeRange(List<Entities.Ticket> entities);
}