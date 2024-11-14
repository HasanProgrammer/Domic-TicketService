#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Update;

public class UpdateCommandHandler(ITicketCommandRepository ticketCommandRepository, IDateTime dateTime, 
    ISerializer serializer
) : ICommandHandler<UpdateCommand, string>
{
    private readonly object _validationResult;
    
    [WithTransaction, WithValidation]
    public Task<string> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
    {
        var ticket = _validationResult as Domain.Ticket.Entities.Ticket;
        
        ticket.Change(dateTime, serializer, command.CategoryId, command.Title, command.Description, command.Priority, 
            command.Status, command.UserId, command.UserRoles
        );
        
        ticketCommandRepository.Change(ticket);

        return Task.FromResult(ticket.Id);
    }

    public Task AfterTransactionHandleAsync(UpdateCommand message, CancellationToken cancellationToken)
        => Task.CompletedTask;
}