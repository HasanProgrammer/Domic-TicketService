#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Domain.Service.Entities;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Delete;

public class DeleteCommandHandler(ITicketCommandRepository ticketCommandRepository, IDateTime dateTime, 
    ISerializer serializer
) : ICommandHandler<DeleteCommand, string>
{
    private readonly object _validationResult;
    
    [WithTransaction, WithValidation]
    public Task<string> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
    {
        var ticket = _validationResult as Domain.Service.Entities.Ticket;
        
        ticket.Delete(dateTime, serializer, command.UserId, command.UserRoles);
        
        ticketCommandRepository.Change(ticket);

        return Task.FromResult(ticket.Id);
    }
}