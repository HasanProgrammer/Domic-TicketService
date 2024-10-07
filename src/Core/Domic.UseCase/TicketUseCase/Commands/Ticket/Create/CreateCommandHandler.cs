using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Create;

public class CreateCommandHandler(
    ITicketCommandRepository ticketCommandRepository, IGlobalUniqueIdGenerator globalUniqueIdGenerator,
    IDateTime dateTime, ISerializer serializer
) : ICommandHandler<CreateCommand, string>
{
    [WithTransaction]
    public Task<string> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        var newTicket = new Domain.Ticket.Entities.Ticket(
            globalUniqueIdGenerator, dateTime, serializer, command.UserId, command.CategoryId, command.Title, 
            command.Description, command.Priority, command.UserId, command.UserRoles
        );
        
        ticketCommandRepository.Add(newTicket);

        return Task.FromResult(newTicket.Id);
    }
}