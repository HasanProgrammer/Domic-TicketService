using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.CategoryUseCase.Events;

public class DeleteCategoryConsumerEventBusHandler(ITicketCommandRepository ticketCommandRepository, IDateTime dateTime) 
    : IConsumerEventBusHandler<CategoryDeleted>
{
    public Task BeforeHandleAsync(CategoryDeleted @event, CancellationToken cancellationToken)
        => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Command)]
    public async Task HandleAsync(CategoryDeleted @event, CancellationToken cancellationToken)
    {
        var tickets = await ticketCommandRepository.FindByCategoryIdAsync(@event.Id, cancellationToken);

        if (tickets.Count != 0)
        {
            foreach (var ticket in tickets)
                ticket.Delete(dateTime, @event.UpdatedBy, @event.UpdatedRole, false);

            await ticketCommandRepository.ChangeRangeAsync(tickets, cancellationToken);
        }
    }

    public Task AfterHandleAsync(CategoryDeleted @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}