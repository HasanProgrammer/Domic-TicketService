using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Enumerations;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Events;

namespace Domic.UseCase.UserUseCase.Events;

public class InActiveUserConsumerEventBusHandler(ITicketCommandRepository ticketCommandRepository, IDateTime dateTime) 
    : IConsumerEventBusHandler<UserActived>
{
    public Task BeforeHandleAsync(UserActived @event, CancellationToken cancellationToken)
        => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Command)]
    public async Task HandleAsync(UserActived @event, CancellationToken cancellationToken)
    {
        var tickets =
            await ticketCommandRepository.FindByUserIdConditionallyAsync(@event.Id,
                ticket => ticket.IsActive == IsActive.Active, cancellationToken
            );

        if (tickets.Count != 0)
        {
            foreach (var ticket in tickets)
                ticket.InActive(dateTime, @event.UpdatedBy, @event.UpdatedRole, false);

            await ticketCommandRepository.ChangeRangeAsync(tickets, cancellationToken);
        }
    }

    public Task AfterHandleAsync(UserActived @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}