using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.UserUseCase.Events;

public class ActiveUserConsumerEventBusHandler(ITicketCommandRepository ticketCommandRepository, IDateTime dateTime) 
    : IConsumerEventBusHandler<UserActived>
{
    public void Handle(UserActived @event){}

    [TransactionConfig(Type = TransactionType.Command)]
    public async Task HandleAsync(UserActived @event, CancellationToken cancellationToken)
    {
        var tickets =
            await ticketCommandRepository.FindByUserIdConditionallyAsync(@event.Id,
                ticket => ticket.IsActive == IsActive.InActive, cancellationToken
            );

        if (tickets.Count != 0)
        {
            foreach (var ticket in tickets)
                ticket.Active(dateTime, @event.UpdatedBy, @event.UpdatedRole, false);

            await ticketCommandRepository.ChangeRangeAsync(tickets, cancellationToken);
        }
    }

    public void AfterTransactionHandle(UserActived @event){}

    public Task AfterTransactionHandleAsync(UserActived @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}