using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.CategoryUseCase.Events;

public class DeleteCategoryConsumerEventBusHandler(ITicketCommandRepository ticketCommandRepository, IDateTime dateTime, 
    ISerializer serializer
) : IConsumerEventBusHandler<CategoryDeleted>
{
    public void Handle(CategoryDeleted @event){}
    
    [TransactionConfig(Type = TransactionType.Command)]
    public async Task HandleAsync(CategoryDeleted @event, CancellationToken cancellationToken)
    {
        var tickets =
            await ticketCommandRepository.FindByCategoryIdConditionallyAsync(@event.Id,
                ticket => ticket.IsDeleted == IsDeleted.UnDelete, cancellationToken
            );

        if (tickets.Count != 0)
        {
            foreach (var ticket in tickets)
                ticket.Delete(dateTime, serializer, @event.UpdatedBy, new[]{ @event.UpdatedRole }, false);

            ticketCommandRepository.ChangeRange(tickets);
        }
    }

    public void AfterTransactionHandle(CategoryDeleted @event){}

    public Task AfterTransactionHandleAsync(CategoryDeleted @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}