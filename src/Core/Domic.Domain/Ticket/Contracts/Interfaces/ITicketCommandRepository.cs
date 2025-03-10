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
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="condition"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<List<Entities.Ticket>> FindByCategoryIdAsync(string categoryId, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entities"></param>
    public Task ChangeRangeAsync(List<Entities.Ticket> entities, CancellationToken cancellationToken);
}