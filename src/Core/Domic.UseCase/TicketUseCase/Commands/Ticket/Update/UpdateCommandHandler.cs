#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Update;

public class UpdateCommandHandler(ITicketCommandRepository ticketCommandRepository, IDateTime dateTime, 
    ISerializer serializer, [FromKeyedServices("Http2")] IIdentityUser identityUser
) : ICommandHandler<UpdateCommand, string>
{
    private readonly object _validationResult;
    
    [WithTransaction, WithValidation]
    public Task<string> HandleAsync(UpdateCommand command, CancellationToken cancellationToken)
    {
        var ticket = _validationResult as Domain.Ticket.Entities.Ticket;
        
        ticket.Change(dateTime, serializer, identityUser, command.CategoryId, command.Title, command.Description, 
            command.Priority, command.Status
        );
        
        ticketCommandRepository.Change(ticket);

        return Task.FromResult(ticket.Id);
    }

    public Task AfterTransactionHandleAsync(UpdateCommand message, CancellationToken cancellationToken)
        => Task.CompletedTask;
}